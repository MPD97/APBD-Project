using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetAllQuery : IRequest<IEnumerable<BuildingResponseModel>>
    {
    }
}