using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services
{
    public class ManageClientService : IManageClientService
    {
        public Task<Client> Create(Client client, string password)
        {
            throw new NotImplementedException();
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
