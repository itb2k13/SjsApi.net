namespace SjsApi.Lib.Providers
{
    using Microsoft.Extensions.Configuration;
    using SjsApi.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ContentSectionProvider" />.
    /// </summary>
    public class ContentSectionProvider : IContentSectionProvider
    {
        /// <summary>
        /// Defines the _config..
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSectionProvider"/> class.
        /// </summary>
        /// <param name="config">The config<see cref="IConfiguration" />.</param>
        public ContentSectionProvider(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// The GetContentSection.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}" />.</returns>
        public async Task<ContentSection> GetContentSection(string path)
        {
            return await Task
                .FromResult(_config.GetSection("Contents").Get<IEnumerable<ContentSection>>()?
                    .FirstOrDefault(x => x.Path == path));
        }

        public async Task<Project> GetProjectDetail(string path, string projectTitle)
        {
            var content = await GetContentSection(path);

            return content.Projects?
                    .Where(n => n.Title == projectTitle)?
                    .FirstOrDefault();
        }
    }
}
