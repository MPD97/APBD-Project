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
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public GetClientHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<ClientResponseModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.Get(request.ClientId);
            if (client == null)
            {
                return null;
            }

           return _mapper.Map<ClientResponseModel>(client);
        }
    }
}
