using System;
using System.Collections.Generic;
using CECode.Jira;

namespace CECode.Business
{
    internal class JiraItemAdapter
    {
        #region public methods
        public static IList<ICEJiraIssue> Translate(IEnumerable<Atlassian.Jira.Issue> jiraIssues)
        {
            IList<ICEJiraIssue> JiraItems = new List<ICEJiraIssue>();
            foreach (var entity in jiraIssues)
            {
                JiraItems.Add(Translate(entity));
            }
            return JiraItems;
        }

        public static ICEJiraIssue Translate(Atlassian.Jira.Issue jiraIssue)
        {
            ICEJiraIssue item = new CEJiraIssue()
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

            //PopulateDetails(item, build);

            //switch (item.ItemType)
            //{
            //    case JiraIssueType.UserStory:
            //        {
            //            PopulateUserStoryDetails(item, build);
            //            break;
            //        }
            //    case JiraIssueType.Epic:
            //        {
            //            PopulateEpicDetails(item, build);
            //            break;
            //        }
            //    default:
            //        {
            //            PopulateDetails(item, build);
            //            break;
            //        }
            //}

            return item;
        } 
        #endregion

        #region private methods
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

        private static void PopulateUserStoryDetails(ICEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateEpicDetails(ICEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        }

        private static void PopulateDetails(ICEJiraIssue item, Atlassian.Jira.Issue jiraIssue)
        {
            Console.WriteLine(jiraIssue.Type.Name);
            foreach (var field in jiraIssue.CustomFields)
            {
                Console.WriteLine(field.Id + ":" + field.Name + ":" + field.Values[0].ToString());
            }
            Console.WriteLine();
        } 
        #endregion
    }
}
