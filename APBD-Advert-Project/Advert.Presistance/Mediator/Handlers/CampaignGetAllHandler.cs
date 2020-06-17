﻿using Advert.Presistance.Mediator.Queries;
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
    public class CampaignGetAllHandler : IRequestHandler<CampaignGetAllQuery, IEnumerable<Campaign>>
    {
        private readonly ICampaignQueryService _campaignQueryService;

        public CampaignGetAllHandler(ICampaignQueryService campaignQueryService)
        {
            _campaignQueryService = campaignQueryService;
        }
        public async Task<IEnumerable<Campaign>> Handle(CampaignGetAllQuery request, CancellationToken cancellationToken)
        {
            var campaigns = await _campaignQueryService.GetAllAsync();

            return campaigns;
        }
    }
}