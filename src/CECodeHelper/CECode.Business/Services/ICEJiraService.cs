using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICEJiraService
    {
        IList<ICEJiraIssue> GetAMSIssues();
        IList<ICEJiraIssue> GetByJql(string jql);
        IList<string> GetFilters();
        ICEJiraIssue GetItem(string key);
        IList<ICEJiraIssue> GetOpenItems(IList<string> projects);
        IList<ICEJiraIssue> GetItems(string jiraProjectName, int count, int start);
        IList<ICEJiraIssue> GetInProgressIssues();
        IList<string> GetPriorities();
        IList<string> GetProjects();
        IList<ICEJiraIssue> GetRAndDIssues();
        IList<string> GetStatuses();
        IList<string> GetTypes();
    }
}
