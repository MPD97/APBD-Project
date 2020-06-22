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
    public class ClientGetHandler : IRequestHandler<ClientGetQuery, IResponseModel>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(ClientGetQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.GetAsync(request.ClientId);
            if (client == null) return new NotFoundResponse("No client could be found with this id");

            return new SuccessResponse( _mapper.Map<ClientResponseModel>(client));
        }
    }
}