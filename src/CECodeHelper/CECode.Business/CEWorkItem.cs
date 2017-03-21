using System.Collections.Generic;

namespace CECode.Business
{
    internal class CEWorkItem : ICEWorkItem
    {
        #region properties
        public ICEJiraIssue JiraIssue { get; set; }
        public IList<ICEPullRequest> PullRequests { get; set; }
        public IList<ICEBranch> Branches { get; set; }
        public IList<ICEBuild> Builds { get; set; }
        #endregion

        #region ctor
        public CEWorkItem()
        {
            PullRequests = new List<ICEPullRequest>();
            Branches = new List<ICEBranch>();
            Builds = new List<ICEBuild>();
        }
        #endregion
    }
}
