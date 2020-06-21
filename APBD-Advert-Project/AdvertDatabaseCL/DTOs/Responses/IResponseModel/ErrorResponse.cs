namespace Advert.Database.DTOs.Responses
{
    public class ErrorResponse : IResponseModel
    {
        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; } = null;
        public object Result { get; set; }
    }
}