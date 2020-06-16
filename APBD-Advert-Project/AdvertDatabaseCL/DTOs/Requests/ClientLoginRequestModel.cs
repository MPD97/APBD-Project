using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advert.Database.DTOs.Requests
{
    public class ClientLoginRequestModel
    {
        [Required]
        [MinLength(6), MaxLength(15)]
        public string Login { get; set; }

        [Required]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
