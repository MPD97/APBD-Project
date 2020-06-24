﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IBuildingQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class
        BuildingGetAllHandler : IRequestHandler<BuildingGetAllQuery, IResponseModel<IEnumerable<BuildingResponseModel>>>
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly IMapper _mapper;

        public BuildingGetAllHandler(IMapper mapper, IBuildingQueryService buildingQueryService)
        {
            _mapper = mapper;
            _buildingQueryService = buildingQueryService;
        }

        public async Task<IResponseModel<IEnumerable<BuildingResponseModel>>> Handle(BuildingGetAllQuery request,
            CancellationToken cancellationToken)
        {
            // TODO: FluentValidation
            var buildings = _buildingQueryService.GetAll(request.City, request.Street,
                request.StreetStartNumber, request.SteetEndNumber, request.Even);
            if (buildings == null || buildings.Count() == 0)
                return new NotFoundResponse<IEnumerable<BuildingResponseModel>>("No buildings could be found");

            return new SuccessResponse<IEnumerable<BuildingResponseModel>>(
                buildings.Select(_mapper.Map<Building, BuildingResponseModel>));
        }
    }
}