using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Client> GetAll(string login = null, string firstName = null, string lastName = null,
            string phone = null)
        {
            var query = _repository.GetAll();
            if (login != null)
                query = query.Where(a =>
                    string.Equals(a.Login, login, StringComparison.CurrentCultureIgnoreCase));
            if (firstName != null)
                query = query.Where(a =>
                    string.Equals(a.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase));

            if (lastName != null)
                query = query.Where(a =>
                    string.Equals(a.LastName, lastName, StringComparison.InvariantCultureIgnoreCase));

            if (phone != null)
                query = query.Where(a => string.Equals(a.Phone, phone, StringComparison.InvariantCultureIgnoreCase));

            return query.AsEnumerable();
        }
    }
}