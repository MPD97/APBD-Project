using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IBuildingQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class BuildingGetAllHandler : IRequestHandler<BuildingGetAllQuery, IEnumerable<BuildingResponseModel>>
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly IMapper _mapper;

        public BuildingGetAllHandler(IMapper mapper, IBuildingQueryService buildingQueryService)
        {
            _mapper = mapper;
            _buildingQueryService = buildingQueryService;
        }


        public async Task<IEnumerable<BuildingResponseModel>> Handle(BuildingGetAllQuery request,
            CancellationToken cancellationToken)
        {
            var buildings = await _buildingQueryService.GetAllAsync();
            if (buildings == null) return null;

            return buildings.Select(_mapper.Map<Building, BuildingResponseModel>);
        }
    }
}