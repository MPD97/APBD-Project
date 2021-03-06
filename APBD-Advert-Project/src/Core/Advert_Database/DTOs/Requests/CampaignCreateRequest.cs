﻿using System;

namespace Advert.Database.DTOs.Requests
{
    public class CampaignCreateRequest
    {
        public int IdClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; } = 35;
        public int FromIdBuilding { get; set; }
        public int ToIdBuilding { get; set; }
    }
}