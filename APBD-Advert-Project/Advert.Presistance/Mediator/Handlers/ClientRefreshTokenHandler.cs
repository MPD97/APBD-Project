using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.ILoginClientService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientRefreshTokenHandler : IRequestHandler<ClientRefreshTokenCommand, JwtTokenResponseModel>
    {
        private readonly ILoginClientService _loginService;

        public ClientRefreshTokenHandler(ILoginClientService loginService)
        {
            _loginService = loginService;
        }
        public async Task<JwtTokenResponseModel> Handle(ClientRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await _loginService.RefreshTokenAsync(request);

            return tokenResult;
        }
    }
}
