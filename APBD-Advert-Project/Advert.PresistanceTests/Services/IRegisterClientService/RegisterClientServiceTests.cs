using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advert.Presistance.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AdvertDatabaseCL.Contexts;
using Moq;
using AdvertDatabaseCL.Entities;

namespace Advert.Presistance.Services.Tests
{
    [TestClass()]
    public class RegisterClientServiceTests
    {
        [TestMethod()]
        public void Create_ShouldReturnClientWithId_WhenEverythingIsOk()
        {
            // Counters to verify call order
            int callCount = 0;
            int addUser = 0;
            int saveChanges = 0;

            // use Moq to create a mock IDbContext.
            var mockContext = new Mock<AdvertContext>();

            // Register callbacks for the mocked methods to increment our counters.
            mockContext.Setup(x => x.Add(It.IsAny<Client>())).Callback(() => addUser = callCount++);
            mockContext.Setup(x => x.SaveChanges()).Callback(() => saveChanges = callCount++);

            // Create the command, providing it the mocked IDbContext and execute it
            var command = new ClientRegisterService(new PBKDF2PasswordHasherService(), mockContext.Object);
            command.CreateAsync(new Client(), "abc");

            // Check that each method was only called once.
            mockContext.Verify(x => x.Add(It.IsAny<Client>()), Times.Once());
            mockContext.Verify(x => x.SaveChanges(), Times.Once());

            // check the counters to confirm the call order.
            Assert.AreEqual(0, addUser);
            Assert.AreEqual(1, saveChanges);
        }
    }
}