namespace SjsApi.Lib.Providers
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using SjsApi.Models;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ContentSectionProvider" />.
    /// </summary>
    public class ContentSectionProvider : IContentSectionProvider
    {
        /// <summary>
        /// Defines the _config.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Defines the _provider.
        /// </summary>
        private readonly IMlabProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSectionProvider"/> class.
        /// </summary>
        /// <param name="config">The config<see cref="IConfiguration" />.</param>
        /// <param name="provider">The provider<see cref="IMlabProvider"/>.</param>
        public ContentSectionProvider(IConfiguration config, IMlabProvider provider)
        {
            _provider = provider;
            _config = config;
        }

        /// <summary>
        /// The GetContentSection.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}" />.</returns>
        public async Task<ContentSection> GetContentSection(string path)
        {
            return await _provider.Get(path);
        }

        /// <summary>
        /// The SetContentSection.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="content">The content<see cref="ContentSection"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        public async Task<ContentSection> SetContentSection(string path, ContentSection content)
        {
            return await _provider.Set(path, content);
        }

        /// <summary>
        /// The GetProjectDetail.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="projectTitle">The projectTitle<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{Project}"/>.</returns>
        public async Task<Project> GetProjectDetail(string path, string projectTitle)
        {
            var content = await GetContentSection(path);

            return content.Projects?
                    .Where(n => n.Title == projectTitle)?
                    .FirstOrDefault();
        }
    }
}
