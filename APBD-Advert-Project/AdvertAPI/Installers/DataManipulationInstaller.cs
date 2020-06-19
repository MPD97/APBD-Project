using Advert.Presistance.Services;
using Advert.Presistance.Services.ICampaignQuery;
using Advert.Presistance.Services.ICampaignService;
using Advert.Presistance.Services.IJwtBarerService;
using Advert.Presistance.Services.ILoginClientService;
using Advert.Presistance.Services.IManageService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advert.API.Installers
{
    public class DataManipulationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasherService, PBKDF2PasswordHasherService>();
            services.AddSingleton<IJwtBearerService, JwtBearerService>();
            services.AddScoped<IClientLoginService, ClientLoginService>();
            services.AddScoped<IClientRegisterService, ClientRegisterService>();
            services.AddScoped<IClientQueryService, ClientQueryService>();
            services.AddScoped<ICampaignQueryService, CampaignQueryService>();
        }
    }
}
