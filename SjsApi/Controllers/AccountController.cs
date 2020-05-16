using System.Security.Claims;
using System.Security.Principal;

namespace SjsApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SjsApi.Security;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="AccountController" />.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="Task{ClaimsPrincipal}"/>.</returns>
        [HttpGet]
        [Route("user")]
        public async Task<dynamic> Get()
        {
            return await Task.FromResult(new
            {
                Username = User.Identity.Name,
                IsAdministrator = User.IsInRole(Roles.Administrator),
                IsContentEditor = User.IsInRole(Roles.ContentEditor),
                Claims = User.Claims.Select(x => new
                {
                    ClaimType = x.Type,
                    ClaimValue = x.Value
                })
            });
        }
    }
}
