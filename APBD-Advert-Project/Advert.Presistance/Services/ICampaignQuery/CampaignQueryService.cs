using Advert.Presistance.Services.ICampaignService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
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

        public Task<Campaign> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campaign>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
