using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Advert.Database.Entities;

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
