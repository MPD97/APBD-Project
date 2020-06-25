using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBannerCreate;
using AutoMapper;

namespace Advert.Presistance.Services.ICampaignCreate
{
    public class CampaignCreateService : ICampaignCreateService
    {
        private readonly IBannerCreateService _bannerCreateService;
        private readonly AdvertContext _context;
        private readonly IMapper _mapper;

        public CampaignCreateService(IMapper mapper, AdvertContext context, IBannerCreateService bannerCreateService)
        {
            _mapper = mapper;
            _context = context;
            _bannerCreateService = bannerCreateService;
        }

        public async Task<Campaign> CreateAsync(CampaignCreateRequestModel model,
            CampaignCreateResponseModel calculation)
        {
            var campaign = _mapper.Map<Campaign>(model);

            await _context.Campaigns.AddAsync(campaign);
            if (await _context.SaveChangesAsync() == 0)
                // TODO: Log errors
                return null;
            var bannerModel1 = new Banner
            {
                IdCampaign = campaign.IdCampaign,
                Area = calculation.Banner1.SquareMeters,
                Name = 0,
                Price = calculation.Banner1.Price
            };
            var bannerModel2 = new Banner
            {
                IdCampaign = campaign.IdCampaign,
                Area = calculation.Banner2.SquareMeters,
                Name = 0,
                Price = calculation.Banner2.Price
            };

            var banner1 = await _bannerCreateService.Create(bannerModel1);
            var banner2 = await _bannerCreateService.Create(bannerModel2);

            if (banner1 == null || banner2 == null) return null;


            return campaign;
        }
    }
}