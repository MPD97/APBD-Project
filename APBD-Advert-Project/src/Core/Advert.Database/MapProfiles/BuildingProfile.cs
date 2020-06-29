using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using AutoMapper;

namespace Advert.Database.MapProfiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingResponse>();
        }
    }
}