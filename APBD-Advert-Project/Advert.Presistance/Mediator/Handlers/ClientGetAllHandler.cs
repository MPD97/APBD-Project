using System.Collections.Generic;
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
    public class ClientGetAllHandler : IRequestHandler<ClientGetAllQuery, IResponseModel>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly IMapper _mapper;

        public ClientGetAllHandler(IClientQueryService clientQueryService, IMapper mapper)
        {
            _clientQueryService = clientQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(ClientGetAllQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _clientQueryService.GetAllAsync();
            if (client == null) return new NotFoundResponse("No clients could be found");

            return new SuccessResponse( client.Select(_mapper.Map<Client, ClientResponseModel>));
        }
    }
}