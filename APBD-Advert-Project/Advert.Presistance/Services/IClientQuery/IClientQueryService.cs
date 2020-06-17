using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IManageService
{
    public interface IClientQueryService
    {
        public Task<Client> Get(int id);

        public Task<ICollection<Client>> GetAll();
    }
}
