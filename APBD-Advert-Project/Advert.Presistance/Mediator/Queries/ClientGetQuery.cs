using Advert.Database.DTOs.Responses;
using Advert.Database.DTOs.Responses.ResponseModel;
using MediatR;

namespace Advert.Presistance.Mediator.Queries
{
    public class ClientGetQuery : IRequest<IResponseModel>
    {
        public ClientGetQuery(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}