using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public interface ICEWorkItemService
    {
        Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber);
        Task<IList<ICEWorkItem>> GetWorkItems(string gitHubRepositoryName, string jiraProjectName);
    }
}
