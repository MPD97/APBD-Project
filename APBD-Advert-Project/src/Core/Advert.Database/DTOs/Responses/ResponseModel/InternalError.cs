namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class InternalError<T> : IResponseModel<T> where T : class
    {
        private InternalError()
        {
        }

        public InternalError(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public T Result { get; set; } = null;
    }
}