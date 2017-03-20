using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business
{
    public class CEPullRequest : ICEPullRequest
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string Sha { get; set; }
        public string Repo { get; set; }
        public string Branch { get; set; }
        public string Title { get; set; }
        
        public string Status { get; set; }
        public bool IsOnHold { get; set; }
        public bool IsMerged { get; set; }
        public bool IsReviewed { get; set; }

        public int CommentCount { get; set; }
        public int CommitCount { get; set; }

        public IList<ICECommit> Commits { get; set; }

        public CEPullRequest()
        {
            Commits = new List<ICECommit>();
        }
    }
}
