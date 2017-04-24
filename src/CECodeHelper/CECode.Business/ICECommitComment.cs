using System;
namespace CECode.Business
{
    public interface ICECommitComment
    {
        string Body { get; }
        string CommitId { get; }
        DateTimeOffset CreatedAt { get; }
        Uri HtmlUrl { get; }
        int Id { get; }
        int? Line { get; }
        string Path { get; }
        int? Position { get; }
        DateTimeOffset? UpdatedAt { get; }
        Uri Url { get; }
        string User { get; }
    }
}
