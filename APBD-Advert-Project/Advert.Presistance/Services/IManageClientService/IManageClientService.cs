using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IManageService
{
    public interface IManageClientService
    {
        public Task<Client> Create(Client client, string password);

    }
}
