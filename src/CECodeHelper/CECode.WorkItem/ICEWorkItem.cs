using System;
using System.Collections.Generic;

namespace CECode.Business
{
    public interface ICEWorkItem
    {
        IList<ICEJiraIssue> JiraIssues { get; set; }
        ICEPullRequest PullRequest { get; set; }
    }
}
