using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Services;
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
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IRegisterService registerService, IMapper mapper,
            ILogger<ClientsController> logger)
        {
            _registerService = registerService;
            _mapper = mapper;
            _logger = logger;
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
                client = await _registerService.Create(client, model.RepeatPassword);
            }
            catch (CannotUpdateException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
            var response = _mapper.Map<ClientRegisterResponseModel>(client);

            return Ok(response);
        }
    }
}