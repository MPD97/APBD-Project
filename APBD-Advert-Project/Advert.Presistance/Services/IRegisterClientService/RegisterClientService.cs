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
    public class RegisterClientService : IRegisterClientService
    {
        private readonly IPasswordHasherService _passwordHasher;
        protected internal readonly AdvertContext _context;
        public RegisterClientService(IPasswordHasherService passwordHasher, AdvertContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
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
                throw new CannotUpdateException("SaveChangesAsync returned less or equal than 0.");
            }

            return client;
        }
    }
}
