using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IRepository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Task<Client> FindByIdAsync(int id);
        Task<Client> FindByLoginAsync(string login);
        Task<Client> FindByEmailAsync(string email);
        Task<Client> FindByTokenAsync(string token, string refresh);
        Task Insert(Client client);
        Task Insert(IEnumerable<Client> clients);
        Task<bool> Delete(int id);
        void Update(Client client);
        Task<int> SaveAsync();
    }
}