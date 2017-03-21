using System;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public interface ICEWorkItemService
    {
        Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber);
    }
}
