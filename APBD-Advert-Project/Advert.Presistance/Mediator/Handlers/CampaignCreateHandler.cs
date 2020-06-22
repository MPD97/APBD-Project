using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Commands;
using Advert.Presistance.Services.IBannerCalculate;
using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.ICampaignCreate;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignCreateHandler : IRequestHandler<CampaignCreateCommand, IResponseModel>
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


        public async Task<IResponseModel> Handle(CampaignCreateCommand request,
            CancellationToken cancellationToken)
        {
            // TODO: Logs
            var fromBuilding = await _buildingQueryService.FindAsync(request.FromIdBuilding);
            var toBuilding = await _buildingQueryService.FindAsync(request.ToIdBuilding);

            if (fromBuilding.City != toBuilding.City)
                return new BadRequestResponse("The buildings must be in the same city.");

            if (fromBuilding.Street != toBuilding.Street)
                return new BadRequestResponse("The buildings must be on the same street.");

            if (toBuilding.StreetNumber % 2 == 0 != (fromBuilding.StreetNumber % 2 == 0))
                return new BadRequestResponse("The buildings must be on the same side of the road.");

            if (fromBuilding.StreetNumber > toBuilding.StreetNumber)
                return new BadRequestResponse("FromIdBuilding must have smaller street number than ToIdBuilding.");

            if (fromBuilding.StreetNumber == toBuilding.StreetNumber)
                return new BadRequestResponse("The buildings must have different street number.");

            var buildings = _buildingQueryService.GetAll(fromBuilding.City, fromBuilding.Street,
                fromBuilding.IdBuilding, toBuilding.IdBuilding,
                toBuilding.StreetNumber % 2 == 0);

            var calculation = await _bannerCalculateService.Calculate(buildings.ToList(), request.PricePerSquareMeter);
            if (calculation == null)
                return new InternalError("The calculation task could not be completed.");

            var result = await _campaignCreateService.CreateAsync(request, calculation);
            if (result == null)
                return new InternalError("The campaign could not be created.");

            return new SuccessResponse("Campaign has been created.", calculation);
        }
    }
}