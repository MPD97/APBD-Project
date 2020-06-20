using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IClientRegister
{
    public interface IClientRegisterService
    {
        public Task<Client> CreateAsync(Client client, string password);
    }
}
