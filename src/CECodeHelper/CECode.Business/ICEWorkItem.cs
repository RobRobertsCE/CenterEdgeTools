using System;
using System.Collections.Generic;

namespace CECode.Business
{
    public interface ICEWorkItem
    {
        ICEJiraIssue JiraIssue { get; set; }
        IList<ICEBranch> Branches { get; set; }
        IList<ICEBuild> Builds { get; set; }
        IList<ICEPullRequest> PullRequests { get; set; }
    }
}
