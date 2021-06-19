using Microsoft.Extensions.Configuration;

namespace SjsApi.Lib.Providers
{
    using MongoDB.Driver;
    using SjsApi.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="MlabProvider" />.
    /// </summary>
    public class MlabProvider : IMlabProvider
    {
        /// <summary>
        /// Defines the _collection.
        /// </summary>
        private readonly IMongoCollection<ContentSection> _collection;

        private IConfiguration _config;

        /// <summary>
        /// The _pathFilter.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="FilterDefinition{ContentSection}"/>.</returns>
        private FilterDefinition<ContentSection> PathFilter(string path)
        {
            return Builders<ContentSection>.Filter.Eq("Path", path);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MlabProvider"/> class.
        /// </summary>
        public MlabProvider(IConfiguration config)
        {
            _config = config;
            var client = new MongoClient(config.GetConnectionString("mlab.com"));
            var database = client.GetDatabase("SjsApi");
            _collection = database.GetCollection<ContentSection>("ContentSections");
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        public async Task<ContentSection> Get(string path)
        {
            var result = await _collection.Find(PathFilter(path)).FirstOrDefaultAsync();
            return result ?? new ContentSection() { Path = path };
        }

        /// <summary>
        /// The Add.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="content">The content<see cref="ContentSection"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        public async Task<ContentSection> Add(string path, ContentSection content)
        {
            await _collection.InsertOneAsync(content);
            return await Get(path);
        }

        /// <summary>
        /// The Set.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="content">The content<see cref="ContentSection"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        public async Task<ContentSection> Set(string path, ContentSection content)
        {
            await _collection.ReplaceOneAsync(PathFilter(path), content, new ReplaceOptions() { IsUpsert = true });
            return await Get(path);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> Delete(string path)
        {
            var result = await _collection.DeleteManyAsync(PathFilter(path));
            return result.IsAcknowledged;
        }
    }
}
