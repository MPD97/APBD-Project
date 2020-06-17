using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.ICampaignService;
using AdvertDatabaseCL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignGetHandler : IRequestHandler<CampaignGetQuery, Campaign>
    {
        private readonly ICampaignQueryService _campaignQueryService;

        public CampaignGetHandler(ICampaignQueryService campaignQueryService)
        {
            _campaignQueryService = campaignQueryService;
        }

        public async Task<Campaign> Handle(CampaignGetQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _campaignQueryService.GetAsync(request.CampaignId);
            
            return campaign;
        }
    }
}
