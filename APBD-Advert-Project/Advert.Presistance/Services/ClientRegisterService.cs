using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public class ClientRegisterService : IRegisterService
    {
        private readonly IPasswordHasher _passwordHasher;

        public ClientRegisterService(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public ClientRegisterResponseModel Create(ClientRegisterRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
