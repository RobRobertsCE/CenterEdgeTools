using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business
{
    public class CEWorkItem
    {
        public ICEJiraIssue JiraIssue { get; set; }

        public IList<ICEPullRequest> PullRequests { get; set; }

        public IList<CEBranch> Branches { get; set; }

        public IList<CEBuild> Builds { get; set; }

        public CEWorkItem()
        {
            PullRequests = new List<ICEPullRequest>();
            Branches = new List<CEBranch>();
            Builds = new List<CEBuild>();
        }
    }
}
