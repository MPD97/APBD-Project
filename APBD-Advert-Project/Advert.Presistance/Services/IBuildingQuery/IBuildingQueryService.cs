using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBuildingQuery
{
    public interface IBuildingQueryService
    {
        public Task<Building> GetAsync(int id);

        public Task<ICollection<Building>> GetAllAsync();
        public Task<ICollection<Building>> GetAllAsync(string city);
        public Task<ICollection<Building>> GetAllAsync(string city, string street);

        public Task<ICollection<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd);

        public Task<ICollection<Building>> GetAllAsync(string city, string street, int streetNumberStart,
            int streetNumberEnd, bool even);
    }
}