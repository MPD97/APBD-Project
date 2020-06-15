using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advert.Presistance.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services.Tests
{
    [TestClass()]
    public class PBKDF2PasswordHasherTests
    {
        private readonly IPasswordHasherService _passwordHasher;

        public PBKDF2PasswordHasherTests()
        {
            _passwordHasher = new PBKDF2PasswordHasherService();
        }

        [TestMethod()]
        public void Validate_ShouldResultTrue_WhenValuesAreTheSame()
        {
            string password = "abcDEF123!@#";
            string salt = _passwordHasher.CreateSalt();

            string hash = _passwordHasher.Create(password, salt);

            bool result = _passwordHasher.Validate(password, salt, hash);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void Validate_ShouldResultFalse_WhenValuesAreDifferent()
        {
            string password = "abcDEF123!@#";
            string differentPassword = "AbcDEF123!@#";

            string salt = _passwordHasher.CreateSalt();

            string hash = _passwordHasher.Create(password, salt);

            bool result = _passwordHasher.Validate(differentPassword, salt, hash);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void Create_ShouldResultTheSameHashes_WhenCreatingUsingSamePasswordAndSameSalt()
        {
            string password = "abcDEF123!@#";
            string salt = _passwordHasher.CreateSalt();

            string passwordOne = _passwordHasher.Create(password, salt);
            string passwordTwo = _passwordHasher.Create(password, salt);
            Assert.AreEqual(passwordOne, passwordTwo);
        }
        [TestMethod()]
        public void Create_ShouldResultSameHashesLength_WhenUsingDiffrentValues()
        {
            string passwordOne = "abcDEF123!@#";
            string passwordTwo = "123qazXSW#$%";
            string passwordThree = "123";
            string passwordFour = "asdvxc3245543DSFvcbaasd";
            string salt = _passwordHasher.CreateSalt();

            string resultPasswordOne = _passwordHasher.Create(passwordOne, salt);
            string resultPasswordTwo = _passwordHasher.Create(passwordTwo, salt);
            string resultPasswordThree = _passwordHasher.Create(passwordThree, salt);
            string resultPasswordFour = _passwordHasher.Create(passwordFour, salt);

            Assert.AreEqual(resultPasswordOne.Length, resultPasswordTwo.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordThree.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordFour.Length);
        }
        [TestMethod()]
        public void Create_ShouldResultSameHashesLength_WhenUsingDiffrentValuesAndSalts()
        {
            string passwordOne = "abcDEF123!@#";
            string passwordTwo = "123qazXSW#$%";
            string passwordThree = "123";
            string passwordFour = "asdvxc3245543DSFvcbaasd";

            string resultPasswordOne = _passwordHasher.Create(passwordOne, _passwordHasher.CreateSalt());
            string resultPasswordTwo = _passwordHasher.Create(passwordTwo, _passwordHasher.CreateSalt());
            string resultPasswordThree = _passwordHasher.Create(passwordThree, _passwordHasher.CreateSalt());
            string resultPasswordFour = _passwordHasher.Create(passwordFour, _passwordHasher.CreateSalt());

            Assert.AreEqual(resultPasswordOne.Length, resultPasswordTwo.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordThree.Length);
            Assert.AreEqual(resultPasswordOne.Length, resultPasswordFour.Length);
        }

        [TestMethod()]
        public void Create_ShouldCreateDifferentHashes_WhenUsingDifferentSalts()
        {
            string password = "abcDEF123!@#";
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            string resultPasswordOne = _passwordHasher.Create(password, saltOne);
            string resultPasswordTwo = _passwordHasher.Create(password, saltTwo);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }
        [TestMethod()]
        public void Create_ShouldCreateDifferentHashes_WhenUsingDifferentValues()
        {
            string passwordOne = "abcDEF123!@#";
            string passwordTwo = "123qazXSW#$%";

            string salt = _passwordHasher.CreateSalt();

            string resultPasswordOne = _passwordHasher.Create(passwordOne, salt);
            string resultPasswordTwo = _passwordHasher.Create(passwordTwo, salt);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }

        [TestMethod()]
        public void CreateSalt_ShouldCreateDIfferentSalts_WhenGeneratingSalt()
        {
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            Assert.AreNotEqual(saltOne, saltTwo);
        }
        [TestMethod()]
        public void CreateSalt_ShouldCreateTheSameSaltLength_WhenCreatingSalts()
        {
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            Assert.AreEqual(saltOne.Length, saltTwo.Length);
        }
    }
}