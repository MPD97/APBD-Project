using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Services.IClientLogin;
using Advert.Presistance.Services.IJwtBearer;
using Advert.Presistance.Services.IPasswordHasher;
using Advert.Presistance.Services.IRepository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IClientLogin
{
    public class ClientLoginServiceTests
    {
        public ClientLoginServiceTests()
        {
            _sut = new ClientLoginService(_clientRepository, _jwtBearer, _passwordHasher);
        }

        private readonly ClientLoginService _sut;
        private readonly IJwtBearerService _jwtBearer = Substitute.For<IJwtBearerService>();
        private readonly IClientRepository _clientRepository = Substitute.For<IClientRepository>();
        private readonly IPasswordHasherService _passwordHasher = Substitute.For<IPasswordHasherService>();

        [Fact]
        public async Task LoginAsync_ShouldReturnJwtTokenResponse_WhenInputIsValid()
        {
            // Arrange
            var clientToLogin = new ClientLoginRequestModel
            {
                Login = "login",
                Password = "password"
            };
            var client = new Client();
            var jwtToken = new JwtTokenResponseModel {Token = "token", RefreshToken = "refreshToken"};

            _clientRepository.FindByLoginAsync(Arg.Any<string>()).Returns(client);
            _passwordHasher.Validate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);
            _jwtBearer.CreateToken(client).Returns(jwtToken);
            _clientRepository.SaveAsync().Returns(1);
            // Act
            var token = await _sut.LoginAsync(clientToLogin);

            // Assert
            token.Should().NotBeNull();
            token.Should().Be(jwtToken);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnNull_WhenClientNotFoundInDb()
        {
            // Arrange
            var clientToLogin = new ClientLoginRequestModel
            {
                Login = "login",
                Password = "password"
            };
            _clientRepository.FindByLoginAsync(Arg.Any<string>()).ReturnsNull();
            _passwordHasher.Validate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);

            // Act
            var token = await _sut.LoginAsync(clientToLogin);

            // Assert
            token.Should().BeNull();
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnNull_WhenPasswordIsNotValid()
        {
            // Arrange
            var clientToLogin = new ClientLoginRequestModel
            {
                Login = "login",
                Password = "password"
            };
            _clientRepository.FindByLoginAsync(Arg.Any<string>()).Returns(new Client());
            _passwordHasher.Validate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(false);

            // Act
            var token = await _sut.LoginAsync(clientToLogin);

            // Assert
            token.Should().BeNull();
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnNull_WhenSaveAsyncFails()
        {
            // Arrange
            var clientToLogin = new ClientLoginRequestModel
            {
                Login = "login",
                Password = "password"
            };
            var client = new Client();
            var jwtToken = new JwtTokenResponseModel {Token = "token", RefreshToken = "refreshToken"};

            _clientRepository.FindByLoginAsync(Arg.Any<string>()).Returns(client);
            _passwordHasher.Validate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);
            _jwtBearer.CreateToken(client).Returns(jwtToken);
            _clientRepository.SaveAsync().Returns(0);
            // Act
            var token = await _sut.LoginAsync(clientToLogin);

            // Assert
            token.Should().BeNull();
        }
    }
}