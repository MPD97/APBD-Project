using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using MediatR;

namespace Advert.Presistance.Mediator.Commands
{
    public class ClientLoginCommand : ClientLoginRequestModel, IRequest<JwtTokenResponseModel>
    {
    }
}