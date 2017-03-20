using System;
namespace CECode.Business
{
    public interface ICEJiraIssue
    {
        System.Collections.Generic.IList<string> AffectsVersions { get; set; }
        string AssignedTo { get; set; }
        DateTime? Created { get; set; }
        System.Collections.Generic.IList<string> FixVersions { get; set; }
        string ItemNumber { get; set; }
        CECode.Jira.JiraStatus ItemStatus { get; set; }
        CECode.Jira.JiraIssueType ItemType { get; set; }
        string Key { get; set; }
        CECode.Jira.JiraPriority Priority { get; set; }
        string ProjectName { get; set; }
        string Sprint { get; set; }
        string Summary { get; set; }
        string Team { get; set; }
        DateTime? Updated { get; set; }
    }
}
