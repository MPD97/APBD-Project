using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public interface IBannerCalculateService
    {
        public Task<CampaignCreateResponseModel> CalculateAsync(List<Building> buildings,
            decimal pricePerSquareMeter = 35);
    }
}