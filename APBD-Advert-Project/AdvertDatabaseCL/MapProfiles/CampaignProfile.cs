using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.MapProfiles
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignResponseModel>();
            CreateMap<CampaignResponseModel, Campaign>();
        }
    }
}
