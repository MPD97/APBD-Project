using Advert.Database.DTOs.Responses;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class ClientGetQuery : IRequest<ClientResponseModel>
    {
        public ClientGetQuery(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}