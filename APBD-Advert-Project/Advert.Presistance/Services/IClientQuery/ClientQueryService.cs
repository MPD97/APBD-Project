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

        public async Task<Client> FindAsync(int id)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.IdClient == id);
        }

        public async Task<Client> FindByEmailAsync(string email)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Client> FindByLoginAsync(string login)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.Login == login);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToArrayAsync();
        }
    }
}