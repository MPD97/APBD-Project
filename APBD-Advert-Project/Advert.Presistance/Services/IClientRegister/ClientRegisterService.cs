using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IPasswordHasher;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IClientRegister
{
    public class ClientRegisterService : IClientRegisterService
    {
        private readonly IPasswordHasherService _passwordHasher;
        private readonly IClientRepository _repository;

        public ClientRegisterService(IClientRepository repository, IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }


        public async Task<Client> CreateAsync(Client client, string password)
        {
            var salt = _passwordHasher.CreateSalt();

            var hash = _passwordHasher.Create(password, salt);

            client.Salt = salt;
            client.Hash = hash;

            await _repository.Insert(client);

            if (await _repository.SaveAsync() <= 0)
                return null;

            return client;
        }
    }
}