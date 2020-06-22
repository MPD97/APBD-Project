namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class SuccessResponse : IResponseModel
    {
        public SuccessResponse(object result)
        {
            Result = result;
        }

        public SuccessResponse(string message, object result)
        {
            Message = message;
            Result = result;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Ok;
        public string Message { get; set; }
        public object Result { get; set; }
    }
}