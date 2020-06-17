using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ICampaignService
{
    public interface ICampaignQueryService
    {
        public Task<Campaign> Get(int id);

        public Task<IEnumerable<Campaign>> GetAll();
    }
}
