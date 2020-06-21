using Advert.Presistance.Services.IBannerCalculate;
using Advert.Presistance.Services.IBannerCreate;
using Advert.Presistance.Services.IBannerQuery;
using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.ICampaignCreate;
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
            services.AddScoped<ICampaignCreateService, CampaignCreateService>();

            services.AddScoped<IBuildingQueryService, BuildingQueryService>();

            services.AddScoped<IBannerQueryService, BannerQueryService>();
            services.AddScoped<IBannerCreateService, BannerCreateService>();
            services.AddScoped<IBannerCalculateService, BannerCalculateService>();
        }
    }
}