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

        public IEnumerable<Building> GetAll(string city, string street, int? streetNumberStart,
            int? streetNumberEnd, bool? even)
        {
            IEnumerable<Building> result = _context.Buildings;
            if (city != null)
                result = result.Where(b => string.Equals(b.City, city, StringComparison.CurrentCultureIgnoreCase));

            if (street != null)
                result = result.Where(b => string.Equals(b.Street, street, StringComparison.CurrentCultureIgnoreCase));

            if (streetNumberStart.HasValue) result = result.Where(b => b.StreetNumber >= streetNumberStart);

            if (streetNumberEnd.HasValue) result = result.Where(b => b.StreetNumber <= streetNumberEnd);

            if (even.HasValue) result = result.Where(b => b.StreetNumber % 2 == 0 == even);

            return result.OrderBy(b => b.StreetNumber);
        }
    }
}