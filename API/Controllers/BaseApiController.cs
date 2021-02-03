using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // This BaseApiController it's created to avoid call the ApiController and the Route attributes in every single controller I need to create. 
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}