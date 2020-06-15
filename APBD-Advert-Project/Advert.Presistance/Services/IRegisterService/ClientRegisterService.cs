using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Client> Create(Client client, string password)
        {
            // Create salt
            var salt = _passwordHasher.CreateSalt();

            // Create hash
            var hash = _passwordHasher.Create(password, salt);

            // Assign into Client
            client.Salt = salt;
            client.Hash = hash;

            // Start tracking
            _context.Add(client);

            if ((await _context.SaveChangesAsync()) <= 0)
            {
                throw new CannotUpdateException("SaveChangesAsync returned less or equal 0.");
            }

            return client;
        }
    }
}
