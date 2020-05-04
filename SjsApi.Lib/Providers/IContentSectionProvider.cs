using System.Collections.Generic;
using System.Threading.Tasks;
using SjsApi.Models;

namespace SjsApi.Lib.Providers
{
    public interface IContentSectionProvider
    {
        Task<ContentSection> GetContentSection(string path);
    }
}