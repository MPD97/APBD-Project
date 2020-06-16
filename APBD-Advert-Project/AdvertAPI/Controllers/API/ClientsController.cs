using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services;
using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Advert.API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IManageClientService _manageService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientsController> _logger;
        private readonly IMediator _mediator;

        public ClientsController(IManageClientService manageService, IMapper mapper,
            ILogger<ClientsController> logger, IMediator mediator)
        {
            _manageService = manageService;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetClientQuery(id);
            var result = await _mediator.Send(query);
            return result != null ?(IActionResult) Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientRegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = _mapper.Map<Client>(model);
            try
            {
                client = await _manageService.Create(client, model.RepeatPassword);
            }
            catch (CannotUpdateException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
            var response = _mapper.Map<ClientResponseModel>(client);

            return CreatedAtAction(nameof(Get), new { id = client.IdClient }, response);
        }
    }
}