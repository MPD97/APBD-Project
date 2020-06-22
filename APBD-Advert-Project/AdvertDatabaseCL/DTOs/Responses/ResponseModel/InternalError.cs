namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class InternalError : IResponseModel
    {
        public InternalError(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
}