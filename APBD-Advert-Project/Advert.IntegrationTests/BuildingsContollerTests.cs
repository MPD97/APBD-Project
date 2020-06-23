using System.Net;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using FluentAssertions;
using Xunit;

namespace Advert.IntegrationTests
{
    public class BuildingsContollerTests : IntegrationTest
    {
        [Fact]
        public async Task GetALL_ShoultReturnStatusCode200_WhenNotAuthenticated()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Buildings.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}