using System.ComponentModel.DataAnnotations;

namespace Advert.Database.DTOs.Requests
{
    public class ClientLoginRequest
    {
        public string Login { get; set; }

        [DataType(DataType.Password)] public string Password { get; set; }
    }
}