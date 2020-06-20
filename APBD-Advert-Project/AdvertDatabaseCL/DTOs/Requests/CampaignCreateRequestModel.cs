using System;

namespace Advert.Database.DTOs.Requests
{
    public class CampaignCreateRequestModel
    {
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PricePerSquareMeter { get; set; } = 35;
        public int FromIdBuilding { get; set; }
        public int ToIdBuilidng { get; set; }
    }
}