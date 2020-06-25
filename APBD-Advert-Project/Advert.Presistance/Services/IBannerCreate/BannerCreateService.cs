using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;
using Advert.Presistance.Services.IRepository;
using AutoMapper;

namespace Advert.Presistance.Services.IBannerCreate
{
    public class BannerCreateService : IBannerCreateService
    {
        private readonly IMapper _mapper;
        private readonly IBannerRepository _repository;

        public BannerCreateService(IBannerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Banner> Create(BannerCreateRequestModel model)
        {
            var banner = _mapper.Map<Banner>(model);
            await _repository.Insert(banner);

            if (await _repository.SaveAsync() == 0) return null;

            return banner;
        }
    }
}