using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class CampaignGetAllQuery : IRequest<IEnumerable<CampaignResponseModel>>
    {
    }
}