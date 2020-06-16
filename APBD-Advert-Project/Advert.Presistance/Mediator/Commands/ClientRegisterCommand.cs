using Advert.Database.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advert.Database.DTOs.Requests
{
    public class ClientRegisterCommand: ClientRegisterRequestModel, IRequest<ClientResponseModel>
    {

    }
}
