using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Responses
{
    public class CampaignCreateResponseModel
    {
        public Banner Banner1 { get; set; }
        public Banner Banner2 { get; set; }
        public decimal TotalPrice { get; set; }

        public class Banner
        {
            public decimal Width { get; set; }
            public decimal Height { get; set; }
        }
    }

}
