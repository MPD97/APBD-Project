using System.Collections.Generic;

namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class ErrorResponse
    {
        public IEnumerable<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }

    public class ErrorModel
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}