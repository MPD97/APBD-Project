using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IClientQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientGetHandler : IRequestHandler<ClientGetQuery, ClientResponseModel>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<ClientResponseModel> Handle(ClientGetQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.GetAsync(request.ClientId);
            if (client == null) return null;

            return _mapper.Map<ClientResponseModel>(client);
        }
    }
}