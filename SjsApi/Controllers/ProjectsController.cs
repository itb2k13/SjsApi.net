using Microsoft.AspNetCore.Mvc;
using SjsApi.Lib.Providers;
using SjsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SjsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IProjectsProvider _projectsProvider;
        private readonly ILogger<BaseController> _logger;

        public ProjectsController(IUtilityProvider utilityProvider, ILogger<ProjectsController> logger, IProjectsProvider projectsProvider) : base(utilityProvider)
        {
            _projectsProvider = projectsProvider;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            return await _projectsProvider.GetProjects();
        }
    }
}