using System.Collections.Generic;

namespace Advert.Database.Entities
{
    public class Building
    {
        public int IdBuilding { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public decimal Height { get; set; }

        public virtual ICollection<Campaign> CampaignsFrom { get; set; }
        public virtual ICollection<Campaign> CampaignsTo { get; set; }
    }
}