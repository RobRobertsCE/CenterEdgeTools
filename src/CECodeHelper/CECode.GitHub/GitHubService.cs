using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.BranchHelper;
using Octokit;

namespace CECode.GitHub
{
    public class GitHubService
    {
        #region events
        public event EventHandler NewPullRequests;
        void OnNewPullRequest()
        {
            EventHandler handler = NewPullRequests;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler GetPullRequestsComplete;
        void OnGetPullRequestsComplete()
        {
            EventHandler handler = GetPullRequestsComplete;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        #endregion

        #region fields
        private readonly string _user;
        private readonly string _token;
        private readonly string _owner;
        // TODO: Move to parameter
        IList<string> _jiraIssuePrefixes = new List<string>() { "ADVANTAGE", "WEB", "SITEINFO", "ONLINE", "MOBILEINV", "MOBILETIK", "CST" };
        #endregion

        #region properties
        private GitHubClient _client = null;
        public GitHubClient Client
        {
            get
            {
                if (null == _client)
                {
                    _client = new GitHubClient(new ProductHeaderValue("CE.GitHub.Helper"));
                    _client.Credentials = new Credentials(_user, _token);
                }
                return _client;
            }
        }
        private IList<PullRequestView> _pullRequests = new List<PullRequestView>();
        public IList<PullRequestView> PullRequests
        {
            get
            {
                return _pullRequests;
            }
        }
        #endregion

        #region ctor
        public GitHubService(string user, string token, string owner)
        {
            _user = user;
            _token = token;
            _owner = owner;
        }
        #endregion

        #region public
        public async Task<IList<PullRequestView>> GetRequests(IList<string> repoNames)
        {
            return await GetRequests(null, 0, repoNames);
        }
        public async Task<IList<PullRequestView>> GetRequests(ItemState? state, IList<string> repoNames)
        {
            return await GetRequests(state, 0, repoNames);
        }
        public async Task<IList<PullRequestView>> GetRequests(ItemState? state, int daysBack, IList<string> repoNames)
        {
            return await GetRequests(state, new DateRange(DateTime.Now.AddDays(-1 * daysBack), SearchQualifierOperator.GreaterThanOrEqualTo), repoNames);
        }
        public async Task<IList<PullRequestView>> GetRequests(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            var requestTask = GetPullRequestViews(state, searchDates, repoNames);
            await requestTask;

            if (requestTask.IsCompleted)
            {
                if (!requestTask.IsFaulted)
                {
                    return requestTask.Result;
                }
                else
                {
                    Console.WriteLine(requestTask.Exception.ToString());
                }
            }

            return null;
        }
        #endregion

        #region private
        async Task<IList<PullRequestView>> GetPullRequestViews(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            try
            {
                var hasNewRequests = false;

                var searchResults = await SearchPullRequests(state, searchDates, repoNames);

                // Gets general info on each Pull Request.
                var existingRequestIds = PullRequests.Select(r => r.Id).ToList();

                foreach (var request in searchResults.Items)
                {
                    //var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');

                    var pullRequest = PullRequests.FirstOrDefault(r => r.Id == request.Number);
                    if (null == pullRequest)
                    {
                        try
                        {
                            pullRequest = GetNewPullRequestView(request);
                            // Get detailed info on each Pull Request.
                            pullRequest = await GetPullRequestDetails(request, pullRequest);

                            PullRequests.Add(pullRequest);
                            if (pullRequest.State == ItemState.Open)
                                hasNewRequests = true;
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler(ex);
                        }

                    }
                    else // already had a copy in our list.. update it
                    {
                        existingRequestIds.Remove(request.Number);
                        if (pullRequest.Updated != request.UpdatedAt.GetValueOrDefault())
                        {
                            pullRequest = await GetPullRequestDetails(request, pullRequest);
                        }
                        //if (pullRequest.JiraIssues.Count == 0)
                        //{
                        //    pullRequest = await GetPullRequestDetails(request, pullRequest);
                        //}
                    }
                }

                foreach (var requestToRemove in PullRequests.Where(r => existingRequestIds.Contains(r.Id)).ToList())
                {
                    PullRequests.Remove(requestToRemove);
                }

                if (hasNewRequests)
                    OnNewPullRequest();

                OnGetPullRequestsComplete();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
                throw;
            }

            return PullRequests;
        }
        async Task GetPullRequestViewsByJiraNumber(ItemState? state, DateRange searchDates, IList<string> repoNames, string jiraIssueNumber)
        {
            try
            {
                var hasNewRequests = false;

                var searchResults = await SearchPullRequests(state, searchDates, repoNames, jiraIssueNumber);

                // Gets general info on each Pull Request.
                var existingRequestIds = PullRequests.Select(r => r.Id).ToList();

                foreach (var request in searchResults.Items)
                {
                    var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');

                    var pullRequest = PullRequests.FirstOrDefault(r => r.Id == request.Number);
                    if (null == pullRequest)
                    {
                        pullRequest = GetNewPullRequestView(request);
                        // Get detailed info on each Pull Request.
                        pullRequest = await GetPullRequestDetails(request, pullRequest);

                        PullRequests.Add(pullRequest);
                        if (pullRequest.State == ItemState.Open)
                            hasNewRequests = true;
                    }
                    else // already had a copy in our list.. update it
                    {
                        existingRequestIds.Remove(request.Number);
                        if (pullRequest.Updated != request.UpdatedAt.GetValueOrDefault())
                        {
                            pullRequest = await GetPullRequestDetails(request, pullRequest);
                        }
                        //if (pullRequest.JiraIssues.Count == 0)
                        //{
                        //    pullRequest = await GetPullRequestDetails(request, pullRequest);
                        //}
                    }
                }

                foreach (var requestToRemove in PullRequests.Where(r => existingRequestIds.Contains(r.Id)).ToList())
                {
                    PullRequests.Remove(requestToRemove);
                }

                if (hasNewRequests)
                    OnNewPullRequest();

                OnGetPullRequestsComplete();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        PullRequestView GetNewPullRequestView(Octokit.Issue request)
        {
            var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');
            var newRequest = new PullRequestView()
            {
                RepoName = repositoryName,
                Title = request.Title,
                Id = request.Number,
                Created = request.CreatedAt,
                Updated = request.UpdatedAt.GetValueOrDefault(),
                State = request.State,
                Developer = request.User.Login,
                JiraIssues = GetJiraIssues(request, repositoryName), //TODO: Get Commits, Comments, etc?
                Tag = request
            };

            return newRequest;
        }

        async Task<PullRequestView> GetPullRequestDetails(Octokit.Issue request, PullRequestView pullRequest)
        {
            var pullRequestDetails = await Client.Repository.PullRequest.Get(_owner, pullRequest.RepoName, pullRequest.Id);

            pullRequest.Branch = pullRequestDetails.Base.Ref;
            pullRequest.RepoBranch = BranchVersionHelper.Map.GetRepoBranch(pullRequest.Branch);
            if (null != pullRequest.RepoBranch)
                pullRequest.Version = pullRequest.RepoBranch.Version;
            pullRequest.Mergeable = pullRequestDetails.Mergeable;
            pullRequest.Merged = pullRequestDetails.Merged;
            pullRequest.ChangedFileCount = pullRequestDetails.ChangedFiles;
            pullRequest.State = pullRequestDetails.State;
            pullRequest.CommitCount = pullRequestDetails.Commits;
            // "Make children syncable from Advantage 16.6(REVNU-1326)" - throws error, thinks it is ADVANTAGE-16 JIRA issue
          
            pullRequest = await UpdateCommits(request, pullRequest, pullRequestDetails.Head.Sha);

            return pullRequest;
        }

        async Task<PullRequestView> UpdateCommits(Octokit.Issue request, PullRequestView pullRequest, string sha)
        {
            var commitTask = await Client.Repository.Commit.Get(_owner, pullRequest.RepoName, sha);

            if (null != commitTask)
            {
                pullRequest.Commits.Add(commitTask);

                pullRequest.HasDbUpgrade = commitTask.Files.Any(f => f.Filename.Contains("AdvUpgrade"));
                pullRequest.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));

                pullRequest.Files = commitTask.Files.Select(f => f.Filename).ToList();

                var advantagePatchBuilder = new PullRequestAssembyHelper(pullRequest, "rroberts");
                pullRequest.AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
            }

            return pullRequest;
        }

        async Task<SearchIssuesResult> SearchPullRequests(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            SearchIssuesRequest searchRequest = new SearchIssuesRequest()
            {
                // only search pull requests
                Type = IssueTypeQualifier.PullRequest,
                State = state,
                Updated = searchDates
            };

            foreach (var repoName in repoNames)
            {
                searchRequest.Repos.Add(String.Format(@"{0}/{1}", _owner, repoName));
            }

            return await Client.Search.SearchIssues(searchRequest);
        }

        async Task<SearchIssuesResult> SearchPullRequests(ItemState? state, DateRange searchDates, IList<string> repoNames, string jiraIssueNumber)
        {
            // Documentation: http://octokitnet.readthedocs.org/en/latest/search/
            SearchIssuesRequest request = new SearchIssuesRequest(jiraIssueNumber)
            {
                // only search pull requests
                Type = IssueTypeQualifier.PullRequest,
                State = state,
                Updated = searchDates
            };

            // if you're searching for a specific term, you can
            // focus your search on specific criteria
            request.In = new[] {
                    IssueInQualifier.Title,
                    IssueInQualifier.Body
                };

            foreach (var repoName in repoNames)
            {
                request.Repos.Add(String.Format(@"{0}/{1}", _owner, repoName));
            }

            return await Client.Search.SearchIssues(request);
        }

        IList<string> GetJiraIssues(Octokit.Issue request, string repoName)
        {
            string titleAndBody = String.Empty;
            if (request.Title.Contains("…"))
            {
                titleAndBody = request.Title.Replace("…", "");
            }
            else
            {
                titleAndBody = request.Title;
            }
            if (request.Body.Contains("…"))
            {
                titleAndBody += request.Body.Replace("…", "");
            }
            else
            {
                titleAndBody += request.Body;
            }

            return GetJiraIssueNumbers(titleAndBody);
        }

        IList<string> GetJiraIssueNumbers(string body)
        {
            var issueNumbers = new List<string>();
            var foundKey = false;

            foreach (var repoName in _jiraIssuePrefixes)
            {
                var tokenLength = repoName.Length;

                body = body.ToUpper();

                if (body.Contains(repoName + "-"))
                {
                    foundKey = true;
                    for (int i = 0; i < body.Length - tokenLength; i++)
                    {
                        if (body.Substring(i, tokenLength) == repoName)
                        {
                            var issueNumberBuffer = String.Empty;
                            var nextIdx = 0;
                            // add 1 for the '-' character. (Sometimes it is a different character, so we don't hard-code it.)
                            var textSection = body.Substring(i + tokenLength + 1);
                            while (GetNumberValue(textSection, ref issueNumberBuffer, ref nextIdx))
                            {
                                if (!String.IsNullOrEmpty(issueNumberBuffer))
                                {
                                    var issueKey = String.Format("{0}-{1}", repoName, issueNumberBuffer);
                                    if (!issueNumbers.Contains(issueKey))
                                        issueNumbers.Add(issueKey);
                                }

                                if ("," == body.Substring(nextIdx + i + tokenLength - 1, 1))
                                {
                                    textSection = body.Substring(nextIdx + i + tokenLength);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (!foundKey)
            {
                Console.WriteLine("######################## Did not find JIRA issue key! #################### ");
                Console.WriteLine(body);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            return issueNumbers.Where(i => !String.IsNullOrEmpty(i)).ToList();
        }

        bool GetNumberValue(string buffer, ref string numberValue, ref int nextIdx)
        {
            int digitLength = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                var digitBuffer = buffer.Substring(i, 1);
                if (digitBuffer != " ")
                {
                    if (!digitBuffer.All(Char.IsDigit))
                    {
                        numberValue = buffer.Substring(i - digitLength, digitLength).Trim();
                        nextIdx = i + 1;
                        return true;
                    }
                }
                digitLength++;
            }
            return false;
        }
        #endregion

        #region common
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw ex;
        }
        #endregion
    }
}
