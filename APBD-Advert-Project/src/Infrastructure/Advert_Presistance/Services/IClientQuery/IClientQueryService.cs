using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IClientQuery
{
    public interface IClientQueryService
    {
        public Task<Client> FindAsync(int id);
        public Task<Client> FindByEmailAsync(string email);
        public Task<Client> FindByLoginAsync(string login);

        public IEnumerable<Client> GetAll(string login = null, string firstName = null, string lastName = null,
            string phone = null);
    }
}