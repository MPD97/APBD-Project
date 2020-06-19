using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public interface IBuildingQueryService
    {
        public Task<Building> GetAsync(int id);

        public Task<ICollection<Building>> GetAllAsync();
    }
}
