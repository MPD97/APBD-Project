using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services.IJwtBarerService;
using Advert.Presistance.Services.IJwtBearer;
using AdvertDatabaseCL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Advert.Presistance.Services
{
    public class JwtBearerService : IJwtBearerService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtBearerConfig _jwtBearerConfig;
        public JwtBearerService(IConfiguration configuration, JwtBearerConfig jwtBearerConfig)
        {
            _configuration = configuration;
            _jwtBearerConfig = jwtBearerConfig;
        }

        public JwtTokenResponseModel CreateToken(Client model)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.Login),
                new Claim(ClaimTypes.Name, model.FirstName +","+ model.LastName),
                new Claim(ClaimTypes.Role, "default"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Advert",
                audience: "Clients",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds
            );

            var result = new JwtTokenResponseModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = Guid.NewGuid().ToString()
            };
            return result;
        }
    }
}
