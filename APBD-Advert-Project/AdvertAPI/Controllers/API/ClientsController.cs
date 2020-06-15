using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services;
using Advert.Presistance.Services.IManageService;
using AdvertDatabaseCL.Entities;
using AutoMapper;
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

        public ClientsController(IManageClientService manageService, IMapper mapper,
            ILogger<ClientsController> logger)
        {
            _manageService = manageService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _manageService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            
            var response = _mapper.Map<ClientResponseModel>(client);
            return Ok(response);
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