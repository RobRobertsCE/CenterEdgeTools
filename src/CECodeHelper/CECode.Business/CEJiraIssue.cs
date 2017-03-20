using System;
using System.Collections.Generic;
using CECode.Jira;

namespace CECode.Business
{
    public class CEJiraIssue : ICEJiraIssue
    {
        public string ItemNumber { get; set; }

        public string ProjectName { get; set; }

        public string Key { get; set; }

        public string Summary { get; set; }

        public JiraPriority Priority { get; set; }

        public JiraStatus ItemStatus { get; set; }

        public JiraIssueType ItemType { get; set; }

        public IList<string> AffectsVersions { get; set; }

        public IList<string> FixVersions { get; set; }

        public string Team { get; set; }

        public string Sprint { get; set; }

        public string AssignedTo { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public CEJiraIssue()
        {
            AffectsVersions = new List<string>();
            FixVersions = new List<string>();
        }
    }

    internal class JiraItemAdapter
    {
        public static IList<CEJiraIssue> Translate(IEnumerable<Atlassian.Jira.Issue> jiraIssues)
        {
            IList<CEJiraIssue> JiraItems = new List<CEJiraIssue>();
            foreach (var entity in jiraIssues)
            {
                JiraItems.Add(Translate(entity));
            }
            return JiraItems;
        }

        public static CEJiraIssue Translate(Atlassian.Jira.Issue jiraIssue)
        {
            CEJiraIssue item = new CEJiraIssue()
            {
                Key = jiraIssue.Key.ToString(),
                ItemNumber = jiraIssue.JiraIdentifier,
                ProjectName = jiraIssue.Project,
                ItemStatus = (JiraStatus)Convert.ToInt32(jiraIssue.Status.Id),
                ItemType = (JiraIssueType)Convert.ToInt32(jiraIssue.Type.Id),
                Created = jiraIssue.Created,
                Updated = jiraIssue.Updated,
                Priority = (JiraPriority)Convert.ToInt32(jiraIssue.Priority.Id),
                Summary = jiraIssue.Summary,
                AssignedTo = String.IsNullOrEmpty(jiraIssue.Assignee) ? "" : jiraIssue.Assignee.ToString(),
            };

            item.Team = GetCustomFieldValue("Team", jiraIssue);

            item.Sprint = GetCustomFieldValue("Sprint", jiraIssue);

            foreach (var version in jiraIssue.AffectsVersions)
            {
                item.AffectsVersions.Add(version.Name.ToString());
            }

            foreach (var version in jiraIssue.FixVersions)
            {
                item.FixVersions.Add(version.Name.ToString());
            }

            //PopulateDetails(item, jiraIssue);

            //switch (item.ItemType)
            //{
            //    case JiraIssueType.UserStory:
            //        {
            //            PopulateUserStoryDetails(item, jiraIssue);
            //            break;
            //        }
            //    case JiraIssueType.Epic:
            //        {
            //            PopulateEpicDetails(item, jiraIssue);
            //            break;
            //        }
            //    default:
            //        {
            //            PopulateDetails(item, jiraIssue);
            //            break;
            //        }
            //}

            return item;
        }

        private static string GetCustomFieldValue(string name, Atlassian.Jira.Issue jiraIssue)
        {
            var fieldValue = jiraIssue.CustomFields[name];
            if (null != fieldValue)
            {
                if (null != fieldValue.Values[0])
                    return fieldValue.Values[0].ToString();
                else
                    return "";
            }
            else
                return "";
        }

        private static void PopulateUserStoryDetails(CEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateEpicDetails(CEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateDetails(CEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }
    }
}
