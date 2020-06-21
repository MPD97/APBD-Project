using System.Collections.Generic;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.IClientQuery
{
    public class ClientQueryService : IClientQueryService
    {
        private readonly AdvertContext _context;

        public ClientQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<Client> GetAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.IdClient == id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToArrayAsync();
        }
    }
}