using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SjsApi.Lib.Providers;
using SjsApi.Models;
using System.Threading.Tasks;

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
        public async Task<ContentSection> Get(string section, string path)
        {
            return await _contentSectionProvider.GetContentSection($"{section}/{path}");
        }

        [HttpGet]
        [Route("{section}/{path}/{title}")]
        public async Task<Project> Get(string section, string path, string title)
        {
            return await _contentSectionProvider.GetProjectDetail($"{section}/{path}", title);
        }
    }
}