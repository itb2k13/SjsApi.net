using SjsApi.Models;
using System.Threading.Tasks;

namespace SjsApi.Lib.Providers
{
    public interface IContentSectionProvider
    {
        Task<ContentSection> GetContentSection(string path);

        Task<ContentSection> SetContentSection(string path, ContentSection content);

        Task<Project> GetProjectDetail(string path, string projectTitle);
    }
}