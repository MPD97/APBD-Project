using System;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.IRepository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IBuildingQuery
{
    public class BuildingQueryServiceTests
    {
        public BuildingQueryServiceTests()
        {
            _sut = new BuildingQueryService(_buildingRepository);
        }

        private readonly BuildingQueryService _sut;
        private readonly IBuildingRepository _buildingRepository = Substitute.For<IBuildingRepository>();

        private static Building[] SeedBuildings()
        {
            return new[]
            {
                new Building
                {
                    IdBuilding = 1,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 33.6M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 2,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 22.2M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 3,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 52.3M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 4,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 23M,
                    StreetNumber = 4
                },
                new Building
                {
                    IdBuilding = 5,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 13.5M,
                    StreetNumber = 5
                },
                new Building
                {
                    IdBuilding = 6,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 9.9M,
                    StreetNumber = 6
                },
                new Building
                {
                    IdBuilding = 7,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 23.5M,
                    StreetNumber = 7
                },
                new Building
                {
                    IdBuilding = 8,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 30.8M,
                    StreetNumber = 8
                },
                new Building
                {
                    IdBuilding = 9,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 62.6M,
                    StreetNumber = 9
                },
                new Building
                {
                    IdBuilding = 10,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 14.6M,
                    StreetNumber = 10
                },
                new Building
                {
                    IdBuilding = 11,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 36.7M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 12,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 22.7M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 13,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 15.5M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 14,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 13.9M,
                    StreetNumber = 4
                },
                new Building
                {
                    IdBuilding = 15,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 19.0M,
                    StreetNumber = 5
                },
                new Building
                {
                    IdBuilding = 16,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 64.3M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 17,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 34.3M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 18,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 54.0M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 19,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 22.2M,
                    StreetNumber = 4
                },
                new Building
                {
                    IdBuilding = 20,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 11.0M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 21,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 12.0M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 22,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 11.0M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 23,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 19.7M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 24,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 26.7M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 25,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 23.7M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 26,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 35.5M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 27,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 15.5M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 28,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 5.5M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 29,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 4.5M,
                    StreetNumber = 4
                },
                new Building
                {
                    IdBuilding = 30,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 13.2M,
                    StreetNumber = 5
                },
                new Building
                {
                    IdBuilding = 31,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 12.5M,
                    StreetNumber = 6
                },
                new Building
                {
                    IdBuilding = 32,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 15.1M,
                    StreetNumber = 7
                },
                new Building
                {
                    IdBuilding = 33,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 22.5M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 34,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 25.5M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 35,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 27.5M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 36,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 18.0M,
                    StreetNumber = 4
                },
                new Building
                {
                    IdBuilding = 37,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 22.5M,
                    StreetNumber = 5
                },
                new Building
                {
                    IdBuilding = 38,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 11.5M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 39,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 12.5M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 40,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 6.5M,
                    StreetNumber = 3
                }
            };
        }

        [Fact]
        public async Task FindAsync_ShouldReturnBuilding_WhenBuildingIsFound()
        {
            // Arrange
            var buildingId = 1;
            var buildingToFind = new Building {IdBuilding = buildingId};
            _buildingRepository.FindByIdAsync(buildingId).Returns(buildingToFind);

            // Act
            var building = await _sut.FindAsync(buildingId);

            // Assert
            building.Should().NotBeNull();
            building.Should().Be(buildingToFind);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnNull_WhenBuildingNotFound()
        {
            // Arrange
            var buildingId = 1;
            _buildingRepository.FindByIdAsync(Arg.Any<int>()).ReturnsNull();

            // Act
            var building = await _sut.FindAsync(buildingId);

            // Assert
            building.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllBuildings_WhenThereAreAllParametersPassed()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);

            var city = "warszawa";
            var street = "afrodyty";
            var startSN = 2;
            var endSN = 7;
            var even = false;

            var buildingsWithFilters = buildingsData.Count(a =>
                string.Equals(a.City, city, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(a.Street, street, StringComparison.OrdinalIgnoreCase) &&
                a.StreetNumber >= startSN &&
                a.StreetNumber <= endSN &&
                a.StreetNumber % 2 == 0 == even);

            // Act
            var buildings = _sut.GetAll(city, street, startSN, endSN, even).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().HaveCount(buildingsWithFilters);
            buildings.Should().Match(b => b.All(a => string.Equals(a.City, city, StringComparison.OrdinalIgnoreCase)));
            buildings.Should().Match(b =>
                b.All(a => string.Equals(a.Street, street, StringComparison.OrdinalIgnoreCase)));
            buildings.Should().Match(b => b.All(a => a.StreetNumber >= startSN));
            buildings.Should().Match(b => b.All(a => a.StreetNumber <= endSN));
            buildings.Should().Match(b => b.All(a => a.StreetNumber % 2 == 0 == even));
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllBuildingsInSameCity_WhenThereIsCity()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var city = "Warszawa";
            var buildingsWithWarsawCity =
                buildingsData.Count(a => string.Equals(a.City, city, StringComparison.OrdinalIgnoreCase));

            // Act
            var buildings = _sut.GetAll(city).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => string.Equals(a.City, city, StringComparison.OrdinalIgnoreCase)));
            buildings.Should().HaveCount(buildingsWithWarsawCity);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllBuildingsInSameStreet_WhenThereIsStreet()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var street = "afrodyty";
            var buildingsWithWarsawCity =
                buildingsData.Count(a => string.Equals(a.Street, street, StringComparison.OrdinalIgnoreCase));

            // Act
            var buildings = _sut.GetAll(street: street).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b =>
                b.All(a => string.Equals(a.Street, street, StringComparison.OrdinalIgnoreCase)));
            buildings.Should().HaveCount(buildingsWithWarsawCity);
        }

        [Fact]
        public async Task GetAll_ShouldReturnBeetwenOrEqualsStreetNumbers_WhenThereIsStartAndEndStreetNumber()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var startSN = 3;
            var endSN = 3;

            // Act
            var buildings = _sut.GetAll(streetNumberStart: startSN, streetNumberEnd: endSN).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => a.StreetNumber >= startSN && a.StreetNumber <= endSN));
        }

        [Fact]
        public async Task GetAll_ShouldReturnBiggerOrEqualStreetNumbers_WhenThereIsStartStreetNumber()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var startSN = 3;

            // Act
            var buildings = _sut.GetAll(streetNumberStart: startSN).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => a.StreetNumber >= startSN));
        }

        [Fact]
        public async Task GetAll_ShouldReturnBuildingsMaxAmountOfElements_WhenThereAreBuildings()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);

            // Act
            var buildings = _sut.GetAll().ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Count().Should().Be(buildingsData.Length);
        }

        [Fact]
        public async Task GetAll_ShouldReturnBuildingsOrderByStreetNumber_WhenThereAreBuildings()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);

            // Act
            var buildings = _sut.GetAll().ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Count().Should().Be(buildingsData.Length);
            buildings.Should().BeInAscendingOrder(a => a.StreetNumber);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEvenStreetNumbers_WhenThereAreBuildings()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var ShouldBeEven = true;

            // Act
            var buildings = _sut.GetAll(even: ShouldBeEven).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => a.StreetNumber % 2 == 0 == ShouldBeEven));
        }

        [Fact]
        public async Task GetAll_ShouldReturnOddStreetNumbers_WhenThereAreBuildings()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var ShouldBeEven = false;

            // Act
            var buildings = _sut.GetAll(even: ShouldBeEven).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => a.StreetNumber % 2 == 0 == ShouldBeEven));
        }

        [Fact]
        public async Task GetAll_ShouldReturnSmallerOrEqualStreetNumbers_WhenThereIsEndStreetNumber()
        {
            // Arrange
            var buildingsData = SeedBuildings();
            _buildingRepository.GetAll().Returns(buildingsData);
            var endStreetN = 3;

            // Act
            var buildings = _sut.GetAll(streetNumberEnd: endStreetN).ToList();

            // Assert
            buildings.Should().NotBeNull();
            buildings.Should().Match(b => b.All(a => a.StreetNumber <= endStreetN));
        }
    }
}