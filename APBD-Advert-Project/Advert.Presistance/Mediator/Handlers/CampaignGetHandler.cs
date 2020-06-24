using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.ICampaignQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignGetHandler : IRequestHandler<CampaignGetQuery, IResponseModel<CampaignResponseModel>>
    {
        private readonly ICampaignQueryService _campaignQueryService;
        private readonly IMapper _mapper;

        public CampaignGetHandler(ICampaignQueryService campaignQueryService, IMapper mapper)
        {
            _campaignQueryService = campaignQueryService;
            _mapper = mapper;
        }

        public async Task<IResponseModel<CampaignResponseModel>> Handle(CampaignGetQuery request,
            CancellationToken cancellationToken)
        {
            var campaign = await _campaignQueryService.FindAsync(request.CampaignId);
            if (campaign == null)
                return new NotFoundResponse<CampaignResponseModel>("No campaigns could be found with this id");

            return new SuccessResponse<CampaignResponseModel>(_mapper.Map<CampaignResponseModel>(campaign));
        }
    }
}