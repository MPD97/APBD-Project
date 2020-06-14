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
        private readonly IPasswordHasher _passwordHasher;

        public PBKDF2PasswordHasherTests()
        {
            _passwordHasher = new PBKDF2PasswordHasher();
        }

        [TestMethod()]
        public void Should_Result_True_When_Validate_Same_Password()
        {
            string password = "abcDEF123!@#";
            string salt = _passwordHasher.CreateSalt();

            string hash = _passwordHasher.Create(password, salt);

            bool result = _passwordHasher.Validate(password, salt, hash);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void Should_Result_False_When_Validate_Password_Is_Different()
        {
            string password = "abcDEF123!@#";
            string differentPassword = "AbcDEF123!@#";

            string salt = _passwordHasher.CreateSalt();

            string hash = _passwordHasher.Create(password, salt);

            bool result = _passwordHasher.Validate(differentPassword, salt, hash);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void Should_Create_Same_Passwords()
        {
            string password = "abcDEF123!@#";
            string salt = _passwordHasher.CreateSalt();

            string passwordOne = _passwordHasher.Create(password, salt);
            string passwordTwo = _passwordHasher.Create(password, salt);
            Assert.AreEqual(passwordOne, passwordTwo);
        }
        [TestMethod()]
        public void Should_Create_Same_Passwords_Length()
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
        public void Should_Create_Same_Passwords_Length_Using_Different_Salt()
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
        public void Should_Create_Different_Passwords_Using_Different_Salt()
        {
            string password = "abcDEF123!@#";
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            string resultPasswordOne = _passwordHasher.Create(password, saltOne);
            string resultPasswordTwo = _passwordHasher.Create(password, saltTwo);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }
        [TestMethod()]
        public void Should_Create_Different_Passwords_Using_Same_Salt_And_Different_Passwords()
        {
            string passwordOne = "abcDEF123!@#";
            string passwordTwo = "123qazXSW#$%";

            string salt = _passwordHasher.CreateSalt();

            string resultPasswordOne = _passwordHasher.Create(passwordOne, salt);
            string resultPasswordTwo = _passwordHasher.Create(passwordTwo, salt);
            Assert.AreNotEqual(resultPasswordOne, resultPasswordTwo);
        }

        [TestMethod()]
        public void Should_Create_Differnt_Salt()
        {
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            Assert.AreNotEqual(saltOne, saltTwo);
        }
        [TestMethod()]
        public void Should_Create_Same_Length_Salt()
        {
            string saltOne = _passwordHasher.CreateSalt();
            string saltTwo = _passwordHasher.CreateSalt();

            Assert.AreEqual(saltOne.Length, saltTwo.Length);
        }
    }
}