using System.Threading.Tasks;
using Advert.Presistance.Services.IPasswordHasher;
using FluentAssertions;
using Xunit;

namespace Advert.Presistance.Tests.Services.IPasswordHasher
{
    public class Pbkdf2PasswordHasherServiceTests
    {
        public Pbkdf2PasswordHasherServiceTests()
        {
            _sut = new Pbkdf2PasswordHasherService();
        }

        private readonly Pbkdf2PasswordHasherService _sut;

        [Fact]
        public async Task Create_ShouldCreateDifferentPasswords_WhenInputPasswordIsDifferent()
        {
            var passwordOne = "password1";
            var passwordTwo = "password2";
            var salt = _sut.CreateSalt();

            var hashOne = _sut.Create(passwordOne, salt);
            var hashTwo = _sut.Create(passwordTwo, salt);

            passwordOne.Should().NotBeSameAs(passwordTwo);
            hashOne.Should().NotBeNull();
            hashTwo.Should().NotBeNull();

            hashOne.Should().NotBeSameAs(hashTwo);
        }

        [Fact]
        public async Task Create_ShouldCreateDifferentPasswords_WhenInputSaltIsDifferent()
        {
            var password = "password";
            var saltOne = _sut.CreateSalt();
            var saltTwo = _sut.CreateSalt();

            var hashOne = _sut.Create(password, saltOne);
            var hashTwo = _sut.Create(password, saltTwo);

            saltOne.Should().NotBeSameAs(saltTwo);
            hashOne.Should().NotBeNull();
            hashTwo.Should().NotBeNull();

            hashOne.Should().NotBeSameAs(hashTwo);
        }

        [Fact]
        public async Task Create_ShouldCreateSamePasswords_WhenInputIsSame()
        {
            var password = "password";
            var salt = _sut.CreateSalt();

            var hashOne = _sut.Create(password, salt);
            var hashTwo = _sut.Create(password, salt);

            hashOne.Should().NotBeNull();
            hashTwo.Should().NotBeNull();

            hashOne.Should().Be(hashTwo);
        }

        [Fact]
        public async Task Create_ShouldCreateSamePasswordsLength_Always()
        {
            var passwordOne = "pass";
            var passwordTwo = "password123$^&*password";
            var saltOne = _sut.CreateSalt();
            var saltTwo = _sut.CreateSalt();

            var hashOne = _sut.Create(passwordOne, saltOne);
            var hashTwo = _sut.Create(passwordTwo, saltTwo);

            saltOne.Should().NotBeSameAs(saltTwo);
            hashOne.Should().NotBeNull();
            hashTwo.Should().NotBeNull();

            hashOne.Length.Should().Be(hashTwo.Length);
        }

        [Fact]
        public async Task CreateSalt_ShouldReturnDifferentSalts_Always()
        {
            var saltOne = _sut.CreateSalt();
            var saltTwo = _sut.CreateSalt();
            var saltThree = _sut.CreateSalt();

            saltOne.Should().NotBeSameAs(saltTwo).And.NotBeSameAs(saltThree);
            saltTwo.Should().NotBeSameAs(saltThree);
        }

        [Fact]
        public async Task CreateSalt_ShouldReturnNotNull_Always()
        {
            var salt = _sut.CreateSalt();

            salt.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateSalt_ShouldReturnSameSaltsLength_Always()
        {
            var saltOne = _sut.CreateSalt();
            var saltTwo = _sut.CreateSalt();
            var saltThree = _sut.CreateSalt();

            saltOne.Length.Should().Be(saltTwo.Length).And.Be(saltThree.Length);
            saltTwo.Length.Should().Be(saltThree.Length);
        }

        [Fact]
        public async Task Validate_ShouldReturnFalse_WhenHashIsDifferent()
        {
            var password = "password";
            var salt = _sut.CreateSalt();

            var hash = _sut.Create(password, salt);
            var result = _sut.Validate(password, salt, "differentHash");

            result.Should().Be(false);
        }

        [Fact]
        public async Task Validate_ShouldReturnFalse_WhenPasswordIsDifferent()
        {
            var password = "password";
            var salt = _sut.CreateSalt();

            var hash = _sut.Create(password, salt);
            var result = _sut.Validate("differentPassword", salt, hash);

            result.Should().Be(false);
        }

        [Fact]
        public async Task Validate_ShouldReturnFalse_WhenSaltIsDifferent()
        {
            var password = "password";
            var salt = _sut.CreateSalt();

            var hash = _sut.Create(password, salt);
            var result = _sut.Validate(password, _sut.CreateSalt(), hash);

            result.Should().Be(false);
        }

        [Fact]
        public async Task Validate_ShouldReturnTrue_WhenInputIsValid()
        {
            var password = "password";
            var salt = _sut.CreateSalt();

            var hash = _sut.Create(password, salt);
            var result = _sut.Validate(password, salt, hash);

            result.Should().Be(true);
        }
    }
}