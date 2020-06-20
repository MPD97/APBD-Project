using System;
using System.Threading.Tasks;
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using Advert.Presistance.Services.IBuildingQuery;
using Advert.Presistance.Services.IClientQuery;
using AutoMapper;

namespace Advert.Presistance.Services.ICampaignCreate
{
    public class CampaignCreateService : ICampaignCreateService
    {
        private readonly IBuildingQueryService _buildingQueryService;
        private readonly IClientQueryService _clientQueryService;

        private readonly IMapper _mapper;

        public CampaignCreateService(IBuildingQueryService buildingQueryService, IMapper mapper)
        {
            _buildingQueryService = buildingQueryService;
            _mapper = mapper;
        }

        public async Task<Campaign> CreateAsync(CampaignCreateRequestModel model,
            CampaignCreateResponseModel.Banner[] banner)
        {
            if (banner.Length != 2) return null;

            var campaign = _mapper.Map<Campaign>(model);

            var client = await _clientQueryService.GetAsync(model.ClientId);
            if (client == null) return null;

            var fromBuilding = await _buildingQueryService.GetAsync(model.FromIdBuilding);
            if (fromBuilding == null) return null;

            var toBuilding = await _buildingQueryService.GetAsync(model.ToIdBuilidng);
            if (toBuilding == null) return null;

            throw new NotImplementedException();
        }
    }
}