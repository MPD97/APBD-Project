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
    public class ManageClientService : RegisterClientService, IManageClientService
    {
        public ManageClientService(IPasswordHasherService passwordHasher, AdvertContext context) : base(passwordHasher, context)
        {
        }

        public async Task<Client> Get(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.IdClient == id);
        }

        public Task<ICollection<Client>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
