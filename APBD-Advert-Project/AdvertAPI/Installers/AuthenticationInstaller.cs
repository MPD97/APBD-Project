using Advert.Presistance.Services.IJwtBearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.API.Installers
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtBearerConfig = new JwtBearerConfig();
            configuration.Bind(nameof(JwtBearerConfig), jwtBearerConfig);

            services.AddSingleton(jwtBearerConfig);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                              .AddJwtBearer(options =>
                              {
                                  options.TokenValidationParameters = new TokenValidationParameters
                                  {
                                      ValidateIssuer = true,
                                      ValidateAudience = true,
                                      ValidateLifetime = true,
                                      ValidIssuer = "Advert",
                                      ValidAudience = "Clients",
                                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerConfig.Secret))
                                  };
                              });
        }
    }
}
