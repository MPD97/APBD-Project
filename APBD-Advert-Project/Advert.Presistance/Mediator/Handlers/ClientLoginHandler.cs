using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IClientLogin;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientLoginHandler : IRequestHandler<ClientLoginCommand, IResponseModel>
    {
        private readonly IClientLoginService _loginService;

        public ClientLoginHandler(IClientLoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<IResponseModel> Handle(ClientLoginCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await _loginService.LoginAsync(request);
            if (tokenResult == null)
            {
                return new ErrorResponse("Cannot create token");
            }
            return new SuccessResponse(tokenResult);
        }
    }
}