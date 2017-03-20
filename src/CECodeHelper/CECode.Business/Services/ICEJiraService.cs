using System;
namespace CECode.Business.Services
{
    public interface ICEJiraService
    {
        System.Collections.Generic.IList<CECode.Business.CEJiraIssue> GetAMSIssues();
        System.Collections.Generic.IList<CECode.Business.CEJiraIssue> GetByJql(string jql);
        System.Collections.Generic.IList<string> GetFilters();
        CECode.Business.CEJiraIssue GetItem(string key);
        System.Collections.Generic.IList<CECode.Business.CEJiraIssue> GetOpenItems(System.Collections.Generic.IList<string> projects);
        System.Collections.Generic.IList<string> GetPriorities();
        System.Collections.Generic.IList<string> GetProjects();
        System.Collections.Generic.IList<CECode.Business.CEJiraIssue> GetRAndDIssues();
        System.Collections.Generic.IList<string> GetStatuses();
        System.Collections.Generic.IList<string> GetTypes();
    }
}
