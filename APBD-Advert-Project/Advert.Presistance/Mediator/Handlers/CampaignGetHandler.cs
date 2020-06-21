using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using Advert.Presistance.Services.ICampaignQuery;
using AutoMapper;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignGetHandler : IRequestHandler<CampaignGetQuery, CampaignResponseModel>
    {
        private readonly ICampaignQueryService _campaignQueryService;
        private readonly IMapper _mapper;

        public CampaignGetHandler(ICampaignQueryService campaignQueryService, IMapper mapper)
        {
            _campaignQueryService = campaignQueryService;
            _mapper = mapper;
        }

        public async Task<CampaignResponseModel> Handle(CampaignGetQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _campaignQueryService.GetAsync(request.CampaignId);
            if (campaign == null) return null;
            return _mapper.Map<CampaignResponseModel>(campaign);
        }
    }
}