using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public interface IBannerCalculateService
    {
        public Task<ICollection<Banner>> Calculate(CampaignCreateRequestModel model);
    }
}