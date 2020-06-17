using AdvertDatabaseCL.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Entities
{
    public class Campaign
    {
        public int IdCampaign { get; set; }
        public int IdClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public int FromIdBuilding { get; set; }
        public int ToIdBuilding { get; set; }

        public virtual Client Client { get; set; }
        public virtual Building FromBuilding { get; set; }
        public virtual Building ToBuilding { get; set; }

        public virtual ICollection<Banner> Banners { get; set; }
    }
}
