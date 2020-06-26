using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class CampaignGetAllQuery : IRequest<IResponseModel<IEnumerable<CampaignResponse>>>
    {
    }
}