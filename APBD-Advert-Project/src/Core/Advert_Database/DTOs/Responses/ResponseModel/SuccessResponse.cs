namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class SuccessResponse<T> : IResponseModel<T> where T : class
    {
        private SuccessResponse()
        {
        }

        public SuccessResponse(T result)
        {
            Result = result;
        }

        public SuccessResponse(string message, T result)
        {
            Message = message;
            Result = result;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Ok;
        public string Message { get; set; }
        public T Result { get; set; }
    }
}