using System.Collections.Generic;

namespace Advert.Database.DTOs.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}