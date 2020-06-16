using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Responses
{
    public class JwtTokenResponseModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
