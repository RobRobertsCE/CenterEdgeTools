using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.Business.Adapters;
using CECode.Jira.Service;

namespace CECode.Business.Services
{
    /// <summary>
    /// Adapter for JiraService
    /// </summary>
    internal class CEJiraService : CECode.Business.Services.ICEJiraService
    {
        #region fields
        private IJiraService _service;
        #endregion

        #region ctor
        internal CEJiraService(string url, string userName, string password)
        {
            _service = new JiraService(url, userName, password);
        }
        internal CEJiraService(IJiraService service)
        {
            _service = service;
        }
        #endregion

        #region public methods
        public ICEJiraIssue GetItem(string key)
        {
            var issue = _service.GetIssue(key);
            return JiraItemAdapter.Translate(issue);
        }

        public IList<ICEJiraIssue> GetOpenItems(IList<string> projects)
        {
            var issues = _service.GetOpenIssues(projects);
            return JiraItemAdapter.Translate(issues);
        }

        public IList<ICEJiraIssue> GetItems(string jiraProjectName, int count, int start)
        {
            var issues = _service.GetIssues(new List<string>() { jiraProjectName }, count, start);
            return JiraItemAdapter.Translate(issues);
        }

        public IList<ICEJiraIssue> GetRAndDIssues()
        {
            var issues = _service.GetRAndDIssues();
            return JiraItemAdapter.Translate(issues);
        }

        public IList<ICEJiraIssue> GetAMSIssues()
        {
            var issues = _service.GetAMSIssues();
            return JiraItemAdapter.Translate(issues);
        }

        public IList<ICEJiraIssue> GetByJql(string jql)
        {
            var issues = _service.GetByJql(jql, 50, 0);
            return JiraItemAdapter.Translate(issues);
        }
        public IList<ICEJiraIssue> GetInProgressIssues()
        {
            var issues = _service.GetInProgressIssues();
            return JiraItemAdapter.Translate(issues);
        }

        public IList<string> GetProjects()
        {
            return _service.GetProjects();
        }

        public IList<string> GetFilters()
        {
            return _service.GetFilters();
        }

        public IList<string> GetTypes()
        {
            return _service.GetTypes();
        }

        public IList<string> GetStatuses()
        {
            return _service.GetStatuses();
        }

        public IList<string> GetPriorities()
        {
            return _service.GetPriorities();
        }
        #endregion
    }
}
