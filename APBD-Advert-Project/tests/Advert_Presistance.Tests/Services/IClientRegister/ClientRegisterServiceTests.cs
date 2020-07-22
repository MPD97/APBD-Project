using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IClientRegister;
using Advert.Presistance.Services.IPasswordHasher;
using Advert.Presistance.Services.IRepository;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Advert.Presistance.Tests.Services.IClientRegister
{
    public class ClientRegisterServiceTests
    {
        public ClientRegisterServiceTests()
        {
            _sut = new ClientRegisterService(_clientRepository, _passwordHasher);
        }

        private readonly ClientRegisterService _sut;
        private readonly IPasswordHasherService _passwordHasher = Substitute.For<IPasswordHasherService>();
        private readonly IClientRepository _clientRepository = Substitute.For<IClientRepository>();

        [Fact]
        public async Task CreateAsync_ShouldReturnClient_WhenInputIsValid()
        {
            // Arrange
            _passwordHasher.CreateSalt().Returns("salt");
            _passwordHasher.Create(Arg.Any<string>(), Arg.Any<string>()).Returns("hash");
            _clientRepository.SaveAsync().Returns(1);

            // Act
            var client = await _sut.CreateAsync(new Client(), "password");

            // Assert
            client.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnGoodHash_WhenInputIsValid()
        {
            // Arrange
            var salt = "salt";
            var hash = "hash";
            _passwordHasher.CreateSalt().Returns(salt);
            _passwordHasher.Create(Arg.Any<string>(), Arg.Any<string>()).Returns(hash);
            _clientRepository.SaveAsync().Returns(1);

            // Act
            var client = await _sut.CreateAsync(new Client(), "password");

            // Assert
            client.Should().NotBeNull();
            client.Hash.Should().Be(hash);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnGoodSalt_WhenInputIsValid()
        {
            // Arrange
            var salt = "salt";
            _passwordHasher.CreateSalt().Returns(salt);
            _passwordHasher.Create(Arg.Any<string>(), Arg.Any<string>()).Returns("hash");
            _clientRepository.SaveAsync().Returns(1);

            // Act
            var client = await _sut.CreateAsync(new Client(), "password");

            // Assert
            client.Should().NotBeNull();
            client.Salt.Should().Be(salt);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnNull_WhenInputClientIsNull()
        {
            // Arrange
            _passwordHasher.CreateSalt().Returns("salt");
            _passwordHasher.Create(Arg.Any<string>(), Arg.Any<string>()).Returns("hash");
            _clientRepository.SaveAsync().Returns(1);

            // Act
            var client = await _sut.CreateAsync(null, "password");

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnNull_WhenSaveAsyncReturnsZero()
        {
            // Arrange
            _passwordHasher.CreateSalt().Returns("salt");
            _passwordHasher.Create(Arg.Any<string>(), Arg.Any<string>()).Returns("hash");
            _clientRepository.SaveAsync().Returns(0);

            // Act
            var client = await _sut.CreateAsync(new Client(), "password");

            // Assert
            client.Should().BeNull();
        }
    }
}