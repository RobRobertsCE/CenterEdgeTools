using System;
using System.Collections.Generic;

namespace CECode.Business
{
    internal class CEPullRequest : ICEPullRequest
    {
        #region properties
        public long Id { get; set; }
        public int Number { get; set; }
        public string Sha { get; set; }
        public string Repo { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public string Head { get; set; }
        public string Base { get; set; }
        public string HeadRef { get; set; }
        public string BaseRef { get; set; }
        public string MergeCommitSha { get; set; }

        public string Status { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsMergeable { get; set; }
        public bool IsMerged { get; set; }
        public bool IsReviewed { get; set; }
        public DateTime? MergedAt { get; set; }
        public string MergedBy { get; set; }

        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int ChangedFiles { get; set; }

        public string PatchUrl { get; set; }
        public string DiffUrl { get; set; }
        public string HtmlUrl { get; set; }
        public string Url { get; set; }

        public string User { get; set; }

        public int CommentCount { get; set; }
        public int CommitCount { get; set; }

        public IList<ICECommit> Commits { get; set; }
        public IList<ICEBuild> Builds { get; set; } 
        #endregion

        #region ctor
        public CEPullRequest()
        {
            Commits = new List<ICECommit>();
            Builds = new List<ICEBuild>();
        } 
        #endregion
    }
}
