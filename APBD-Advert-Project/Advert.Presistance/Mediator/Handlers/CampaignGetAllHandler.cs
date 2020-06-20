﻿using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.ICampaignQuery;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignGetAllHandler : IRequestHandler<CampaignGetAllQuery, IEnumerable<CampaignResponseModel>>
    {
        private readonly ICampaignQueryService _campaignQueryService;
        private readonly IMapper _mapper;

        public CampaignGetAllHandler(ICampaignQueryService campaignQueryService, IMapper mapper)
        {
            _campaignQueryService = campaignQueryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CampaignResponseModel>> Handle(CampaignGetAllQuery request, CancellationToken cancellationToken)
        {
            var campaigns = await _campaignQueryService.GetAllAsync();
            if (campaigns == null)
            {
                return null;
            }
            var result = campaigns.Select(_mapper.Map<Campaign, CampaignResponseModel>);
            return result;
        }
    }
}
