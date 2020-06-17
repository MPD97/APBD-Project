using Advert.Presistance.Mediator.Queries;
using AdvertDatabaseCL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class CampaignGetHandler : IRequestHandler<GetCampaignQuery, Campaign>
    {
        public Task<Campaign> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
