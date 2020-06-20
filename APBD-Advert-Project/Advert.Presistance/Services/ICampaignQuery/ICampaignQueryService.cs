using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.ICampaignQuery
{
    public interface ICampaignQueryService
    {
        public Task<Campaign> GetAsync(int id);

        public Task<IEnumerable<Campaign>> GetAllAsync();
    }
}
