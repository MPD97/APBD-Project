﻿using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using AutoMapper;

namespace Advert.Database.MapProfiles
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignResponseModel>();
            CreateMap<CampaignResponseModel, Campaign>();
            CreateMap<CampaignCreateRequestModel, Campaign>();
        }
    }
}