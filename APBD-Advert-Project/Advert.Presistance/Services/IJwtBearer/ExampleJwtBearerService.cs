using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services.IJwtBarerService;
using AdvertDatabaseCL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Advert.Presistance.Services
{
    public class ExampleJwtBearerService : IJwtBearerService
    {
        private readonly IConfiguration _configuration;

        public ExampleJwtBearerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtTokenResponseModel CreateToken(Client model)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.Login),
                new Claim(ClaimTypes.Name, model.FirstName +","+ model.LastName),
                new Claim(ClaimTypes.Role, "default"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secret"]));
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
