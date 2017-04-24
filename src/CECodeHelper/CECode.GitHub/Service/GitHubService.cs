using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CECode.Logging;
using Octokit;

namespace CECode.GitHub.Service
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
            return await GetPullRequestInternal(repositoryName, number);
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

        public async Task<IReadOnlyList<PullRequest>> SearchPullRequests(string repositoryName, PullRequestRequest request, ApiOptions options)
        {
            return await SearchPullRequestsInternal(repositoryName, request, options);
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

        public async Task<IReadOnlyList<PullRequestCommit>> GetPullRequestCommits(string repositoryName, int number)
        {
            var result = await GetPullRequestCommitsInternal(repositoryName, number);
            return result;
        }
        public async Task<IReadOnlyList<PullRequestReviewComment>> GetPullRequestComments(string repositoryName, int number)
        {
            var result = await GetPullRequestCommentsInternal(repositoryName, number);
            return result;
        }
        #endregion
        #endregion

        #region private
        #region branches
        private async Task<IReadOnlyList<Branch>> GetBranchList(string repoName)
        {
            return await Client.Repository.Branch.GetAll(_owner, repoName);
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
        private async Task<IReadOnlyList<PullRequest>> SearchPullRequestsInternal(string repositoryName, PullRequestRequest request, ApiOptions options)
        {
            return await Client.Repository.PullRequest.GetAllForRepository(_owner, repositoryName, request, options);
        }

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
            return await Client.Repository.PullRequest.Get(_owner, repositoryName, number); ;
        }

        private async Task<IReadOnlyList<PullRequestCommit>> GetPullRequestCommitsInternal(string repositoryName, int number)
        {
            return await Client.Repository.PullRequest.Commits(_owner, repositoryName, number);
        }

        private async Task<IReadOnlyList<CommitComment>> GetPullRequestCommentsInternal(string repositoryName, string sha)
        {
            var comments = await Client.Repository.Comment.GetAllForCommit(_owner, repositoryName, sha);
            return comments;
        }
        
        private async Task<IReadOnlyList<PullRequestReviewComment>> GetPullRequestCommentsInternal(string repositoryName, int number)
        {
            var comments = await Client.Repository.PullRequest.ReviewComment.GetAll(_owner, repositoryName, number);
            return comments;
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
        #endregion
    }
}
