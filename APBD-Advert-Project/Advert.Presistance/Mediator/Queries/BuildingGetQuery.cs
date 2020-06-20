using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetQuery : IRequest<BuildingResponseModel>, IRequest<IEnumerable<BuildingResponseModel>>
    {
        public BuildingGetQuery(int buildingId)
        {
            BuildingId = buildingId;
        }

        public int BuildingId { get; set; }
    }
}