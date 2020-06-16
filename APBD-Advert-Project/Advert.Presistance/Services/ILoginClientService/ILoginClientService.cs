using Advert.Database.DTOs.Requests;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ILoginClientService
{
    public interface ILoginClientService
    {
        public Task<Client> Login(ClientLoginRequestModel model);
    }
}
