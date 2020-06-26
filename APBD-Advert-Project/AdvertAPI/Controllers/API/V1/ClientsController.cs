using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
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
        public async Task<IActionResult> GetAll([FromQuery] ClientGetAllQuery query)
        {
            var result = await _mediator.Send(query);

            return Response(result);
        }

        [HttpGet(ApiRoutes.Clients.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new ClientGetQuery(id);

            var result = await _mediator.Send(query);

            return Response(result);
        }

        [HttpPost(ApiRoutes.Clients.Create)]
        public async Task<IActionResult> Create(ClientRegisterCommand command)
        {
            var result = await _mediator.Send(command);

            return result switch
            {
                SuccessResponse<ClientResponse> _ => StatusCode(201, result),
                NotFoundResponse<ClientResponse> _ => NotFound(result),
                BadRequestResponse<ClientResponse> _ => BadRequest(result),
                InternalError<ClientResponse> _ => StatusCode(500, result),
                _ => NotFound()
            };
        }

        [HttpPost(ApiRoutes.Clients.LogIn)]
        public async Task<IActionResult> LogIn(ClientLoginCommand command)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(new ErrorResponse
            //         {Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage))});

            var result = await _mediator.Send(command);

            return Response(result);
        }

        [HttpPost(ApiRoutes.Clients.Refresh)]
        public async Task<IActionResult> RefreshToken(ClientRefreshTokenCommand command)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(new ErrorResponse
            //         {Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage))});

            var result = await _mediator.Send(command);

            return Response(result);
        }

        private IActionResult Response<T>(IResponseModel<T> result) where T : class
        {
            return result switch
            {
                SuccessResponse<T> _ => Ok(result),
                NotFoundResponse<T> _ => NotFound(result),
                BadRequestResponse<T> _ => BadRequest(result),
                InternalError<T> _ => StatusCode(500, result),
                _ => NotFound()
            };
        }
    }
}