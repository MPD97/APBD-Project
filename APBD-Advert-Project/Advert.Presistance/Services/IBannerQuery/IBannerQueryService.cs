using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerQuery
{
    public interface IBannerQueryService
    {
        public Task<Banner> GetAsync(int id);
        public Task<ICollection<Banner>> GetAllAsync(int id);
    }
}