using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.IRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AdvertContext _context;

        public ClientRepository(AdvertContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsEnumerable();
        }

        public async Task<Client> FindByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> FindByLoginAsync(string login)
        {
            return await _context.Clients.SingleOrDefaultAsync(c =>
                c.Login.ToLower().Contains(login.ToLower()));
        }

        public async Task<Client> FindByEmailAsync(string email)
        {
            return await _context.Clients.SingleOrDefaultAsync(c =>
                c.Email.ToLower().Contains(email.ToLower()));
        }

        public async Task<Client> FindByTokenAsync(string token, string refresh)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.Token == token && c.RefreshToken == refresh);
        }

        public async Task Insert(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task Insert(IEnumerable<Client> clients)
        {
            await _context.Clients.AddRangeAsync(clients);
        }

        public async Task<bool> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            return true;
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}