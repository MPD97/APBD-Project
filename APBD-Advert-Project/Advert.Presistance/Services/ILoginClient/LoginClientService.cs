using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services.IJwtBarerService;
using AdvertDatabaseCL.Contexts;
using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<JwtTokenResponseModel> LoginAsync(ClientLoginRequestModel model)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Login == model.Login);
            if (client == null)
            {
                return null;
            }

            var loginResult = _passwordHasher.Validate(model.Password, client.Salt, client.Hash);
            if (!loginResult)
            {
                return null;
            }

            return await GenerateAndSaveTokenAsync(client);
        }

        private async Task<JwtTokenResponseModel> GenerateAndSaveTokenAsync(Client client)
        {
            var tokenResult = _jwtBearer.CreateToken(client);
            client.RefreshToken = tokenResult.RefreshToken;
            client.Token = tokenResult.Token;

            _context.Entry(client).State = EntityState.Modified;
            if ((await _context.SaveChangesAsync()) <= 0)
            {
                return null;
            }

            return tokenResult;
        }

        public async Task<JwtTokenResponseModel> RefreshTokenAsync(ClientRefreshTokenModel model)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.RefreshToken == model.RefreshToken && c.Token == model.Token);
            if (client == null)
            {
                return null;
            }

            return await GenerateAndSaveTokenAsync(client);
        }
    }
}
