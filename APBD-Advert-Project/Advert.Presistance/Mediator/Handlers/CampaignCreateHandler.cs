using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IBannerCalculate;
using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.ICampaignCreate;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignCreateHandler : IRequestHandler<CampaignCreateCommand, CampaignCreateResponseModel>
    {
        private readonly IBannerCalculateService _bannerCalculateService;
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly ICampaignCreateService _campaignCreateService;

        public CampaignCreateHandler(IBuildingQueryService buildingQueryService,
            IBannerCalculateService bannerCalculateService, ICampaignCreateService campaignCreateService)
        {
            _buildingQueryService = buildingQueryService;
            _bannerCalculateService = bannerCalculateService;
            _campaignCreateService = campaignCreateService;
        }


        public async Task<CampaignCreateResponseModel> Handle(CampaignCreateCommand request,
            CancellationToken cancellationToken)
        {
            var fromBuilding = await _buildingQueryService.GetAsync(request.FromIdBuilding);
            var toBuilding = await _buildingQueryService.GetAsync(request.ToIdBuilding);

            if (fromBuilding.City != toBuilding.City) return null; // City must be the same.

            if (fromBuilding.Street != toBuilding.Street) return null; // Street must be the same.

            if (toBuilding.StreetNumber % 2 == 0 != (fromBuilding.StreetNumber % 2 == 0))
                return null; // Cant place banner across the road.

            if (fromBuilding.StreetNumber > toBuilding.StreetNumber)
                return null; // FromCity street number must be befeore toCity street number 

            if (fromBuilding.StreetNumber == toBuilding.StreetNumber) return null; // Buildings must be different

            var buildings = _buildingQueryService.GetAll(fromBuilding.City, fromBuilding.Street,
                fromBuilding.IdBuilding, toBuilding.IdBuilding,
                toBuilding.StreetNumber % 2 == 0);

            var calculation = await _bannerCalculateService.Calculate(buildings.ToList(), request.PricePerSquareMeter);
            if (calculation == null)
                //TODO : Logs
                return null;

            var result = await _campaignCreateService.CreateAsync(request, calculation);
            if (result == null) return null;
            return calculation;
        }
    }
}