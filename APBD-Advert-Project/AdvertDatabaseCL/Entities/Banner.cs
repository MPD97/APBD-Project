using AdvertDatabaseCL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Configurations
{
    public class Banner
    {
        public int IdAdvertisment { get; set; }
        public int Name { get; set; }
        public decimal Price { get; set; }
        public int IdCampaign { get; set; }
        public decimal Area { get; set; }

        public Campaign Campaign { get; set; }
    }
}
