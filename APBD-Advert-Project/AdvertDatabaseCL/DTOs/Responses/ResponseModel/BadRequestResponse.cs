namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public class BadRequestResponse<T> : IResponseModel<T> where T : class
    {
        public BadRequestResponse(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public T Result { get; set; } = null;
    }
}