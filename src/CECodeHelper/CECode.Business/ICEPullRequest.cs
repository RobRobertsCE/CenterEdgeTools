using System;
using System.Collections.Generic;

namespace CECode.Business
{
    public interface ICEPullRequest
    {

        int Additions { get; set; }
        string Base { get; set; }
        string Body { get; set; }
        int ChangedFiles { get; set; }
        int CommentCount { get; set; }
        int CommitCount { get; set; }
        IList<ICECommit> Commits { get; set; }
        IList<ICEBuildDetails> Builds { get; set; } 
        int Deletions { get; set; }
        string DiffUrl { get; set; }
        string HeadRef { get; set; }
        string BaseRef { get; set; }
        string Head { get; set; }
        string HtmlUrl { get; set; }
        long Id { get; set; }
        bool IsLocked { get; set; }
        bool? IsMergeable { get; set; }
        bool IsMerged { get; set; }
        bool IsReviewed { get; set; }
        string MergeCommitSha { get; set; }
        DateTime? MergedAt { get; set; }
        string MergedBy { get; set; }
        int Number { get; set; }
        string PatchUrl { get; set; }
        string Repo { get; set; }
        string Sha { get; set; }
        string Status { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        string User { get; set; }
        DateTime UpdatedAt { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ClosedAt { get; set; }
    }
}
