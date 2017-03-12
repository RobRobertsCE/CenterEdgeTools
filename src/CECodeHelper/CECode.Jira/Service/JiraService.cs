using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Jira.Service
{
    // project = ADVANTAGE ORDER BY Rank ASC

    // project in (WEB, ADVANTAGE, AAC, MOBILETIK, MOBILEINV) AND status in (Open, "In Progress", Closed, QA, "QA Approved") AND (cf[11200] = "R&D" OR type = Epic) ORDER BY Rank ASC

    // Date value '03/10/2017' for field 'Updated' is invalid. Valid formats include: 'yyyy/MM/dd HH:mm', 'yyyy-MM-dd HH:mm', 'yyyy/MM/dd', 'yyyy-MM-dd', or a period format e.g. '-5d', '4w 2d'.
    // works: project = ADVANTAGE AND updated > "2017-03-10 12:00" ORDER BY Rank ASC

    public class JiraService
    {
        private Atlassian.Jira.Jira _jira;

        public JiraService(string url, string userName, string password)
        {
            _jira = Atlassian.Jira.Jira.CreateRestClient(url, userName, password);
        }

        public JiraItem GetItem(string key)
        {
            var issueList = _jira.GetIssue(key);
            return JiraItemAdapter.Translate(issueList);
        }

        public IList<JiraItem> GetOpenItems()
        {
            var issueList = _jira.GetIssuesFromJql("project in (ADVANTAGE, WEB) AND issuetype in standardIssueTypes()", 100, 0);
            return JiraItemAdapter.Translate(issueList);
        }

        public IList<JiraItem> GetOpenItems(IList<string> projects)
        {
            var projectList = String.Join(",", projects);
            var issueList = _jira.GetIssuesFromJql("project in (" + projectList + ") AND issuetype in standardIssueTypes()", 100, 0);
            return JiraItemAdapter.Translate(issueList);
        }

        public IList<JiraItem> GetRAndDIssues()
        {
            var issueList = _jira.GetIssuesFromJql("project in (WEB, ADVANTAGE, AAC, MOBILETIK, MOBILEINV) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"R&D\" OR type = Epic) ORDER BY Rank ASC", 100, 0);
            return JiraItemAdapter.Translate(issueList);
        }

        public IList<JiraItem> GetAMSIssues()
        {
            var issueList = _jira.GetIssuesFromJql("project in (ADVANTAGE) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"AMS\" OR type = Epic) AND (Updated > #03/10/2017#) ORDER BY Rank ASC", 100, 0);
            return JiraItemAdapter.Translate(issueList);
        }

        public IList<string> GetProjects()
        {
            IList<string> projects = new List<string>();
            var items = _jira.GetProjects();
            foreach (var item in items)
            {
                projects.Add(item.Key);
            }
            return projects;
        }

        public IList<string> GetFilters()
        {
            Console.WriteLine("Filters");
            IList<string> filterNames = new List<string>();
            var items = _jira.GetFilters();
            foreach (var item in items)
            {
                filterNames.Add(item.Name.Replace(" ", ""));
                Console.WriteLine(item.Name.Replace(" ", "") + " = " + item.Id + ",");
            }
            return filterNames;
        }

        public IList<string> GetTypes()
        {
            Console.WriteLine("Types");
            IList<string> filterNames = new List<string>();
            var items = _jira.GetIssueTypes();
            foreach (var item in items)
            {
                filterNames.Add(item.Name.Replace(" ", ""));
                Console.WriteLine(item.Name.Replace(" ", "") + " = " + item.Id + ",");
            }
            return filterNames;
        }

        public IList<string> GetStatuses()
        {
            Console.WriteLine("Statuses");
            IList<string> filterNames = new List<string>();
            var items = _jira.GetIssueStatuses();
            foreach (var item in items)
            {
                filterNames.Add(item.Name.Replace(" ", ""));
                Console.WriteLine(item.Name.Replace(" ", "") + " = " + item.Id + ",");
            }
            return filterNames;
        }

        public IList<string> GetPriorities()
        {
            Console.WriteLine("Priorities");
            IList<string> filterNames = new List<string>();
            var items = _jira.GetIssuePriorities();
            foreach (var item in items)
            {
                filterNames.Add(item.Name.Replace(" ", "") + "=" + item.Id + ",");
                Console.WriteLine(item.Name.Replace(" ", "") + " = " + item.Id + ",");
            }
            return filterNames;
        }

        private void DisplayStrings(string title, IList<string> items)
        {
            Console.WriteLine(title);
            Console.WriteLine("----------------------");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
