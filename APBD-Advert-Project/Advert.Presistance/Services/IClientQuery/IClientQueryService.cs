using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IManageService
{
    public interface IClientQueryService
    {
        public Task<Client> GetAsync(int id);

        public Task<IEnumerable<Client>> GetAllAsync();
    }
}
