namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class ErrorResponse : IResponseModel
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
    public class NotFoundResponse : IResponseModel
    {
        public NotFoundResponse(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
}