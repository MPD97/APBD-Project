using Advert.Database.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientResponseModel>>
    {
    }
}
