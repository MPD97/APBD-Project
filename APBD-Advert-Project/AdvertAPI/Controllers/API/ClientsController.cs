using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services;
using Advert.Presistance.Services.ILoginClientService;
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
        private readonly IMediator _mediator;
        private readonly ILoginClientService _loginService;

        public ClientsController(IMediator mediator, ILoginClientService loginService)
        {
            _mediator = mediator;
            _loginService = loginService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllClientsQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetClientQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientRegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel { Errors = ModelState.Values.SelectMany(e=> e.Errors.Select(a => a.ErrorMessage)) });
            }

            var result = await _mediator.Send(command);
            return result != null ?
                (IActionResult)CreatedAtAction(nameof(Get), new { id = result.IdClient }, result)
                : BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(ClientLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel { Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage)) });
            }

            var tokenResult = await _loginService.Login(model);
            if (tokenResult == null)
            {
                return BadRequest("Invalid login or password");
            }

            return Ok(tokenResult);
        }
    }
}