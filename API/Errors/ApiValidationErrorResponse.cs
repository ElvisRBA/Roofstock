using System.Collections.Generic;

namespace API.Errors
{
    // In this class I'm shapping the errors if I got an array of them
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}