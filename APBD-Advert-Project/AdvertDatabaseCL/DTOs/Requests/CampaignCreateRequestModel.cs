using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Requests
{
    public class CampaignCreateRequestModel
    {
        public string ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PricePerSquareMeter { get; set; } = 35;
        public int FromBuildingId { get; set; }
        public int ToBuilidngId { get; set; }
    }
}
