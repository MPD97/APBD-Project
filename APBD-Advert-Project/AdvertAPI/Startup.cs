using System;
using System.Linq;
using Advert.API.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Advert.API
{
    // TODO: Add filters to requests
    // TODO: Add fluent validation
    // TODO: Add fluent validation using Mediator
    // TODO: Change return type of services to some IResponseService interface
    // TODO: Add clean code logging
    // TODO: Add clean code performance
    // TODO: Add Polly
    // TODO: Add caching 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x)
                                                                               && x.IsInterface == false &&
                                                                               x.IsAbstract == false)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(i => i.InstallServices(services, Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advert.API v1"); });
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}