using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public class BuildingQueryService : IBuildingQueryService
    {
        private readonly IBuildingsRepository _repository;

        public BuildingQueryService(IBuildingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Building> FindAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public IEnumerable<Building> GetAll(string city, string street, int? streetNumberStart,
            int? streetNumberEnd, bool? even)
        {
            var result = _repository.GetAll();
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