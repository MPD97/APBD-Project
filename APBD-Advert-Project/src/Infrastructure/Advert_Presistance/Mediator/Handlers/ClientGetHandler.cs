using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IClientQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientGetHandler : IRequestHandler<ClientGetQuery, IResponseModel<ClientResponse>>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel<ClientResponse>> Handle(ClientGetQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.FindAsync(request.ClientId);
            if (client == null)
                return new NotFoundResponse<ClientResponse>("No client could be found with this id");

            return new SuccessResponse<ClientResponse>(_mapper.Map<ClientResponse>(client));
        }
    }
}