using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Commands
{
    public class CampaignCreateCommand : CampaignCreateRequest,
        IRequest<IResponseModel<CampaignCreateResponse>>
    {
    }
}