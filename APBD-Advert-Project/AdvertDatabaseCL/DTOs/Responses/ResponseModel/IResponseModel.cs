namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public interface IResponseModel
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }

    public enum ResponseStatus
    {
        Uknown,
        Ok,
        Error
    }
}