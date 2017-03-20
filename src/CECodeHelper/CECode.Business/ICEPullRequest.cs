using System;
using System.Collections.Generic;
namespace CECode.Business
{
    public interface ICEPullRequest
    {
        string Branch { get; set; }
        int CommentCount { get; set; }
        int CommitCount { get; set; }
        IList<ICECommit> Commits { get; set; }
        long Id { get; set; }
        bool IsMerged { get; set; }
        bool IsOnHold { get; set; }
        bool IsReviewed { get; set; }
        int Number { get; set; }
        string Repo { get; set; }
        string Sha { get; set; }
        string Status { get; set; }
        string Title { get; set; }
    }
}
