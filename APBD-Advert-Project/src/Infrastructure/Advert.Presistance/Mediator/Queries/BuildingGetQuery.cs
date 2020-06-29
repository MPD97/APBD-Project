using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetQuery : IRequest<IResponseModel<BuildingResponse>>
    {
        public BuildingGetQuery(int buildingId)
        {
            BuildingId = buildingId;
        }

        public int BuildingId { get; set; }
    }
}