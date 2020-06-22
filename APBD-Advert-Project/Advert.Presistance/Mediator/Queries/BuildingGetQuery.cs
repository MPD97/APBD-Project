using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetQuery : IRequest<IResponseModel>
    {
        public BuildingGetQuery(int buildingId)
        {
            BuildingId = buildingId;
        }

        public int BuildingId { get; set; }
    }
}