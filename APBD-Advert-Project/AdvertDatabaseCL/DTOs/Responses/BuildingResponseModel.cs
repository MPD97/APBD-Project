namespace Advert.Database.DTOs.Responses
{
    public class BuildingResponseModel
    {
        public int IdBuilding { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public decimal Height { get; set; }
    }
}