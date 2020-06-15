using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public class ClientRegisterService : IRegisterService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly AdvertContext _context;
        private readonly IMapper _mapper;
        public ClientRegisterService(IPasswordHasher passwordHasher, AdvertContext context, IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _mapper = mapper;
        }

        public ClientRegisterResponseModel Create(ClientRegisterRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
