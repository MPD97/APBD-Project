using Advert.Presistance.Services.ICampaignService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ICampaignQuery
{
    public class CampaignQueryService : ICampaignQueryService
    {
        protected internal readonly AdvertContext _context;

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
            return await _context.Campaigns.ToArrayAsync();
        }
    }
}
