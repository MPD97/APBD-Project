using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IBannerCreate
{
    public class BannerCreateService : IBannerCreateService
    {
        private readonly IBannerRepository _repository;

        public BannerCreateService(IBannerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Banner> Create(Banner banner)
        {
            await _repository.Insert(banner);

            if (await _repository.SaveAsync() == 0) return null;

            return banner;
        }
    }
}