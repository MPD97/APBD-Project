using System.Linq;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API.V1
{
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Clients.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new ClientGetAllQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.Clients.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new ClientGetQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Clients.Create)]
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
        [HttpPost(ApiRoutes.Clients.LogIn)]
        public async Task<IActionResult> LogIn(ClientLoginCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel { Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage)) });
            }

            var tokenResult = await _mediator.Send(command);
            if (tokenResult == null)
            {
                return BadRequest("Invalid login or password");
            }

            return Ok(tokenResult);
        }
        [HttpPost(ApiRoutes.Clients.Refresh)]
        public async Task<IActionResult> RefreshToken(ClientRefreshTokenCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel { Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage)) });
            }

            var tokenResult = await _mediator.Send(command);
            if (tokenResult == null)
            {
                return BadRequest("Invalid token or refresh token");
            }

            return Ok(tokenResult);
        }
    }
}