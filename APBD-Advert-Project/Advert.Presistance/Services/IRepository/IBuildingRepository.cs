using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IRepository
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetAll();
        Task<Building> FindByIdAsync(int id);
        Task Insert(Building building);
        Task Insert(IEnumerable<Building> buildings);
        Task<bool> Delete(int id);
        void Update(Building building);
        Task<int> SaveAsync();
    }
}