using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public class ClientRegisterService : IRegisterService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly AdvertContext _context;
        public ClientRegisterService(IPasswordHasher passwordHasher, AdvertContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public ClientRegisterResponseModel Create(ClientRegisterRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
