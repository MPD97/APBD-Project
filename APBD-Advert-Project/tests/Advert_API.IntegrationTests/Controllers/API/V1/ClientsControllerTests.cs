using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using FluentAssertions;
using Xunit;

namespace Advert.IntegrationTests.Controllers.API.V1
{
    public class ClientsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Get_ShouldReturnNotFound_WhenClientNotExistById()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Clients.Get.Replace("{id:int}", "150"));

            var successResponse = await DeserializeObjectAsync<SuccessResponse<ClientResponse>>(response);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            successResponse.Should().NotBe(null);

            successResponse.Status.Should().Be(ResponseStatus.Error);
            successResponse.Message.Should().Be("No client could be found with this id");
            successResponse.Result.Should().Be(null);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNotFound_WhenThereIsNoDataInDatabase()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Clients.GetAll);

            var successResponse =
                await DeserializeObjectAsync<SuccessResponse<IEnumerable<ClientResponse>>>(response);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            successResponse.Should().NotBe(null);

            successResponse.Status.Should().Be(ResponseStatus.Error);
            successResponse.Message.Should().Be("No clients could be found");
            successResponse.Result.Should().BeNull();
        }
    }
}