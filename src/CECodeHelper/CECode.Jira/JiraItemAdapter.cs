using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Jira
{
    internal class JiraItemAdapter
    {
        public static IList<JiraItem> Translate(IEnumerable<Atlassian.Jira.Issue> jiraIssues)
        {
            IList<JiraItem> JiraItems = new List<JiraItem>();
            foreach (var entity in jiraIssues)
            {
                JiraItems.Add(Translate(entity));
            }
            return JiraItems;
        }

        public static JiraItem Translate(Atlassian.Jira.Issue jiraIssue)
        {
            JiraItem item = new JiraItem()
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

        private static void PopulateUserStoryDetails(JiraItem item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateEpicDetails(JiraItem item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateDetails(JiraItem item, Atlassian.Jira.Issue jiraIssue)
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
