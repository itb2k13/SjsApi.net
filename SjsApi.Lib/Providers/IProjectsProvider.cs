using System.Collections.Generic;
using System.Threading.Tasks;
using SjsApi.Models;

namespace SjsApi.Lib.Providers
{
    public interface IProjectsProvider
    {
        Task<IEnumerable<Project>> GetProjects();
    }
}