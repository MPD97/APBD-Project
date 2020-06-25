using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBannerQuery;
using Advert.Presistance.Services.IRepository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IBannerQuery
{
    public class BannerQueryServiceTests
    {
        public BannerQueryServiceTests()
        {
            _sut = new BannerQueryService(_bannerRepository);
        }

        private readonly BannerQueryService _sut;
        private readonly IBannerRepository _bannerRepository = Substitute.For<IBannerRepository>();

        [Fact]
        public async Task FindAsync_ShouldReturnBnner_WhenBannerExistInDb()
        {
            var bannner = new Banner {IdAdvertisment = 1};
            _bannerRepository.FindByIdAsync(bannner.IdAdvertisment).Returns(bannner);

            var result = await _sut.FindAsync(bannner.IdAdvertisment);

            result.Should().NotBeNull();
            result.Should().Be(bannner);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnNull_WhenThereAreBannersButNotThatWeL4()
        {
            var bannner = new Banner {IdAdvertisment = 1};
            _bannerRepository.FindByIdAsync(bannner.IdAdvertisment).Returns(bannner);

            var result = await _sut.FindAsync(6);

            result.Should().BeNull();
        }

        [Fact]
        public async Task FindAsync_ShouldReturnNull_WhenThereIsNoBannersInDb()
        {
            _bannerRepository.FindByIdAsync(Arg.Any<int>()).ReturnsNull();

            var result = await _sut.FindAsync(6);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllBanners_WhenThereAreBannersInDb()
        {
            _bannerRepository.GetAll().Returns(new List<Banner> {new Banner(), new Banner()});

            var result = _sut.GetAll();

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnNull_WhenThereIsNoBannersInDb()
        {
            _bannerRepository.GetAll().ReturnsNull();

            var result = _sut.GetAll();

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnSameBannersLength_WhenThereAreBannersInDb()
        {
            var bannersInDb = new List<Banner> {new Banner(), new Banner()};
            _bannerRepository.GetAll().Returns(bannersInDb);

            var result = _sut.GetAll();

            var enumerable = result.ToList();
            enumerable.Should().NotBeNull();
            enumerable.Count().Should().Be(bannersInDb.Count);
        }
    }
}