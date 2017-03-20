using Atlassian.Jira;
using System;
using System.Collections.Generic;

namespace CECode.Jira.Service
{
    public interface IJiraService
    {
        Issue GetIssue(string key);
        IList<Issue> GetAMSIssues();
        IList<Issue> GetRAndDIssues();
        IList<Issue> GetByJql(string jql);
        IList<Issue> GetOpenIssues(IList<string> projects);
        IList<string> GetPriorities();
        IList<string> GetProjects();
        IList<string> GetFilters();
        IList<string> GetStatuses();
        IList<string> GetTypes();
    }
}
