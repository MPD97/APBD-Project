using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientResponseModel>>
    {
        private readonly IManageClientService _manageService;
        private readonly IMapper _mapper;

        public GetAllClientsHandler(IManageClientService manageService, IMapper mapper)
        {
            _manageService = manageService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientResponseModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var client = await _manageService.GetAll();
            if (client == null)
            {
                return null;
            }
            
            return client.Select(_mapper.Map<Client, ClientResponseModel>); 
        }
    }
}