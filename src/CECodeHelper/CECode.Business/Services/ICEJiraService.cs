using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICEJiraService
    {
        IList<CEJiraIssue> GetAMSIssues();
        IList<CEJiraIssue> GetByJql(string jql);
        IList<string> GetFilters();
        CEJiraIssue GetItem(string key);
        IList<CEJiraIssue> GetOpenItems(IList<string> projects);
        IList<string> GetPriorities();
        IList<string> GetProjects();
        IList<CEJiraIssue> GetRAndDIssues();
        IList<string> GetStatuses();
        IList<string> GetTypes();
    }
}
