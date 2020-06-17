using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services
{
    public class ClientQueryService : IClientQueryService
    {
        protected internal readonly AdvertContext _context;

        public ClientQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<Client> Get(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.IdClient == id);
        }

        public async Task<ICollection<Client>> GetAll()
        {
            return await _context.Clients.ToArrayAsync();
        }
    }
}
