﻿namespace Advert.Database.DTOs.Requests
{
    public class BannerCreateRequestModel
    {
        public int Name { get; set; }
        public decimal Price { get; set; }
        public int IdCampaign { get; set; }
        public decimal Area { get; set; }
    }
}