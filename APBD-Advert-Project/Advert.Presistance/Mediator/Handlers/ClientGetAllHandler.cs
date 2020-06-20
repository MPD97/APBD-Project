using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IClientQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientGetAllHandler : IRequestHandler<ClientGetAllQuery, IEnumerable<ClientResponseModel>>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetAllHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientResponseModel>> Handle(ClientGetAllQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.GetAllAsync();
            if (client == null) return null;

            return client.Select(_mapper.Map<Client, ClientResponseModel>);
        }
    }
}