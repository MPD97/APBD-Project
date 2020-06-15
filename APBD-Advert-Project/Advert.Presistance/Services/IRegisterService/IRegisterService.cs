
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services
{
    public interface IRegisterService
    {
        public Task<Client> Create(Client client, string password);
    }
}
