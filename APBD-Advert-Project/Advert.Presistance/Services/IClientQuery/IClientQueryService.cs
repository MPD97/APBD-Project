using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IClientQuery
{
    public interface IClientQueryService
    {
        public Task<Client> GetAsync(int id);

        public Task<IEnumerable<Client>> GetAllAsync();
    }
}