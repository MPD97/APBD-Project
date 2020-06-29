using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerCreate
{
    public interface IBannerCreateService
    {
        public Task<Banner> Create(Banner banner);
    }
}