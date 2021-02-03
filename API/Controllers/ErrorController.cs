using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // This controller manages the client attempts to hit an endpoint that doesn't exist in the API and I still want to return
    // The same consistent response even for requests that are not being handled by the controllers directly.
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}