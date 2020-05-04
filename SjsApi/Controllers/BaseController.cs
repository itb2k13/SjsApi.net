using Microsoft.AspNetCore.Mvc;
using SjsApi.Lib.Providers;

namespace SjsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IUtilityProvider _utilityProvider;

        public BaseController(IUtilityProvider utilityProvider)
        {
            _utilityProvider = utilityProvider;
        }
    }
}