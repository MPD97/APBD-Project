using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services.IBuildingQuery;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public class BannerCalculateService : IBannerCalculateService
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly int _buildingWidth = 1;

        public BannerCalculateService(IBuildingQueryService buildingQueryService)
        {
            _buildingQueryService = buildingQueryService;
        }

        public async Task<CampaignCreateResponseModel> Calculate(CampaignCreateRequestModel model)
        {
            // TODO: Refactor this method to achieve SRP

            var fromBuilding = await _buildingQueryService.GetAsync(model.FromIdBuilding);
            var toBuilding = await _buildingQueryService.GetAsync(model.ToIdBuilidng);

            if (fromBuilding.City != toBuilding.City) return null; // City must be the same.

            if (fromBuilding.Street != toBuilding.Street) return null; // Street must be the same.

            if (fromBuilding.StreetNumber % toBuilding.StreetNumber != 0)
                return null; // Cant place banner across the road.

            if (fromBuilding.StreetNumber > toBuilding.StreetNumber)
                return null; // FromCity street number must be befeore toCity street number 

            if (fromBuilding.StreetNumber == toBuilding.StreetNumber) return null; // Buildings must be different

            var allBuildings = _buildingQueryService.GetAll(fromBuilding.City,
                fromBuilding.Street, fromBuilding.StreetNumber,
                toBuilding.StreetNumber, toBuilding.StreetNumber % 2 == 0).ToList();

            var response = new CampaignCreateResponseModel();
            var firstBuilding = allBuildings.First();
            var lasBuilding = allBuildings.Last();
            if (firstBuilding.Height >= lasBuilding.Height)
            {
                response.Banner1 = new CampaignCreateResponseModel.Banner
                {
                    Width = _buildingWidth,
                    Height = firstBuilding.Height
                };
                response.Banner1.SquareMeters = response.Banner1.Width * response.Banner1.Height;

                response.Banner2 = new CampaignCreateResponseModel.Banner
                {
                    Width = (allBuildings.Count() - 1) * _buildingWidth,
                    Height = lasBuilding.Height
                };
                response.Banner2.SquareMeters = response.Banner2.Width * response.Banner2.Height;
            }
            else
            {
                response.Banner1 = new CampaignCreateResponseModel.Banner
                {
                    Width = (allBuildings.Count() - 1) * _buildingWidth,
                    Height = firstBuilding.Height
                };
                response.Banner1.SquareMeters = response.Banner1.Width * response.Banner1.Height;

                response.Banner2 = new CampaignCreateResponseModel.Banner
                {
                    Width = _buildingWidth,
                    Height = lasBuilding.Height
                };
                response.Banner2.SquareMeters = response.Banner2.Width * response.Banner2.Height;
            }

            response.TotalSquareMeters = response.Banner1.SquareMeters + response.Banner2.SquareMeters;
            response.PricePerSquareMeter = model.PricePerSquareMeter;
            response.TotalPrice = response.TotalSquareMeters * response.PricePerSquareMeter;

            return response;
        }
    }
}