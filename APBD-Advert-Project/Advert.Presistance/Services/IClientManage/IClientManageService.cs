using Advert.Presistance.Services.IClientQuery;
using Advert.Presistance.Services.IClientRegister;

namespace Advert.Presistance.Services.IClientManage
{
    public interface IClientManageService : IClientRegisterService, IClientQueryService
    {
    }
}