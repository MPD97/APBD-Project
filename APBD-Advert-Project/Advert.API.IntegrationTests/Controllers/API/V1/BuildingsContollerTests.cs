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
    public class BuildingsContollerTests : IntegrationTest
    {
        [Fact]
        public async Task Get_ShouldReturnNotFound_WhenBuildingByIdNotExists()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Buildings.Get.Replace("{id:int}", "150"));

            var successResponse = await DeserializeObjectAsync<SuccessResponse<BuildingResponse>>(response);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            successResponse.Should().NotBe(null);

            successResponse.Status.Should().Be(ResponseStatus.Error);
            successResponse.Message.Should().Be("No buildings could be found with this id");
            successResponse.Result.Should().Be(null);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNotFound_WhenThereIsNoDataInDatabase()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Buildings.GetAll);

            var successResponse =
                await DeserializeObjectAsync<SuccessResponse<IEnumerable<BuildingResponse>>>(response);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            successResponse.Should().NotBe(null);

            successResponse.Status.Should().Be(ResponseStatus.Error);
            successResponse.Message.Should().Be("No buildings could be found");
            successResponse.Result.Should().BeNull();
        }
    }
}