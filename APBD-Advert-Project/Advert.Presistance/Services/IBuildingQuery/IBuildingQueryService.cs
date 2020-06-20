using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public interface IBuildingQueryService
    {
        public Task<Building> GetAsync(int id);

        public IEnumerable<Building> GetAll(string city, string street, int? streetNumberStart,
            int? streetNumberEnd, bool? even);
    }
}