using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.DTOs.Responses
{
    public class ErrorResponseModel
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
