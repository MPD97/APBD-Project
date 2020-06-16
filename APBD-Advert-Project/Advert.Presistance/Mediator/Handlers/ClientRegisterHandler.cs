﻿using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services;
using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientRegisterHandler : IRequestHandler<ClientRegisterCommand, ClientResponseModel>
    {
        private readonly IManageClientService _manageService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientRegisterHandler> _logger;

        public ClientRegisterHandler(IManageClientService manageService, IMapper mapper,
            ILogger<ClientRegisterHandler> logger)
        {
            _manageService = manageService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ClientResponseModel> Handle(ClientRegisterCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>((ClientRegisterRequestModel)request);
            try
            {
                client = await _manageService.Create(client, request.RepeatPassword);
            }
            catch (CannotUpdateException ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
            return _mapper.Map<ClientResponseModel>(client);
        }
    }
}