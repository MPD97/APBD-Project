using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.ILoginClientService
{
    public interface ILoginClientService
    {
        public Task<JwtTokenResponseModel> LoginAsync(ClientLoginRequestModel model);
        public Task<JwtTokenResponseModel> RefreshTokenAsync(ClientRefreshTokenModel model);
    }
}
