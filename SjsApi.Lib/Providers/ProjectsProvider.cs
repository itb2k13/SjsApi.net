using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SjsApi.Models;

namespace SjsApi.Lib.Providers
{
    /// <summary>
    ///     Defines the <see cref="ProjectsProvider" />.
    /// </summary>
    public class ProjectsProvider : IProjectsProvider
    {
        /// <summary>
        ///     Defines the _config.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectsProvider" /> class.
        /// </summary>
        /// <param name="config">The config<see cref="IConfiguration" />.</param>
        public ProjectsProvider(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        ///     The GetProjects.
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{Project}}" />.</returns>
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await Task.FromResult(_config.GetSection("Projects").Get<List<Project>>());
        }
    }
}