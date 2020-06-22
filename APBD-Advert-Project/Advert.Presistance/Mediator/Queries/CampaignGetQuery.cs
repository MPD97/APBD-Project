using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class CampaignGetQuery : IRequest<IResponseModel>
    {
        public CampaignGetQuery(int campaignId)
        {
            CampaignId = campaignId;
        }

        public int CampaignId { get; internal set; }
    }
}