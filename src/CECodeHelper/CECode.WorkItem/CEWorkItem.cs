using System.Collections.Generic;

namespace CECode.Business
{
    internal class CEWorkItem : ICEWorkItem
    {
        #region properties
        public IList<ICEJiraIssue> JiraIssues { get; set; }
        public ICEPullRequest PullRequest { get; set; }        
        #endregion

        #region ctor
        public CEWorkItem()
        {            
            JiraIssues = new List<ICEJiraIssue>();
        }
        #endregion
    }
}
