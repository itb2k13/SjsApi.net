using System.Threading.Tasks;
using SjsApi.Models;

namespace SjsApi.Lib.Providers
{
    public interface IMlabProvider
    {
        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        Task<ContentSection> Get(string path);

        /// <summary>
        /// The Add.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="content">The content<see cref="ContentSection"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        Task<ContentSection> Add(string path, ContentSection content);

        /// <summary>
        /// The Set.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <param name="content">The content<see cref="ContentSection"/>.</param>
        /// <returns>The <see cref="Task{ContentSection}"/>.</returns>
        Task<ContentSection> Set(string path, ContentSection content);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> Delete(string path);
    }
}