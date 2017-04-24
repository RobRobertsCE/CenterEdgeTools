using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business
{
    internal class CECommitComment : CECode.Business.ICECommitComment
    {
        // Summary:
        //     Details about the repository comment.
        public string Body { get; set; }
        //
        // Summary:
        //     The commit
        public string CommitId { get; set; }
        //
        // Summary:
        //     The date the repository comment was created.
        public DateTimeOffset CreatedAt { get; set; }
        //
        // Summary:
        //     The html URL for this repository comment.
        public Uri HtmlUrl { get; set; }
        //
        // Summary:
        //     The issue comment Id.
        public int Id { get; set; }
        //
        // Summary:
        //     The line number in the file that was commented on.
        public int? Line { get; set; }
        //
        // Summary:
        //     Relative path of the file that was commented on.
        public string Path { get; set; }
        //
        // Summary:
        //     Line index in the diff that was commented on.
        public int? Position { get; set; }
        //
        // Summary:
        //     The date the repository comment was last updated.
        public DateTimeOffset? UpdatedAt { get; set; }
        //
        // Summary:
        //     The URL for this repository comment.
        public Uri Url { get; set; }
        //
        // Summary:
        //     The user that created the repository comment.
        public string User { get; set; }
    }
}
