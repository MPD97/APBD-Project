using Advert.Database.Contexts;
using Advert.Database.Entities;
using Advert.Presistance.Services.IClientRegister;
using Advert.Presistance.Services.IPasswordHasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Advert.PresistanceTests.Services.IRegisterClientService
{
    [TestClass]
    public class RegisterClientServiceTests
    {
        [TestMethod]
        public void Create_ShouldReturnClientWithId_WhenEverythingIsOk()
        {
            // Counters to verify call order
            var callCount = 0;
            var addUser = 0;
            var saveChanges = 0;

            // use Moq to create a mock IDbContext.
            var mockContext = new Mock<AdvertContext>();

            // Register callbacks for the mocked methods to increment our counters.
            mockContext.Setup(x => x.Add(It.IsAny<Client>())).Callback(() => addUser = callCount++);
            mockContext.Setup(x => x.SaveChanges()).Callback(() => saveChanges = callCount++);

            // Create the command, providing it the mocked IDbContext and execute it
            var command = new ClientRegisterService(new Pbkdf2PasswordHasherService(), mockContext.Object);
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