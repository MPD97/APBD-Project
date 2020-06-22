using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Advert.API;
using Advert.API.Contracts.V1;
using Advert.Database.Contexts;
using Advert.Presistance.Mediator.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Advert.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(AdvertContext));
                        services.AddDbContext<AdvertContext>(
                            options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Clients.Create, new ClientRegisterCommand
            {
                Email = "test.email@test.net",
                Login = "exampletestlogin"
            })
        }
    }
}