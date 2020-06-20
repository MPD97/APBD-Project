using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBuildingQuery;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public class BannerCalculateService :IBannerCalculateService
    {
        private readonly IBuildingQueryService _buildingQueryService;

        public BannerCalculateService(IBuildingQueryService buildingQueryService)
        {
            _buildingQueryService = buildingQueryService;
        }

        public Task<ICollection<Banner>> Calculate(CampaignCreateRequestModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}