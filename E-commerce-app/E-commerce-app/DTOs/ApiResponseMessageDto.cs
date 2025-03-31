namespace E_commerce_app.DTOs
{
    public class ApiResponseMessageDto<T>
    {
        public T Date { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public object Messages { get; set; }
    }
}
