using System.Collections.Generic;

namespace Advert.Database.DTOs.Responses
{
    public class ErrorResponseModel
    {
        public IEnumerable<string> Errors { get; set; }
    }
}