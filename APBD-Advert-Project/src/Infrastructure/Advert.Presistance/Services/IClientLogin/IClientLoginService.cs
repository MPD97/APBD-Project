using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;

namespace Advert.Presistance.Services.IClientLogin
{
    public interface IClientLoginService
    {
        public Task<JwtTokenResponse> LoginAsync(ClientLoginRequest model);
        public Task<JwtTokenResponse> RefreshTokenAsync(ClientRefreshToken model);
    }
}