using Microsoft.AspNetCore.Mvc;
using Middleware.BaseClass;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public BaseResponse __response = new();

    }
}
