using Advert.Database.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Handlers
{
    public class GetClientHandler : IRequest<ClientResponseModel>
    {
        public GetClientHandler(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}
