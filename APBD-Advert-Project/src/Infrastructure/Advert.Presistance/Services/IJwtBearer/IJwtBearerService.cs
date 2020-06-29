using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IJwtBearer
{
    public interface IJwtBearerService
    {
        public JwtTokenResponse CreateToken(Client model);
    }
}