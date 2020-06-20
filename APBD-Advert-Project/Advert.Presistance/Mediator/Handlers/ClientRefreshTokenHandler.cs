using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IClientLogin;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientRefreshTokenHandler : IRequestHandler<ClientRefreshTokenCommand, JwtTokenResponseModel>
    {
        private readonly IClientLoginService _loginService;

        public ClientRefreshTokenHandler(IClientLoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<JwtTokenResponseModel> Handle(ClientRefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var tokenResult = await _loginService.RefreshTokenAsync(request);

            return tokenResult;
        }
    }
}