using Advert.Database.DTOs.Responses;
using MediatR;

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