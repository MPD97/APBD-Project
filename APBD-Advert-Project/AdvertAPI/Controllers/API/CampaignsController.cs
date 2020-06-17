using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}