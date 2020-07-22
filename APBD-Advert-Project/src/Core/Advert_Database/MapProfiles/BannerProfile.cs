using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;
using AutoMapper;

namespace Advert.Database.MapProfiles
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<BannerCreateRequest, Banner>();
        }
    }
}