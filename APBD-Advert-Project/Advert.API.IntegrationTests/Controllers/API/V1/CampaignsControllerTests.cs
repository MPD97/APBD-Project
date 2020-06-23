using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Presistance.Mediator.Commands;
using FluentAssertions;
using Xunit;

namespace Advert.IntegrationTests.Controllers.API.V1
{
    public class CampaignsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Create_ShouldReturnAccessDenied_WhenNotAuthorized()
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Campaigns.Create, new CampaignCreateCommand
            {
                PricePerSquareMeter = 35,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                IdClient = 1,
                FromIdBuilding = 1,
                ToIdBuilding = 3
            });

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Get_ShouldReturnAccessDenied_WhenNotAuthorized()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Campaigns.Get.Replace("{id:int}", "150"));

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAccessDenied_WhenNotAuthorized()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Campaigns.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}