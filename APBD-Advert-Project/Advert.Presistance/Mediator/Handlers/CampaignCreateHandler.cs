using System;
using System.Threading;
using System.Threading.Tasks;
using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using MediatR;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignCreateHandler : IRequestHandler<CampaignCreateCommand, CampaignCreateResponseModel>
    {
        public Task<CampaignCreateResponseModel> Handle(CampaignCreateCommand request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}