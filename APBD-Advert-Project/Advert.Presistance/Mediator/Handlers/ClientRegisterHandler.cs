using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IClientQuery;
using Advert.Presistance.Services.IClientRegister;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientRegisterHandler : IRequestHandler<ClientRegisterCommand, IResponseModel<ClientResponseModel>>
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly ILogger<ClientRegisterHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClientRegisterService _registerService;

        public ClientRegisterHandler(IClientRegisterService registerService, IMapper mapper,
            ILogger<ClientRegisterHandler> logger, IClientQueryService clientQueryService)
        {
            _registerService = registerService;
            _mapper = mapper;
            _logger = logger;
            _clientQueryService = clientQueryService;
        }

        public async Task<IResponseModel<ClientResponseModel>> Handle(ClientRegisterCommand request,
            CancellationToken cancellationToken)
        {
            if (await _clientQueryService.FindByEmailAsync(request.Email) != null)
                return new BadRequestResponse<ClientResponseModel>("Client with this email already exists.");

            if (await _clientQueryService.FindByLoginAsync(request.Login) != null)
                return new BadRequestResponse<ClientResponseModel>("Client with this login already exists.");

            var client = await _registerService.CreateAsync(_mapper.Map<Client>(request), request.RepeatPassword);
            if (client == null) return new BadRequestResponse<ClientResponseModel>("Cannot create client");

            return new SuccessResponse<ClientResponseModel>("Client created.",
                _mapper.Map<ClientResponseModel>(client));
        }
    }
}