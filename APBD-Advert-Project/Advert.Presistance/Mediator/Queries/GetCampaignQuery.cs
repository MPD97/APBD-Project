using AdvertDatabaseCL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Queries
{
    public class GetCampaignQuery :IRequest<Campaign>
    {
    }
}
