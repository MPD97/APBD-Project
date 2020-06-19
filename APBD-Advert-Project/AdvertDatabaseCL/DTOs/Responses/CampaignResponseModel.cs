using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Responses
{
    public class CampaignResponseModel
    {
        public int IdCampaign { get; set; }
        public int IdClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public int FromIdBuilding { get; set; }
        public int ToIdBuilding { get; set; }
    }
}
