using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API
{
    [ApiController]
    [Authorize]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Campaigns.Get)]
        public async Task<IActionResult> Get(int id) 
        {
            var query = new CampaignGetQuery(id);

            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Campaigns.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new CampaignGetAllQuery();

            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet(ApiRoutes.Campaigns.Create)]
        public async Task<IActionResult> Create(CampaignCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}