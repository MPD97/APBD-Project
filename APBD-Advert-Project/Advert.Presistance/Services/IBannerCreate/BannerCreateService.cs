using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.DTOs.Requests;
using Advert.Database.Entities;
using AutoMapper;

namespace Advert.Presistance.Services.IBannerCreate
{
    public class BannerCreateService : IBannerCreateService
    {
        private readonly AdvertContext _context;
        private readonly IMapper _mapper;

        public BannerCreateService(IMapper mapper, AdvertContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Banner> Create(BannerCreateRequestModel model)
        {
            var banner = _mapper.Map<Banner>(model);
            _context.Add((object) banner);

            if (await _context.SaveChangesAsync() == 0) return null;

            return banner;
        }
    }
}