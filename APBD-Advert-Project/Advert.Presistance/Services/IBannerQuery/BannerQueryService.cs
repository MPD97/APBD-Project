using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IBannerQuery
{
    public class BannerQueryService : IBannerQueryService
    {
        private readonly IBannerRepository _repository;

        public BannerQueryService(IBannerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Banner> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Banner> FindAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }
    }
}