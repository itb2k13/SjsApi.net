using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SjsApi.Lib.Providers;

namespace SjsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        IUtilityProvider _utilityProvider;
        
        public BaseController(IUtilityProvider utilityProvider)
        {
            _utilityProvider = utilityProvider;
        }
    }
}