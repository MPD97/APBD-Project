using Advert.Database.DTOs.Requests;
using Advert.Presistance.Services.IJwtBarerService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ILoginClientService
{
    public class LoginClientService : ILoginClientService
    {
        private readonly IPasswordHasherService _passwordHasher;
        protected internal readonly AdvertContext _context;
        private readonly IJwtBearerService _jwtBearer;

        public LoginClientService(IPasswordHasherService passwordHasher, AdvertContext context, IJwtBearerService jwtBearer)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _jwtBearer = jwtBearer;
        }

        public Task<Client> Login(ClientLoginRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
