using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API.V1
{
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Buildings.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new BuildingGetQuery(id);

            var result = await _mediator.Send(query);

            return Response(result);
        }

        [HttpGet(ApiRoutes.Buildings.GetAll)]
        public async Task<IActionResult> GetAll(string city, string street, int? streetNumberStart,
            int? streetNumberEnd, bool? even)
        {
            var query = new BuildingGetAllQuery(city, street, streetNumberStart, streetNumberEnd, even);

            var result = await _mediator.Send(query);

            return Response(result);
        }
        private IActionResult Response(IResponseModel result)
        {
            return result switch
            {
                SuccessResponse _ => Ok(result),
                NotFoundResponse _ => NotFound(result),
                ErrorResponse _ => BadRequest(result),
                InternalError _ => StatusCode(500, result),
                _ => NotFound()
            };
        }
    }
}