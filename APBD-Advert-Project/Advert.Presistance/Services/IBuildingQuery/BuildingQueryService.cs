using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public class BuildingQueryService : IBuildingQueryService
    {
        private readonly AdvertContext _context;

        public BuildingQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<Building> GetAsync(int id)
        {
            return await _context.Buildings.FirstOrDefaultAsync(b => b.IdBuilding == id);
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _context.Buildings.ToArrayAsync();
        }

        public async Task<IEnumerable<Building>> GetAllAsync(string city)
        {
            return await _context.Buildings
                .Where(b => b.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Building>> GetAllAsync(string city, string street)
        {
            return await _context.Buildings
                .Where(b => b.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.Street.Equals(street, StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.StreetNumber)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd)
        {
            return await _context.Buildings
                .Where(b => b.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.Street.Equals(street, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.StreetNumber >= streetNumberStart && b.StreetNumber <= streetNumberEnd)
                .OrderBy(b => b.StreetNumber)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd, bool even)
        {
            return await _context.Buildings
                .Where(b => b.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.Street.Equals(street, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.StreetNumber >= streetNumberStart && b.StreetNumber <= streetNumberEnd)
                .Where(b => b.StreetNumber % 2 == 0 == even)
                .OrderBy(b => b.StreetNumber)
                .ToArrayAsync();
        }
    }
}