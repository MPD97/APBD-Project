﻿using AdvertDatabaseCL.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Mediator.Queries
{
    public class CampaignGetAllQuery : IRequest<IEnumerable<Campaign>>
    {
    }
}