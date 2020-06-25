using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IClientQuery
{
    public class ClientQueryService : IClientQueryService
    {
        private readonly IClientRepository _repository;

        public ClientQueryService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Client> FindAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Client> FindByEmailAsync(string email)
        {
            return await _repository.FindByEmailAsync(email);
        }

        public async Task<Client> FindByLoginAsync(string login)
        {
            return await _repository.FindByLoginAsync(login);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }
    }
}