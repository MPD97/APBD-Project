using Advert.Database.DTOs.Responses;
using Advert.Presistance.Mediator.Handlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Queries
{
    public class GetClientQuery : IRequest<ClientResponseModel>
    {
        public GetClientQuery(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
      
    }
}
