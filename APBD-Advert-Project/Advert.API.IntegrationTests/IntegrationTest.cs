using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Advert.API;
using Advert.API.Contracts.V1;
using Advert.Database.Contexts;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;

namespace Advert.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly WebApplicationFactory<Startup> _application;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            _application = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll<DbContextOptions<AdvertContext>>();
                        services.AddDbContext<AdvertContext>(
                            options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = _application.CreateClient();

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        protected async Task AuthenticateAsync()
        {
            var jwt = await GetJwtAsync();
            TestClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", jwt.Token);
        }

        private async Task<JwtTokenResponseModel> GetJwtAsync()
        {
            var registerResponse = await TestClient.PostAsJsonAsync(ApiRoutes.Clients.Create, new ClientRegisterCommand
            {
                FirstName = "stringT",
                LastName = "stringT",
                Email = "stringT@test.net",
                Phone = "stringT",
                Login = "stringT",
                Password = "string123T",
                RepeatPassword = "string123T"
            });

            var registerSuccess = await DeserializeObjectAsync<SuccessResponse<ClientResponseModel>>(registerResponse);
            if (registerSuccess == null) throw new Exception("Cannot deserialize response.");
            if (registerResponse.StatusCode != HttpStatusCode.Created &&
                registerSuccess.Message != "Client with this email already exists.")
                throw new Exception(
                    $"Register client returned: [{registerResponse.StatusCode.ToString()}] [{registerSuccess.Message}]");

            var loginResponse = await TestClient.PostAsJsonAsync(ApiRoutes.Clients.LogIn, new ClientLoginCommand
            {
                Login = "stringT",
                Password = "string123T"
            });

            if (loginResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Login client returned: [{registerResponse.StatusCode.ToString()}]");


            var successResponse = await DeserializeObjectAsync<SuccessResponse<JwtTokenResponseModel>>(loginResponse);
            if (successResponse == null) throw new Exception("Cannot deserialize response.");

            return successResponse.Result;
        }

        protected async Task<T> DeserializeObjectAsync<T>(HttpResponseMessage response) where T : class
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }
    }
}