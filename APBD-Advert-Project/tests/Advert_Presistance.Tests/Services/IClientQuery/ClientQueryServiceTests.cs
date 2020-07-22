using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IClientQuery;
using Advert.Presistance.Services.IRepository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IClientQuery
{
    public class ClientQueryServiceTests
    {
        public ClientQueryServiceTests()
        {
            _sut = new ClientQueryService(_clientRepository);
        }

        private readonly ClientQueryService _sut;
        private readonly IClientRepository _clientRepository = Substitute.For<IClientRepository>();

        [Fact]
        public async Task FindAsync_ShouldReturnClient_WhenClientWithThisIdExists()
        {
            // Arrange
            var clientInDb = new Client {IdClient = 5};
            _clientRepository.FindByIdAsync(5).Returns(clientInDb);

            // Act
            var client = await _sut.FindAsync(5);

            // Assert
            client.Should().Be(clientInDb);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _clientRepository.FindByIdAsync(Arg.Any<int>()).ReturnsNull();

            // Act
            var client = await _sut.FindAsync(5);

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public async Task FindByEmailAsync_ShouldReturnClient_WhenClientWithThisEmailExists()
        {
            // Arrange
            var clientInDb = new Client {Email = "example@example.com"};
            _clientRepository.FindByEmailAsync("example@example.com").Returns(clientInDb);

            // Act
            var client = await _sut.FindByEmailAsync("example@example.com");

            // Assert
            client.Should().Be(clientInDb);
        }

        [Fact]
        public async Task FindByEmailAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _clientRepository.FindByEmailAsync(Arg.Any<string>()).ReturnsNull();

            // Act
            var client = await _sut.FindByEmailAsync("example@example.com");

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public async Task FindByLoginAsync_ShouldReturnClient_WhenClientWithThisLoginExists()
        {
            // Arrange
            var clientInDb = new Client {Login = "examplelogin"};
            _clientRepository.FindByLoginAsync("examplelogin").Returns(clientInDb);

            // Act
            var client = await _sut.FindByLoginAsync("examplelogin");

            // Assert
            client.Should().Be(clientInDb);
        }

        [Fact]
        public async Task FindByLoginAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _clientRepository.FindByLoginAsync(Arg.Any<string>()).ReturnsNull();

            // Act
            var client = await _sut.FindByLoginAsync("examplelogin");

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmptyArray_WhenThereIsNoClientsInDb()
        {
            // Arrange
            _clientRepository.GetAll().ReturnsNull();

            // Act
            var clients = _sut.GetAll();

            // Assert
            clients.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ShouldReturnSameArrayLength_WhenThereAreClientsInDb()
        {
            // Arrange
            var clientsIndDb = new List<Client>
            {
                new Client(), new Client(), new Client(), new Client(), new Client()
            };
            _clientRepository.GetAll().Returns(clientsIndDb);

            // Act
            var clients = _sut.GetAll().ToList();

            // Assert
            clients.Should().NotBeNull();
            clients.Count.Should().Be(clientsIndDb.Count);
        }
    }
}