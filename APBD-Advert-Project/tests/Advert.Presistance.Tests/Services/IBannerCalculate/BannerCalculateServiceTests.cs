using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBannerCalculate;
using FluentAssertions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IBannerCalculate
{
    public class BannerCalculateServiceTests
    {
        public BannerCalculateServiceTests()
        {
            _sut = new BannerCalculateService();
        }

        private readonly BannerCalculateService _sut;

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2Price_WhenThereIsOnlyThreeBannersAndFirstIsLower()
        {
            var pricePerSquareMeter = 10.5M;
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10.5M
                },
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 20.5M
                }
            };
            var result = await _sut.CalculateAsync(input, pricePerSquareMeter);

            result.Should().NotBeNull();
            result.Banner1.Price.Should().BeApproximately(10.5M * 2 * pricePerSquareMeter, 0.01M);
            result.Banner2.Price.Should().BeApproximately(20.5M * pricePerSquareMeter, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2Price_WhenThereIsOnlyThreeBannersAndLastIsLower()
        {
            var pricePerSquareMeter = 10.5M;
            var input = new List<Building>
            {
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 10.5M
                }
            };
            var result = await _sut.CalculateAsync(input, pricePerSquareMeter);

            result.Should().NotBeNull();
            result.Banner1.Price.Should().BeApproximately(20.5M * pricePerSquareMeter, 0.01M);
            result.Banner2.Price.Should().BeApproximately(10.5M * 2 * pricePerSquareMeter, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2Price_WhenThereIsOnlyTwoBanners()
        {
            var pricePerSquareMeter = 10.5M;
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10.5M
                },
                new Building
                {
                    Height = 20.5M
                }
            };
            var result = await _sut.CalculateAsync(input, pricePerSquareMeter);

            result.Should().NotBeNull();
            result.Banner1.Price.Should().BeApproximately(10.5M * pricePerSquareMeter, 0.01M);
            result.Banner2.Price.Should().BeApproximately(20.5M * pricePerSquareMeter, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2SquareMeters_WhenThereIsOnlyThreeBannersAndFirstIsSmaller()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10.5M
                },
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 20.5M
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.SquareMeters.Should().BeApproximately(21.0M, 0.01M);
            result.Banner2.SquareMeters.Should().BeApproximately(20.5M, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2SquareMeters_WhenThereIsOnlyThreeBannersAndLastIsSmaller()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 20.5M
                },
                new Building
                {
                    Height = 10.5M
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.SquareMeters.Should().BeApproximately(20.5M, 0.01M);
            result.Banner2.SquareMeters.Should().BeApproximately(21.0M, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBanner1And2SquareMeters_WhenThereIsOnlyTwoBanners()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10.5M
                },
                new Building
                {
                    Height = 20.5M
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.SquareMeters.Should().BeApproximately(10.5M, 0.01M);
            result.Banner2.SquareMeters.Should().BeApproximately(20.5M, 0.01M);
        }

        [Fact]
        public async Task Calculate_ShouldReturnNotNullBanner1And2_WhenInputIsThreeLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.Should().NotBeNull();
            result.Banner2.Should().NotBeNull();
        }

        [Fact]
        public async Task Calculate_ShouldReturnNotNullBanner1And2_WhenInputIsTwoLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.Should().NotBeNull();
            result.Banner2.Should().NotBeNull();
        }

        [Fact]
        public async Task Calculate_ShouldReturnNull_WhenInputIsNull()
        {
            List<Building> input = null;

            var result = await _sut.CalculateAsync(input);

            result.Should().BeNull();
        }

        [Fact]
        public async Task Calculate_ShouldReturnNull_WhenInputIsOneLength()
        {
            var input = new List<Building> {new Building()};

            var result = await _sut.CalculateAsync(input);

            result.Should().BeNull();
        }

        [Fact]
        public async Task Calculate_ShouldReturnNull_WhenInputIsZeroLength()
        {
            var input = new List<Building>();

            var result = await _sut.CalculateAsync(input);

            result.Should().BeNull();
        }

        [Fact]
        public async Task Calculate_ShouldReturnPricePerSquareMeter_WhenInputIsCorrect()
        {
            var input = new List<Building>
            {
                new Building(),
                new Building()
            };
            var result = await _sut.CalculateAsync(input, 10);

            result.Should().NotBeNull();
            result.PricePerSquareMeter.Should().Be(10);
        }

        [Fact]
        public async Task Calculate_ShouldReturnSameWidth_WhenThereIsOnlyTwoBanners()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.Width.Should().Be(result.Banner2.Width);
        }

        [Fact]
        public async Task Calculate_ShouldReturnTotalPrice_WhenInputIsThreeLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input, 10);

            result.Should().NotBeNull();
            result.TotalPrice.Should().Be(300);
        }

        [Fact]
        public async Task Calculate_ShouldReturnTotalPrice_WhenInputIsTwoLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input, 10);

            result.Should().NotBeNull();
            result.TotalPrice.Should().Be(200);
        }

        [Fact]
        public async Task Calculate_ShouldReturnTotalSquareMeters_WhenInputIsThreeLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.TotalSquareMeters.Should().Be(30);
        }

        [Fact]
        public async Task Calculate_ShouldReturnTotalSquareMeters_WhenInputIsTwoLength()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.TotalSquareMeters.Should().Be(20);
        }

        [Fact]
        public async Task Calculate_ShouldReturnWiderBanner1_WhenFirstOfThreeBuildingsIsLowerThanLast()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 20
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner1.Width.Should().BeGreaterThan(result.Banner2.Width);
        }

        [Fact]
        public async Task Calculate_ShouldReturnWiderBanner2_WhenFirstOfThreeBuildingsIsHigherThanLast()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 20
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 10
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner2.Width.Should().BeGreaterThan(result.Banner1.Width);
        }

        [Fact]
        public async Task Calculate_ShouldReturnWiderBanner2_WhenFirstOfThreeBuildingsIsSameHeightThanLast()
        {
            var input = new List<Building>
            {
                new Building
                {
                    Height = 20
                },
                new Building
                {
                    Height = 10
                },
                new Building
                {
                    Height = 20
                }
            };
            var result = await _sut.CalculateAsync(input);

            result.Should().NotBeNull();
            result.Banner2.Width.Should().BeGreaterThan(result.Banner1.Width);
        }
    }
}