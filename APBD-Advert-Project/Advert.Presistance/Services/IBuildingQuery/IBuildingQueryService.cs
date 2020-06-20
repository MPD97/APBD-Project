using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public interface IBuildingQueryService
    {
        public Task<Building> GetAsync(int id);

        public Task<IEnumerable<Building>> GetAllAsync();
        public Task<IEnumerable<Building>> GetAllAsync(string city);
        public Task<IEnumerable<Building>> GetAllAsync(string city, string street);

        public Task<IEnumerable<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd);

        public Task<IEnumerable<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd, bool even);
    }
}