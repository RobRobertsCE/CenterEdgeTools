using System;
using System.Collections.Generic;
using System.Linq;
using Atlassian.Jira;

namespace CECode.Jira.Service
{
    public class JiraService : IJiraService
    {
        #region fields
        private Atlassian.Jira.Jira _jira;
        #endregion

        #region ctor
        public JiraService(string url, string userName, string password)
        {
            _jira = Atlassian.Jira.Jira.CreateRestClient(url, userName, password);
        }
        #endregion

        #region public methods
        public Issue GetIssue(string key)
        {
            return _jira.GetIssue(key);
        }

        public IList<Issue> GetOpenIssues(IList<string> projects)
        {
            var projectList = String.Join(",", projects);
            return _jira.GetIssuesFromJql("project in (" + projectList + ") AND issuetype in standardIssueTypes()", 50, 0).ToList();
        }

        public IList<Issue> GetIssues(IList<string> projects, int count, int start)
        {
            var projectList = String.Join(",", projects);
            return _jira.GetIssuesFromJql("project in (" + projectList + ") AND issuetype in standardIssueTypes()", count, start).ToList();
        }

        public IList<Issue> GetRAndDIssues()
        {
            return _jira.GetIssuesFromJql("project in (WEB, ADVANTAGE, AAC, MOBILETIK, MOBILEINV) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"R&D\" OR type = Epic) ORDER BY Rank ASC", 100, 0).ToList();
         }

        public IList<Issue> GetAMSIssues()
        {
            // var issueList = _jira.GetIssuesFromJql("project in (ADVANTAGE) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"AMS\" OR type = Epic) AND (Updated > -1d) ORDER BY Rank ASC", 100, 0);
            return _jira.GetIssuesFromJql("project in (ADVANTAGE) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"AMS\" OR type = Epic) ORDER BY Rank ASC", 100, 0).ToList();            
        }

        public IList<Issue> GetInProgressIssues()
        {
            // var issueList = _jira.GetIssuesFromJql("project in (ADVANTAGE) AND status in (Open, \"In Progress\", Closed, QA, \"QA Approved\") AND (cf[11200] = \"AMS\" OR type = Epic) AND (Updated > -1d) ORDER BY Rank ASC", 100, 0);
            return _jira.GetIssuesFromJql("project IN (ADVANTAGE) AND sprint IN OpenSprints() AND status IN (\"In Progress\", QA) AND (cf[11200] IN (\"AMS\", \"R&D\")) ORDER BY created DESC", 100, 0).ToList();
        }

        public IList<Issue> GetByJql(string jql)
        {
            return _jira.GetIssuesFromJql(jql, 100, 0).ToList();
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
        #endregion

        #region private methods
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
        #endregion
    }
}
