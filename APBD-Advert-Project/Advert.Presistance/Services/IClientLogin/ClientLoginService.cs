using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Services.IJwtBearer;
using Advert.Presistance.Services.IPasswordHasher;
using Advert.Presistance.Services.IRepository;

namespace Advert.Presistance.Services.IClientLogin
{
    public class ClientLoginService : IClientLoginService
    {
        private readonly IJwtBearerService _jwtBearer;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly IClientRepository _repository;

        public ClientLoginService(IClientRepository repository, IJwtBearerService jwtBearer,
            IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _jwtBearer = jwtBearer;
            _passwordHasher = passwordHasher;
        }


        public async Task<JwtTokenResponseModel> LoginAsync(ClientLoginRequestModel model)
        {
            var client = await _repository.FindByLoginAsync(model.Login);
            if (client == null) return null;

            var loginResult = _passwordHasher.Validate(model.Password, client.Salt, client.Hash);
            if (!loginResult) return null;

            return await GenerateAndSaveTokenAsync(client);
        }

        public async Task<JwtTokenResponseModel> RefreshTokenAsync(ClientRefreshTokenModel model)
        {
            var client = await _repository.FindByTokenAsync(model.Token, model.RefreshToken);
            if (client == null) return null;

            return await GenerateAndSaveTokenAsync(client);
        }

        private async Task<JwtTokenResponseModel> GenerateAndSaveTokenAsync(Client client)
        {
            var tokenResult = _jwtBearer.CreateToken(client);

            client.RefreshToken = tokenResult.RefreshToken;
            client.Token = tokenResult.Token;

            _repository.Update(client);

            return await _repository.SaveAsync() <= 0 ? null : tokenResult;
        }
    }
}