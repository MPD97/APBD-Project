using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Presistance.Services.IJwtBarerService
{
    public interface IJwtBearerService
    {
        public JwtTokenResponseModel CreateToken(Client model);
    }
}
