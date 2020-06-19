using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public class BuildingQueryService : IBuildingQueryService
    {
        protected internal readonly AdvertContext _context;

        public BuildingQueryService(AdvertContext context)
        {
            _context = context;
        }

        public Task<ICollection<Building>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Building> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
