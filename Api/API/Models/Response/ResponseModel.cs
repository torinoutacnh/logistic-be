namespace API.Models.Response
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public object? AdditionalData { get; set; }
        public string? Message { get; set; }

        public ResponseModel(T? data, object? additionalData = null, string? message = null)
        {
            Data = data;
            AdditionalData = additionalData;
            Message = message;
        }
    }
}
