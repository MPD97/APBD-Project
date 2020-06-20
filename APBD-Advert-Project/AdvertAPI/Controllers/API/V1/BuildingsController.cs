using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API.V1
{
    [ApiController]
    public class BuildingsController : Controller
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
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Buildings.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new BuildingGetAllQuery();

            var result = await _mediator.Send(query);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}