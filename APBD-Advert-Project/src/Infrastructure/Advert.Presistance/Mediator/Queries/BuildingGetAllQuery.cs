using System.Collections.Generic;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetAllQuery : IRequest<IResponseModel<IEnumerable<BuildingResponse>>>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int? StreetStartNumber { get; set; }
        public int? StreetEndNumber { get; set; }
        public bool? Even { get; set; }
    }
}