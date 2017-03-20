using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.Jira.Service;

namespace CECode.Business.Services
{
    /// <summary>
    /// Adapter for JiraService
    /// </summary>
    public class CEJiraService : CECode.Business.Services.ICEJiraService
    {
        #region fields
        private IJiraService _service;
        #endregion

        #region ctor
        public CEJiraService(string url, string userName, string password)
        {
            _service = new JiraService(url, userName, password);
        }
        public CEJiraService(IJiraService service)
        {
            _service = service;
        }
        #endregion

        #region public methods
        public CEJiraIssue GetItem(string key)
        {
            var issue = _service.GetIssue(key);
            return JiraItemAdapter.Translate(issue);
        }

        public IList<CEJiraIssue> GetOpenItems(IList<string> projects)
        {
            var issues = _service.GetOpenIssues(projects);
            return JiraItemAdapter.Translate(issues);
        }

        public IList<CEJiraIssue> GetRAndDIssues()
        {
            var issues = _service.GetRAndDIssues();
            return JiraItemAdapter.Translate(issues);
        }

        public IList<CEJiraIssue> GetAMSIssues()
        {
            var issues = _service.GetAMSIssues();
            return JiraItemAdapter.Translate(issues);
        }

        public IList<CEJiraIssue> GetByJql(string jql)
        {
            var issues = _service.GetByJql(jql);
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
