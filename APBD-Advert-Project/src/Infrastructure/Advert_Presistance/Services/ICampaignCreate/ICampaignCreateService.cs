using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.ICampaignCreate
{
    public interface ICampaignCreateService
    {
        public Task<Campaign> CreateAsync(CampaignCreateRequest model, CampaignCreateResponse calculation);
    }
}