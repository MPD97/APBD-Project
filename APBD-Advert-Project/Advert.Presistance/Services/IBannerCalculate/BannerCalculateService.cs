using System;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services.IBuildingQuery;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public class BannerCalculateService : IBannerCalculateService
    {
        private readonly IBuildingQueryService _buildingQueryService;

        public BannerCalculateService(IBuildingQueryService buildingQueryService)
        {
            _buildingQueryService = buildingQueryService;
        }

        public async Task<CampaignCreateResponseModel> Calculate(CampaignCreateRequestModel model)
        {
            var fromBuilding = await _buildingQueryService.GetAsync(model.FromIdBuilding);
            var toBuilding = await _buildingQueryService.GetAsync(model.ToIdBuilidng);

            if (fromBuilding.City != toBuilding.City) return null; // City must be the same.

            if (fromBuilding.Street != toBuilding.Street) return null; // Street must be the same.

            if (fromBuilding.StreetNumber % toBuilding.StreetNumber != 0)
                return null; // Cant place banner across the road.

            if (fromBuilding.StreetNumber == toBuilding.StreetNumber) return null; // Buildings must be different
            // TODO: Get buildings beetwen

            throw new NotImplementedException();
        }
    }
}