using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Advert.Presistance.Services.IClientRegister.Exceptions;
using Advert.Presistance.Services.IPasswordHasher;

namespace Advert.Presistance.Services.IClientRegister
{
    public class ClientRegisterService : IClientRegisterService
    {
        private readonly IPasswordHasherService _passwordHasher;
        private readonly AdvertContext _context;
        public ClientRegisterService(IPasswordHasherService passwordHasher, AdvertContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client, string password)
        {
            // Create salt
            var salt = _passwordHasher.CreateSalt();

            // Create hash
            var hash = _passwordHasher.Create(password, salt);

            // Assign into Client
            client.Salt = salt;
            client.Hash = hash;

            // Start tracking
            _context.Add(client);

            if ((await _context.SaveChangesAsync()) <= 0)
            {
                throw new CannotUpdateException("SaveChangesAsync returned less or equal than 0.");
            }

            return client;
        }
    }
}
