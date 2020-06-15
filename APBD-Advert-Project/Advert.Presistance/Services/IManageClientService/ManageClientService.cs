using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
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

        public Task<Client> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Client>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
