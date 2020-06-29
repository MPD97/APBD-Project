namespace Advert.Database.DTOs.Responses.ResponseModel
{
    public interface IResponseModel<T> where T : class
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }

    public enum ResponseStatus
    {
        Uknown,
        Ok,
        Error
    }
}