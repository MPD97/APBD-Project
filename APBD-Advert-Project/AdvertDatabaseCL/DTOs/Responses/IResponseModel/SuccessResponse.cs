namespace Advert.Database.DTOs.Responses
{
    public class SuccessResponse : IResponseModel
    {
        public ResponseStatus Status { get; set; } = ResponseStatus.Ok;
        public string Message { get; set; } = null;
        public object Result { get; set; }
    }
}