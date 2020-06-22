﻿using System.Linq;
using System.Threading.Tasks;
using Advert.API.Contracts.V1;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advert.API.Controllers.API.V1
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

            return Response(result);
        }

        [HttpGet(ApiRoutes.Campaigns.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new CampaignGetAllQuery();

            var result = await _mediator.Send(query);

            return Response(result);
        }

        [HttpPost(ApiRoutes.Campaigns.Create)]
        public async Task<IActionResult> Create(CampaignCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponseModel
                    {Errors = ModelState.Values.SelectMany(e => e.Errors.Select(a => a.ErrorMessage))});

            var result = await _mediator.Send(command);

            return Response(result);
        }

        private IActionResult Response(IResponseModel result)
        {
            return result switch
            {
                SuccessResponse _ => Ok(result),
                NotFoundResponse _ => NotFound(result),
                BadRequestResponse _ => BadRequest(result),
                InternalError _ => StatusCode(500, result),
                _ => NotFound()
            };
        }
    }
}