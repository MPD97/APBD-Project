namespace Advert.Database.DTOs.Responses
{
    public class CampaignCreateResponse
    {
        public Banner Banner1 { get; set; }
        public Banner Banner2 { get; set; }

        public decimal TotalSquareMeters { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public decimal TotalPrice { get; set; }

        public class Banner
        {
            public decimal Width { get; set; }
            public decimal Height { get; set; }
            public decimal SquareMeters { get; set; }
            public decimal Price { get; set; }
        }
    }
}