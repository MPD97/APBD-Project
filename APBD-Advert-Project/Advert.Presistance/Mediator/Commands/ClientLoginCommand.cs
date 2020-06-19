using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Commands
{
    public class ClientLoginCommand : ClientLoginRequestModel, IRequest<JwtTokenResponseModel>
    {

    }
}
