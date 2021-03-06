﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IClientQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class
        ClientGetAllHandler : IRequestHandler<ClientGetAllQuery, IResponseModel<IEnumerable<ClientResponse>>>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetAllHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel<IEnumerable<ClientResponse>>> Handle(ClientGetAllQuery request,
            CancellationToken cancellationToken)
        {
            var clients = _clientQueryService.GetAll(request.Login, request.FirstName, request.LastName, request.Phone)
                ?.ToList();
            if (clients == null || !clients.Any())
                return new NotFoundResponse<IEnumerable<ClientResponse>>("No clients could be found");

            return new SuccessResponse<IEnumerable<ClientResponse>>(
                clients.Select(_mapper.Map<Client, ClientResponse>));
        }
    }
}