using Advert.Presistance.Services;
using Advert.Presistance.Services.ICampaignQuery;
using Advert.Presistance.Services.IClientLogin;
using Advert.Presistance.Services.IClientQuery;
using Advert.Presistance.Services.IClientRegister;
using Advert.Presistance.Services.IJwtBearer;
using Advert.Presistance.Services.IPasswordHasher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advert.API.Installers
{
    public class DataManipulationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasherService, Pbkdf2PasswordHasherService>();
            services.AddSingleton<IJwtBearerService, JwtBearerService>();
            services.AddScoped<IClientLoginService, ClientLoginService>();
            services.AddScoped<IClientRegisterService, ClientRegisterService>();
            services.AddScoped<IClientQueryService, ClientQueryService>();
            services.AddScoped<ICampaignQueryService, CampaignQueryService>();
        }
    }
}
