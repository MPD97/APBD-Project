using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerCreate
{
    public interface IBannerCreateService
    {
        public Task<Banner> Create(BannerCreateRequestModel model);
    }
}