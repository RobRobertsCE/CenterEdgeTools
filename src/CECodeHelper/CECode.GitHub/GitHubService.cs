using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.BranchHelper;
using Octokit;

namespace CECode.GitHub
{
    public class GitHubService : IGitHubService
    {
        #region fields
        private readonly string _user;
        private readonly string _token;
        private readonly string _owner;
        // TODO: Move
        private IList<string> _jiraIssuePrefixes = new List<string>() { "ADVANTAGE", "WEB", "SITEINFO", "ONLINE", "MOBILEINV", "MOBILETIK", "CST" };
        #endregion

        #region properties
        private GitHubClient _client = null;
        protected virtual GitHubClient Client
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
        protected virtual IList<PullRequestView> PullRequests
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

        #region common
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw ex;
        }
        #endregion

        #region public
        #region pull requests
        public async Task<PullRequest> GetPullRequest(string repositoryName, int number)
        {
            return await GetPullRequestInternal( repositoryName, number);
        }
        public async Task<IReadOnlyList<PullRequest>> GetPullRequests(string repositoryName, string branchName)
        {
            return await GetPullRequests(null, repositoryName, branchName);
        }
        public async Task<IReadOnlyList<PullRequest>> GetPullRequests(ItemState? state, string repositoryName, string branchName)
        {
            return await GetPullRequestsInBranch(state, repositoryName, branchName);
        }

        public async Task<SearchIssuesResult> SearchPullRequests(string repositoryName, string jiraIssueKey)
        {
            return await SearchPullRequestsInternal(repositoryName, jiraIssueKey);
        }
        public async Task<SearchIssuesResult> SearchPullRequests(IList<string> repositoryNames)
        {
            return await SearchPullRequestsInternal(ItemState.Open, repositoryNames);
        }
        public async Task<SearchIssuesResult> SearchPullRequests(ItemState? state, IList<string> repositoryNames)
        {
            return await SearchPullRequestsInternal(state, repositoryNames);
        }
        public async Task<SearchIssuesResult> SearchPullRequests(ItemState? state, DateRange updatedDateRange, IList<string> repositoryNames)
        {
            return await SearchPullRequestsInternal(state, updatedDateRange, repositoryNames);
        }
        #endregion

        #region branches
        public async Task<IReadOnlyList<Branch>> GetBranches(string repositoryName)
        {
            return await GetBranchList(repositoryName);
        }
        #endregion

        #region commits
        public async Task<IReadOnlyList<GitHubCommit>> GetCommits(string repositoryName, string branchName)
        {
            var result = await GetCommitsByBranch(repositoryName, branchName);
            return result;
        }
        public async Task<CompareResult> CheckCommitInBranch(string repositoryName, string branchName, string sha)
        {
            var result = await CheckCommit(repositoryName, branchName, sha);
            return result;
        }
        public async Task<GitHubCommit> GetPullRequestCommits(string repositoryName, string sha)
        {
            var result = await GetPullRequestCommitsInternal(repositoryName, sha);
            return result;
        }
        #endregion
        #endregion

        #region private
        #region branches
        private async Task<IReadOnlyList<Branch>> GetBranchList(string repoName)
        {
            return await Client.Repository.GetAllBranches(_owner, repoName);
        }
        #endregion

        #region commits
        private async Task<IReadOnlyList<GitHubCommit>> GetCommitsByBranch(string repositoryName, string branchName)
        {
            var commitRequest = new CommitRequest
              {
                  Sha = branchName,
                  Since = null,
                  Until = null
              };

            var options = new ApiOptions
            {
                PageCount = 1,
                StartPage = 1,
                PageSize = 50
            };

            IReadOnlyList<GitHubCommit> commits = await Client.Repository.Commit.GetAll(_owner, repositoryName, commitRequest, options);

            return commits;
        }

        private async Task<CompareResult> CheckCommit(string repositoryName, string branchName, string headCommit)
        {
            CompareResult result = await Client.Repository.Commit.Compare(_owner, repositoryName, branchName, headCommit);

            return result;
        }

        private async Task<GitHubCommit> GetPullRequestCommitsInternal(string repositoryName, string sha)
        {
            return await Client.Repository.Commit.Get(_owner, repositoryName, sha);
        }

        #endregion

        #region pull requests
        private async Task<IReadOnlyList<PullRequest>> GetPullRequestsInBranch(ItemState? state, string repositoryName, string branchName)
        {
            var request = new PullRequestRequest
            {
                State = state.HasValue ? ((ItemStateFilter)state) : ItemStateFilter.All,
                Base = branchName,
            };

            var options = new ApiOptions
            {
                PageCount = 1,
                StartPage = 1,
                PageSize = 50
            };

            return await GetPullRequestsInBranch(request, repositoryName, options);
        }

        private async Task<IReadOnlyList<PullRequest>> GetPullRequestsInBranch(PullRequestRequest request, string repositoryName, ApiOptions options)
        {
            return await Client.Repository.PullRequest.GetAllForRepository(_owner, repositoryName, request, options);
        }
        private async Task<PullRequest> GetPullRequestInternal(string repositoryName, int number)
        {
            return await Client.Repository.PullRequest.Get(_owner, repositoryName, number);
        }

        private async Task<SearchIssuesResult> SearchPullRequestsInternal(ItemState? state, IList<string> repositorynames)
        {
            SearchIssuesRequest searchRequest = new SearchIssuesRequest()
            {
                Type = IssueTypeQualifier.PullRequest,
                State = state
            };

            foreach (var repositoryName in repositorynames)
            {
                searchRequest.Repos.Add(String.Format(@"{0}/{1}", _owner, repositoryName));
            }

            return await Client.Search.SearchIssues(searchRequest);
        }
        private async Task<SearchIssuesResult> SearchPullRequestsInternal(ItemState? state, DateRange searchDates, IList<string> repositorynames)
        {
            SearchIssuesRequest searchRequest = new SearchIssuesRequest()
            {
                Type = IssueTypeQualifier.PullRequest,
                State = state,
                Updated = searchDates
            };

            foreach (var repositoryName in repositorynames)
            {
                searchRequest.Repos.Add(String.Format(@"{0}/{1}", _owner, repositoryName));
            }

            return await Client.Search.SearchIssues(searchRequest);
        }
        private async Task<SearchIssuesResult> SearchPullRequestsInternal(string repositoryName, string jiraIssueNumber)
        {
            SearchIssuesRequest request = new SearchIssuesRequest(jiraIssueNumber)
            {
                Type = IssueTypeQualifier.PullRequest
            };

            request.In = new[] {
                            IssueInQualifier.Title,
                            IssueInQualifier.Body
                        };

            request.Repos.Add(String.Format(@"{0}/{1}", _owner, repositoryName));

            var results = await Client.Search.SearchIssues(request);

            return results;
        }
        #endregion

        //#region pull request views
        //// ####################################################

        //private async Task<IList<PullRequestView>> GetPullRequestViews(ItemState? state, DateRange searchDates, IList<string> repoNames)
        //{
        //    try
        //    {
        //        var hasNewRequests = false;

        //        var searchResults = await SearchPullRequests(state, searchDates, repoNames);

        //        // Gets general info on each Pull Request.
        //        var existingRequestIds = PullRequests.Select(r => r.Id).ToList();

        //        foreach (var request in searchResults.Items)
        //        {
        //            //var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');

        //            var pullRequest = PullRequests.FirstOrDefault(r => r.Id == request.Number);
        //            if (null == pullRequest)
        //            {
        //                try
        //                {
        //                    pullRequest = GetNewPullRequestView(request);
        //                    // Get detailed info on each Pull Request.
        //                    pullRequest = await GetPullRequestDetails(request, pullRequest);

        //                    PullRequests.Add(pullRequest);
        //                    if (pullRequest.State == ItemState.Open)
        //                        hasNewRequests = true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    ExceptionHandler(ex);
        //                }

        //            }
        //            else // already had a copy in our list.. update it
        //            {
        //                existingRequestIds.Remove(request.Number);
        //                if (pullRequest.Updated != request.UpdatedAt.GetValueOrDefault())
        //                {
        //                    pullRequest = await GetPullRequestDetails(request, pullRequest);
        //                }
        //                //if (pullRequest.JiraIssues.Count == 0)
        //                //{
        //                //    pullRequest = await GetPullRequestDetails(request, pullRequest);
        //                //}
        //            }
        //        }

        //        foreach (var requestToRemove in PullRequests.Where(r => existingRequestIds.Contains(r.Id)).ToList())
        //        {
        //            PullRequests.Remove(requestToRemove);
        //        }

        //        if (hasNewRequests)
        //            OnNewPullRequest();

        //        OnGetPullRequestsComplete();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler(ex);
        //        throw;
        //    }

        //    return PullRequests;
        //}
        // //private async Task<IList<SearchIssuesResult>> GetPullRequestViewsByJiraNumber(IList<string> repoNames, string jiraIssueNumber)


        //private PullRequestView GetNewPullRequestView(Octokit.Issue request)
        //{
        //    var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');
        //    var newRequest = new PullRequestView()
        //    {
        //        RepoName = repositoryName,
        //        Title = request.Title,
        //        Id = request.Number,
        //        Created = request.CreatedAt,
        //        Updated = request.UpdatedAt.GetValueOrDefault(),
        //        State = request.State,
        //        Developer = request.User.Login,
        //        JiraIssues = GetJiraIssues(request, repositoryName),
        //        Tag = request
        //    };

        //    return newRequest;
        //}

        //private async Task<PullRequestView> GetPullRequestDetails(Octokit.Issue request, PullRequestView pullRequest)
        //{
        //    var pullRequestDetails = await Client.Repository.PullRequest.Get(_owner, pullRequest.RepoName, pullRequest.Id);

        //    pullRequest.Branch = pullRequestDetails.Base.Ref;
        //    pullRequest.RepoBranch = BranchVersionHelper.Map.GetRepoBranch(pullRequest.Branch);
        //    if (null != pullRequest.RepoBranch)
        //        pullRequest.Version = pullRequest.RepoBranch.Version;
        //    pullRequest.Mergeable = pullRequestDetails.Mergeable;
        //    pullRequest.Merged = pullRequestDetails.Merged;
        //    pullRequest.ChangedFileCount = pullRequestDetails.ChangedFiles;
        //    pullRequest.State = pullRequestDetails.State;
        //    pullRequest.CommitCount = pullRequestDetails.Commits;
        //    // "Make children syncable from Advantage 16.6(REVNU-1326)" - throws error, thinks it is ADVANTAGE-16 JIRA issue

        //    pullRequest = await UpdateCommits(request, pullRequest, pullRequestDetails.Head.Sha);

        //    return pullRequest;
        //}

        //private async Task<SearchIssuesResult> SearchPullRequestsInternal(ItemState? state, DateRange searchDates, IList<string> repoNames, string jiraIssueNumber)
        //{
        //    // Documentation: http://octokitnet.readthedocs.org/en/latest/search/
        //    SearchIssuesRequest request = new SearchIssuesRequest(jiraIssueNumber)
        //    {
        //        // only search pull requests
        //        Type = IssueTypeQualifier.PullRequest,
        //        State = state,
        //        Updated = searchDates
        //    };

        //    // if you're searching for a specific term, you can
        //    // focus your search on specific criteria
        //    request.In = new[] {
        //            IssueInQualifier.Title,
        //            IssueInQualifier.Body
        //        };

        //    foreach (var repoName in repoNames)
        //    {
        //        request.Repos.Add(String.Format(@"{0}/{1}", _owner, repoName));
        //    }

        //    return await Client.Search.SearchIssues(request);
        //}
        //#endregion

        //#region helpers
        //private IList<string> GetJiraIssues(Octokit.Issue request, string repoName)
        //{
        //    string titleAndBody = String.Empty;
        //    if (request.Title.Contains("…"))
        //    {
        //        titleAndBody = request.Title.Replace("…", "");
        //    }
        //    else
        //    {
        //        titleAndBody = request.Title;
        //    }
        //    if (request.Body.Contains("…"))
        //    {
        //        titleAndBody += request.Body.Replace("…", "");
        //    }
        //    else
        //    {
        //        titleAndBody += request.Body;
        //    }

        //    return GetJiraIssueNumbers(titleAndBody);
        //}

        //private IList<string> GetJiraIssueNumbers(string body)
        //{
        //    var issueNumbers = new List<string>();
        //    var foundKey = false;

        //    foreach (var repoName in _jiraIssuePrefixes)
        //    {
        //        var tokenLength = repoName.Length;

        //        body = body.ToUpper();

        //        if (body.Contains(repoName + "-"))
        //        {
        //            foundKey = true;
        //            for (int i = 0; i < body.Length - tokenLength; i++)
        //            {
        //                if (body.Substring(i, tokenLength) == repoName)
        //                {
        //                    var issueNumberBuffer = String.Empty;
        //                    var nextIdx = 0;
        //                    // add 1 for the '-' character. (Sometimes it is a different character, so we don't hard-code it.)
        //                    var textSection = body.Substring(i + tokenLength + 1);
        //                    while (GetNumberValue(textSection, ref issueNumberBuffer, ref nextIdx))
        //                    {
        //                        if (!String.IsNullOrEmpty(issueNumberBuffer))
        //                        {
        //                            var issueKey = String.Format("{0}-{1}", repoName, issueNumberBuffer);
        //                            if (!issueNumbers.Contains(issueKey))
        //                                issueNumbers.Add(issueKey);
        //                        }

        //                        if ("," == body.Substring(nextIdx + i + tokenLength - 1, 1))
        //                        {
        //                            textSection = body.Substring(nextIdx + i + tokenLength);
        //                        }
        //                        else
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (!foundKey)
        //    {
        //        Console.WriteLine("######################## Did not find JIRA issue key! #################### ");
        //        Console.WriteLine(body);
        //        Console.WriteLine();
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }

        //    return issueNumbers.Where(i => !String.IsNullOrEmpty(i)).ToList();
        //}

        //private bool GetNumberValue(string buffer, ref string numberValue, ref int nextIdx)
        //{
        //    int digitLength = 0;
        //    for (int i = 0; i < buffer.Length; i++)
        //    {
        //        var digitBuffer = buffer.Substring(i, 1);
        //        if (digitBuffer != " ")
        //        {
        //            if (!digitBuffer.All(Char.IsDigit))
        //            {
        //                numberValue = buffer.Substring(i - digitLength, digitLength).Trim();
        //                nextIdx = i + 1;
        //                return true;
        //            }
        //        }
        //        digitLength++;
        //    }
        //    return false;
        //}
        //#endregion
        #endregion
    }
}
