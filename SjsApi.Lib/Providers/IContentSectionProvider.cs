using SjsApi.Models;
using System.Threading.Tasks;

namespace SjsApi.Lib.Providers
{
    public interface IContentSectionProvider
    {
        Task<ContentSection> GetContentSection(string path);
        Task<Project> GetProjectDetail(string path, string projectTitle);
    }
}