using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IRepository
{
    public interface IBannerRepository
    {
        IEnumerable<Banner> GetAll();
        Task<Banner> FindByIdAsync(int id);
        Task Insert(Banner banner);
        Task Insert(IEnumerable<Banner> banners);
        Task<bool> Delete(int id);
        void Update(Banner banner);
        Task<int> SaveAsync();
    }
}