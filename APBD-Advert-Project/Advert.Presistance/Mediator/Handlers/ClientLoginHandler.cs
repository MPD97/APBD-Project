using Advert.Database.DTOs.Requests;
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
    public class ClientLoginHandler : IRequestHandler<ClientLoginCommand, ClientLoginRequestModel>
    {
        private readonly  ILoginClientService _loginService;

        public ClientLoginHandler(ILoginClientService loginService)
        {
            _loginService = loginService;
        }

        public async Task<ClientLoginRequestModel> Handle(ClientLoginCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await _loginService.Login(request);

            return tokenResult;
        }
    }
}
