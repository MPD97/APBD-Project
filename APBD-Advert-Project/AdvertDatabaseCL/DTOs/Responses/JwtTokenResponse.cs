namespace Advert.Database.DTOs.Responses
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}