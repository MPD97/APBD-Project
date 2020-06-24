using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.IRepository
{
    public class BuildingsRepository : IBuildingsRepository
    {
        private readonly AdvertContext _context;

        public BuildingsRepository(AdvertContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings.AsEnumerable();
        }

        public async Task<Building> FindByIdAsync(int id)
        {
            return await _context.Buildings.SingleOrDefaultAsync(b => b.IdBuilding == id);
        }

        public async Task Insert(Building building)
        {
            await _context.Buildings.AddAsync(building);
        }

        public async Task Insert(IEnumerable<Building> buildings)
        {
            await _context.Buildings.AddRangeAsync(buildings);
        }

        public async Task<bool> Delete(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null) return false;

            _context.Buildings.Remove(building);
            return true;
        }

        public void Update(Building building)
        {
            _context.Entry(building).State = EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}