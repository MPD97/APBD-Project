﻿using System.ComponentModel.DataAnnotations;

namespace Advert.Database.DTOs.Requests
{
    public class ClientRefreshToken
    {
        [Required] public string Token { get; set; }

        [Required] public string RefreshToken { get; set; }
    }
}