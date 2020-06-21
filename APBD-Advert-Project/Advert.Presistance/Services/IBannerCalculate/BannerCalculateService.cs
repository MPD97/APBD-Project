using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
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

        public async Task<CampaignCreateResponseModel> Calculate(List<Building> buildings,
            decimal pricePerSquareMeter = 35)
        {
            var response = new CampaignCreateResponseModel();
            var firstBuilding = buildings.First();
            var lasBuilding = buildings.Last();
            if (firstBuilding.Height >= lasBuilding.Height)
            {
                response.Banner1 = new CampaignCreateResponseModel.Banner
                {
                    Width = _buildingWidth,
                    Height = firstBuilding.Height
                };
                response.Banner1.SquareMeters = response.Banner1.Width * response.Banner1.Height;
                response.Banner1.Price = response.Banner1.Width * response.Banner1.Height * pricePerSquareMeter;

                response.Banner2 = new CampaignCreateResponseModel.Banner
                {
                    Width = (buildings.Count() - 1) * _buildingWidth,
                    Height = lasBuilding.Height
                };
                response.Banner2.SquareMeters = response.Banner2.Width * response.Banner2.Height;
                response.Banner2.Price = response.Banner2.Width * response.Banner2.Height * pricePerSquareMeter;
            }
            else
            {
                response.Banner1 = new CampaignCreateResponseModel.Banner
                {
                    Width = (buildings.Count() - 1) * _buildingWidth,
                    Height = firstBuilding.Height
                };
                response.Banner1.SquareMeters = response.Banner1.Width * response.Banner1.Height;
                response.Banner1.Price = response.Banner1.Width * response.Banner1.Height * pricePerSquareMeter;

                response.Banner2 = new CampaignCreateResponseModel.Banner
                {
                    Width = _buildingWidth,
                    Height = lasBuilding.Height
                };
                response.Banner2.SquareMeters = response.Banner2.Width * response.Banner2.Height;
                response.Banner2.Price = response.Banner2.Width * response.Banner2.Height * pricePerSquareMeter;
            }

            response.TotalSquareMeters = response.Banner1.SquareMeters + response.Banner2.SquareMeters;
            response.PricePerSquareMeter = pricePerSquareMeter;
            response.TotalPrice = response.TotalSquareMeters * response.PricePerSquareMeter;

            return response;
        }
    }
}