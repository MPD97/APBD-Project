using Advert.Presistance.Services.IBannerCreate;
using Advert.Presistance.Services.IRepository;
using NSubstitute;

namespace Advert.Presistance.Tests.Services.IBannerCreate
{
    public class BannerCreateServiceTests
    {
        private readonly IBannerRepository _bannerRepository = Substitute.For<IBannerRepository>();
        private readonly BannerCreateService _sut;

        public BannerCreateServiceTests()
        {
            _sut = new BannerCreateService(_bannerRepository);
        }
    }
}