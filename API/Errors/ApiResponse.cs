namespace API.Errors
{
    // Making the error responses consistent so that is easy for the angular application to consume and handle the error responses.
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made A bad request",
                401 => "You are not Authorized",
                404 => "Resource was not found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}