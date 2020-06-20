using Advert.Presistance.Services.IPasswordHasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advert.PresistanceTests.Services.IPasswordHasherService
{
    [TestClass]
    public class Pbkdf2PasswordHasherTests
    {
        private readonly Presistance.Services.IPasswordHasher.IPasswordHasherService _passwordHasher;

        public Pbkdf2PasswordHasherTests()
        {
            _passwordHasher = new Pbkdf2PasswordHasherService();
        }

        [TestMethod]
        public void Validate_ShouldResultTrue_WhenValuesAreTheSame()
        {
            var password = "abcDEF123!@#";
            var salt = _passwordHasher.CreateSalt();

            var hash = _passwordHasher.Create(password, salt);

            var result = _passwordHasher.Validate(password, salt, hash);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Validate_ShouldResultFalse_WhenValuesAreDifferent()
        {
            var password = "abcDEF123!@#";
            var differentPassword = "AbcDEF123!@#";

            var salt = _passwordHasher.CreateSalt();

            var hash = _passwordHasher.Create(password, salt);

            var result = _passwordHasher.Validate(differentPassword, salt, hash);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Create_ShouldResultTheSameHashes_WhenCreatingUsingSamePasswordAndSameSalt()
        {
            var password = "abcDEF123!@#";
            var salt = _passwordHasher.CreateSalt();

            var passwordOne = _passwordHasher.Create(password, salt);
            var passwordTwo = _passwordHasher.Create(password, salt);
            Assert.AreEqual(passwordOne, passwordTwo);
        }

        [TestMethod]
        public void Create_ShouldResultSameHashesLength_WhenUsingDiffrentValues()
        {
            var passwordOne = "abcDEF123!@#";
            var passwordTwo = "123qazXSW#$%";
            var passwordThree = "123";
            var passwordFour = "asdvxc3245543DSFvcbaasd";
            var salt = _passwordHasher.CreateSalt();

            var resultPasswordOne = _passwordHasher.Create(passwordOne, salt);
            var resultPasswordTwo = _passwordHasher.Create(passwordTwo, salt);
            var resultPasswordThree = _passwordHasher.Create(passwordThree, salt);
            var resultPasswordFour = _passwordHasher.Create(passwordFour, salt);

            Assert.AreEqual(resultPasswordOne.Length, resultPasswordTwo.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordThree.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordFour.Length);
        }

        [TestMethod]
        public void Create_ShouldResultSameHashesLength_WhenUsingDiffrentValuesAndSalts()
        {
            var passwordOne = "abcDEF123!@#";
            var passwordTwo = "123qazXSW#$%";
            var passwordThree = "123";
            var passwordFour = "asdvxc3245543DSFvcbaasd";

            var resultPasswordOne = _passwordHasher.Create(passwordOne, _passwordHasher.CreateSalt());
            var resultPasswordTwo = _passwordHasher.Create(passwordTwo, _passwordHasher.CreateSalt());
            var resultPasswordThree = _passwordHasher.Create(passwordThree, _passwordHasher.CreateSalt());
            var resultPasswordFour = _passwordHasher.Create(passwordFour, _passwordHasher.CreateSalt());

            Assert.AreEqual(resultPasswordOne.Length, resultPasswordTwo.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordThree.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordFour.Length);
        }

        [TestMethod]
        public void Create_ShouldCreateDifferentHashes_WhenUsingDifferentSalts()
        {
            var password = "abcDEF123!@#";
            var saltOne = _passwordHasher.CreateSalt();
            var saltTwo = _passwordHasher.CreateSalt();

            var resultPasswordOne = _passwordHasher.Create(password, saltOne);
            var resultPasswordTwo = _passwordHasher.Create(password, saltTwo);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }

        [TestMethod]
        public void Create_ShouldCreateDifferentHashes_WhenUsingDifferentValues()
        {
            var passwordOne = "abcDEF123!@#";
            var passwordTwo = "123qazXSW#$%";

            var salt = _passwordHasher.CreateSalt();

            var resultPasswordOne = _passwordHasher.Create(passwordOne, salt);
            var resultPasswordTwo = _passwordHasher.Create(passwordTwo, salt);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }

        [TestMethod]
        public void CreateSalt_ShouldCreateDIfferentSalts_WhenGeneratingSalt()
        {
            var saltOne = _passwordHasher.CreateSalt();
            var saltTwo = _passwordHasher.CreateSalt();

            Assert.AreNotEqual(saltOne, saltTwo);
        }

        [TestMethod]
        public void CreateSalt_ShouldCreateTheSameSaltLength_WhenCreatingSalts()
        {
            var saltOne = _passwordHasher.CreateSalt();
            var saltTwo = _passwordHasher.CreateSalt();

            Assert.AreEqual(saltOne.Length, saltTwo.Length);
        }
    }
}