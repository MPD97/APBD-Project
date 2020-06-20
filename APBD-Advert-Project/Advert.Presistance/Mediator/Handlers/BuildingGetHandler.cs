using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.IBuildingQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class BuildingGetHandler : IRequestHandler<BuildingGetQuery, BuildingResponseModel>
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly IMapper _mapper;

        public BuildingGetHandler(IBuildingQueryService buildingQueryService, IMapper mapper)
        {
            _buildingQueryService = buildingQueryService;
            _mapper = mapper;
        }

        public async Task<BuildingResponseModel> Handle(BuildingGetQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingQueryService.GetAsync(request.BuildingId);

            return _mapper.Map<BuildingResponseModel>(building);
        }
    }
}