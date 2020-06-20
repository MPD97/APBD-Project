using System;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IBuildingQuery;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignCreateHandler : IRequestHandler<CampaignCreateCommand, CampaignCreateResponseModel>
    {
        private readonly IBuildingQueryService _buildingQueryService;

        public CampaignCreateHandler(IBuildingQueryService buildingQueryService)
        {
            _buildingQueryService = buildingQueryService;
        }

        public async Task<CampaignCreateResponseModel> Handle(CampaignCreateCommand request,
            CancellationToken cancellationToken)
        {
            var fromBuilding = await _buildingQueryService.GetAsync(request.FromIdBuilding);
            var toBuilding = await _buildingQueryService.GetAsync(request.ToIdBuilidng);

            if (fromBuilding.City != toBuilding.City) return null; // City must be the same.

            if (fromBuilding.Street != toBuilding.Street) return null; // Street must be the same.

            if (fromBuilding.StreetNumber % toBuilding.StreetNumber != 0)
                return null; // Cant place banner across the road.

            if (fromBuilding.StreetNumber > toBuilding.StreetNumber)
                return null; // FromCity street number must be befeore toCity street number 

            if (fromBuilding.StreetNumber == toBuilding.StreetNumber) return null; // Buildings must be different

            throw new NotImplementedException();
        }
    }
}