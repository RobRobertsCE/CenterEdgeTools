using System;
using CECode.Jira;
using System.Collections.Generic;

namespace CECode.Business
{
    public interface ICEJiraIssue
    {
        IList<string> AffectsVersions { get; set; }
        string AssignedTo { get; set; }
        DateTime? Created { get; set; }
        IList<string> FixVersions { get; set; }
        string ItemNumber { get; set; }
        JiraStatus ItemStatus { get; set; }
        JiraIssueType ItemType { get; set; }
        string Key { get; set; }
        JiraPriority Priority { get; set; }
        string ProjectName { get; set; }
        string Sprint { get; set; }
        string Summary { get; set; }
        string Team { get; set; }
        DateTime? Updated { get; set; }
    }
}
