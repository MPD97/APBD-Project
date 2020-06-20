using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public class BuildingQueryService : IBuildingQueryService
    {
        private readonly AdvertContext _context;

        public BuildingQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Building>> GetAllAsync()
        {
            return await _context.Buildings.ToArrayAsync();
        }

        public async Task<Building> GetAsync(int id)
        {
            return await _context.Buildings.FirstOrDefaultAsync(b => b.IdBuilding == id);
        }
    }
}
