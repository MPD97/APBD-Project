namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class NotFoundResponse<T> : IResponseModel<T> where T : class
    {
        private NotFoundResponse()
        {
        }

        public NotFoundResponse(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public T Result { get; set; } = null;
    }
}