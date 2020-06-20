using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.ICampaignQuery
{
    public class CampaignQueryService : ICampaignQueryService
    {
        private readonly AdvertContext _context;

        public CampaignQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<Campaign> GetAsync(int id)
        {
            return await _context.Campaigns.FirstOrDefaultAsync(client => client.IdClient == id);
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            return await _context.Campaigns.OrderByDescending(c => c.StartDate).ToArrayAsync();
        }
    }
}