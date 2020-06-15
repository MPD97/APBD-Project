using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Responses
{
    public class ClientRegisterResponseModel
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
    }
}
