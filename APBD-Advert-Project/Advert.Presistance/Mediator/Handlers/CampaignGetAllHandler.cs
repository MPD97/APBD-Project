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
    public class CampaignGetAllHandler : IRequestHandler<CampaignGetAllQuery, IEnumerable<Campaign>>
    {
        public Task<IEnumerable<Campaign>> Handle(CampaignGetAllQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
