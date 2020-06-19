using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Queries
{
    public class CampaignGetQuery : IRequest<CampaignResponseModel>
    {
        public CampaignGetQuery(int campaignId)
        {
            CampaignId = campaignId;
        }

        public int CampaignId { get; internal set; }
    }
}
