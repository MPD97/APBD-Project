using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class BuildingGetAllQuery : IRequest<IResponseModel>
    {
        public BuildingGetAllQuery(string city = null, string street = null, int? streetStartNumber = null,
            int? steetEndNumber = null, bool? even = null)
        {
            City = city;
            Street = street;
            StreetStartNumber = streetStartNumber;
            SteetEndNumber = steetEndNumber;
            Even = even;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public int? StreetStartNumber { get; set; }
        public int? SteetEndNumber { get; set; }
        public bool? Even { get; set; }
    }
}