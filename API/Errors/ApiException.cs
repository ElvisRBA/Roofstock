namespace API.Errors
{
    // This class is created to extend and add extra fields to the exception I'm returning to the client. 
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}