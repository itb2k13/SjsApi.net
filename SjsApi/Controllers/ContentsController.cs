using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SjsApi.Lib.Providers;
using SjsApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SjsApi.Security;

namespace SjsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : BaseController
    {
        private readonly IContentSectionProvider _contentSectionProvider;
        private readonly ILogger<BaseController> _logger;

        public ContentsController(IUtilityProvider utilityProvider, ILogger<ContentsController> logger, IContentSectionProvider contentSectionProvider) : base(utilityProvider)
        {
            _contentSectionProvider = contentSectionProvider;
            _logger = logger;
        }

        [HttpGet]
        [Route("{section}/{path}")]
        [AllowAnonymous]
        public async Task<ContentSection> Get(string section, string path)
        {
            return await _contentSectionProvider.GetContentSection($"{section}/{path}");
        }

        [HttpPost]
        [Route("{section}/{path}")]
        [Authorize(Roles = Roles.ContentEditors)]
        public async Task<ContentSection> Set(string section, string path, ContentSection content)
        {
            return await _contentSectionProvider.SetContentSection($"{section}/{path}", content);
        }

        [HttpGet]
        [Route("{section}/{path}/{title}")]
        [AllowAnonymous]
        public async Task<Project> Get(string section, string path, string title)
        {
            return await _contentSectionProvider.GetProjectDetail($"{section}/{path}", title);
        }
    }
}