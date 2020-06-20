﻿using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Advert.Presistance.Services.IClientLogin;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientLoginHandler : IRequestHandler<ClientLoginCommand, JwtTokenResponseModel>
    {
        private readonly  IClientLoginService _loginService;

        public ClientLoginHandler(IClientLoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<JwtTokenResponseModel> Handle(ClientLoginCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await _loginService.LoginAsync(request);

            return tokenResult;
        }
    }
}
