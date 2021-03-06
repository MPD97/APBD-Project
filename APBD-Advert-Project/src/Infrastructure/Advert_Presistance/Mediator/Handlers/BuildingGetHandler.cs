﻿using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IBuildingQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class BuildingGetHandler : IRequestHandler<BuildingGetQuery, IResponseModel<BuildingResponse>>
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly IMapper _mapper;

        public BuildingGetHandler(IBuildingQueryService buildingQueryService, IMapper mapper)
        {
            _buildingQueryService = buildingQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel<BuildingResponse>> Handle(BuildingGetQuery request,
            CancellationToken cancellationToken)
        {
            var building = await _buildingQueryService.FindAsync(request.BuildingId);

            if (building == null)
                return new NotFoundResponse<BuildingResponse>("No buildings could be found with this id");

            return new SuccessResponse<BuildingResponse>(_mapper.Map<BuildingResponse>(building));
        }
    }
}