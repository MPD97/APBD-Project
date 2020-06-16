using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advert.Presistance.Mediator.Handlers
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, ClientResponseModel>
    {
        public Task<ClientResponseModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
