using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IClientRegister;
using Advert.Presistance.Services.IClientRegister.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Advert.Presistance.Mediator.Handlers
{
    public class ClientRegisterHandler : IRequestHandler<ClientRegisterCommand, ClientResponseModel>
    {
        private readonly ILogger<ClientRegisterHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClientRegisterService _registerService;

        public ClientRegisterHandler(IClientRegisterService registerService, IMapper mapper,
            ILogger<ClientRegisterHandler> logger)
        {
            _registerService = registerService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ClientResponseModel> Handle(ClientRegisterCommand request,
            CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);
            try
            {
                client = await _registerService.CreateAsync(client, request.RepeatPassword);
            }
            catch (CannotUpdateException ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

            return _mapper.Map<ClientResponseModel>(client);
        }
    }
}