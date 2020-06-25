using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerQuery
{
    public interface IBannerQueryService
    {
        public Task<Banner> FindAsync(int id);
        public IEnumerable<Banner> GetAll(int id);
    }
}