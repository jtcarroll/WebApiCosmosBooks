namespace WebApiCosmosBooks.Errors
{
    public class ApiException(int status, string message, string? details)
    {
        public int StatusCode { get; set; } = status;
        public string Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}
