using System;

namespace CECode.Business.Services
{
    public enum RequestState
    {
        Open = 0,
        Closed = 1,
        All = 2
    }

    public class PullRequestSearchArgs
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string Branch { get; set; }
        public string Repository { get; set; }
        public RequestState State { get; set; }
        public DateTime? UpdatedSince { get; set; }
        public string JiraKey { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int PageSize { get; set; }

        public PullRequestSearchArgs()
        {
            State = RequestState.All;
            Id = -1;
            Number = -1;
            PageCount = 1;
            StartPage = 1;
            PageSize = 50;
        }
    }
}
