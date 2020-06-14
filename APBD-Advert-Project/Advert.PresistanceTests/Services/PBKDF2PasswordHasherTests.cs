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
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Should_Create_Diffrent_Salt()
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