using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advert.Database.DTOs.Requests
{
    public class ClientRegisterCommand
    {
        [Required]
        [MinLength(2), MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [MinLength(6), MaxLength(15)]
        public string Login { get; set; }

        [Required]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }

    }

}
