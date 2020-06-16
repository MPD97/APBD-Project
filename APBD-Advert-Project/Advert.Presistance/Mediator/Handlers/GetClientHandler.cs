using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IManageService;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, ClientResponseModel>
    {
        private readonly IManageClientService _manageService;
        private readonly IMapper _mapper;

        public GetClientHandler(IManageClientService manageService, IMapper mapper)
        {
            _manageService = manageService;
            _mapper = mapper;
        }

        public async Task<ClientResponseModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _manageService.Get(request.ClientId);
            if (client == null)
            {
                return null;
            }

           return _mapper.Map<ClientResponseModel>(client);
        }
    }
}
