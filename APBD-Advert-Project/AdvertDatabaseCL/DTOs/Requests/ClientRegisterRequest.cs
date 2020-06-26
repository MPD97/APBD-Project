using System.ComponentModel.DataAnnotations;

namespace Advert.Database.DTOs.Requests
{
    public class ClientRegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)] public string Password { get; set; }

        [DataType(DataType.Password)] public string RepeatPassword { get; set; }
    }
}