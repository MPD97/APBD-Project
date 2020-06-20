using Advert.Database.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.ICampaignCreate
{
    public interface ICampaignCreateService
    {
        public Task<Campaign> CreateAsync(CampaignCreateRequestModel model, CampaignCreateResponseModel.Banner[] banner);
    }
}
