using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;

namespace Advert.Presistance.Services.IBannerCalculate
{
    public interface IBannerCalculateService
    {
        public Task<CampaignCreateResponseModel> Calculate(CampaignCreateRequestModel model);
    }
}