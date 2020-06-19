using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignCreateHandler : IRequestHandler<CampaignCreateCommand, CampaignCreateResponseModel>
    {
        public Task<CampaignCreateResponseModel> Handle(CampaignCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
