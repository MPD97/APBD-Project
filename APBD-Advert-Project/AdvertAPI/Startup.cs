using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.MapProfiles;
using Advert.Presistance.Services;
using AdvertDatabaseCL.Contexts;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AdvertAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdvertContext>(config =>
                config.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddSingleton<IPasswordHasherService, PBKDF2PasswordHasherService>();
            services.AddScoped<IRegisterClientService, RegisterClientService>();
            services.AddSingleton<IMapper>(s => new MapperConfiguration(c => 
                c.AddProfile<ClientProfile>()).CreateMapper());

            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Advert.API", Version = "v1" });
            });    

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advert.API v1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
