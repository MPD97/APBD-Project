using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.ICampaignService;
using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ICampaignCreate
{
    public class CampaignCreateService : ICampaignCreateService
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly ICampaignQueryService _campaignQueryService;
        private readonly IClientQueryService _clientQueryService;

        public CampaignCreateService(IBuildingQueryService buildingQueryService, ICampaignQueryService campaignQueryService,
            IClientQueryService clientQueryService)
        {
            _buildingQueryService = buildingQueryService;
            _campaignQueryService = campaignQueryService;
            _clientQueryService = clientQueryService;
        }

        public Task<Campaign> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
