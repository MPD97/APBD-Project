using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;

namespace Advert.Presistance.Services.IClientLogin
{
    public interface IClientLoginService
    {
        public Task<JwtTokenResponseModel> LoginAsync(ClientLoginRequestModel model);
        public Task<JwtTokenResponseModel> RefreshTokenAsync(ClientRefreshTokenModel model);
    }
}