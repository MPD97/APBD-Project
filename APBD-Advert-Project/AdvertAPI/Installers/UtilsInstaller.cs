using System;
using System.Collections.Generic;
using Advert.Database.MapProfiles;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Advert.API.Installers
{
    public class UtilsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(s => new MapperConfiguration(configure =>
                {
                    configure.AddProfile<ClientProfile>();
                    configure.AddProfile<CampaignProfile>();
                    configure.AddProfile<BuildingProfile>();
                    configure.AddProfile<BannerProfile>();
                })
                .CreateMapper());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Advert.API", Version = "v1"});

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            var assembly = AppDomain.CurrentDomain.Load("Advert.Presistance");
            services.AddMediatR(assembly);
        }
    }
}