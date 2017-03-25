using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CECode.GitHub.Service;
using Octokit;

namespace CECode.Business.Services
{
    /// <summary>
    /// Adapter class for GitHubService
    /// </summary>
    internal class CEGitHubService : ICEGitHubService
    {
        #region fields
        private IGitHubService _service;
        #endregion

        #region ctor
        internal CEGitHubService(string user, string token, string owner)
        {
            _service = new GitHubService(user, token, owner);
        }
        internal CEGitHubService(IGitHubService service)
        {
            _service = service;
        }
        #endregion

        #region public methods
        // Branches 
        public async Task<IList<ICEBranch>> GetBranches(string repositoryName)
        {
            return await GetBranchesInternal(repositoryName);
        }

        // Pull Requests 
        public async Task<IList<ICEPullRequest>> SearchPullRequests(PullRequestSearchArgs e)
        {
            return await SearchPullRequestsInternal(e);
        }

        public async Task<IList<ICEPullRequest>> SearchOpenPullRequests(string repositoryName)
        {
            return await SearchOpenPullRequestsInternal(repositoryName);
        }      
        public async Task<IList<ICEPullRequest>> SearchPullRequests(string repositoryName)
        {
            return await SearchPullRequests(new List<string> { repositoryName });
        }
        public async Task<IList<ICEPullRequest>> SearchPullRequests(IList<string> repositoryNames)
        {
            return await SearchPullRequestsInternal(ItemState.Closed | ItemState.Open, repositoryNames);
        }
        public async Task<IList<ICEPullRequest>> SearchPullRequests(string repositoryName, string branchName)
        {
            return await SearchPullRequestsInternal(repositoryName, branchName);
        }
        public async Task<IList<ICEPullRequest>> SearchPullRequestsByJiraKey(string repositoryName, string jiraIssueKey)
        {
            return await SearchPullRequestsByJiraKeyInternal(repositoryName, jiraIssueKey);
        }
        // Commits 
        public async Task<IList<ICECommit>> GetCommits(string repositoryName, string branchName)
        {
            return await GetCommitsInternal(repositoryName, branchName);
        }
        public async Task<ICECommit> GetPullRequestCommits(string repositoryName, string sha)
        {
            return await GetPullRequestCommitsInternal(repositoryName, sha);
        }
        public async Task<bool> IsCommitInBranch(string repositoryName, string branchName, string sha)
        {
            return await CheckCommitInBranch(repositoryName, branchName, sha);
        }
        #endregion

        #region private methods
        // Branches 
        private async Task<IList<ICEBranch>> GetBranchesInternal(string repositoryName)
        {
            var result = new List<ICEBranch>();

            var gitHubBranches = await _service.GetBranches(repositoryName);

            foreach (var gitHubBranch in gitHubBranches)
            {
                var ceBranch = new CEBranch()
                {
                    Name = gitHubBranch.Name,
                    RepositoryName = repositoryName,
                    Sha = gitHubBranch.Commit.Sha
                };

                result.Add(ceBranch);
            }

            return result;
        }
        // Pull Requests 
        private async Task<IList<ICEPullRequest>> SearchOpenPullRequestsInternal(string repositoryName)
        {
            return await SearchPullRequestsInternal(ItemState.Open, new List<string>() { repositoryName });
        }
        private async Task<IList<ICEPullRequest>> SearchPullRequestsInternal(ItemState? state, IList<string> repositoryNames)
        {
            var result = new List<ICEPullRequest>();

            var searchResults = await _service.SearchPullRequests(state, repositoryNames);

            foreach (var item in searchResults.Items)
            {
                var cePullRequest = new CEPullRequest()
                {
                    Repo = item.Repository.Name,
                    Sha = item.PullRequest.Head.Sha,
                    Id = item.PullRequest.Id,
                    Number = item.PullRequest.Number,
                    Title = item.PullRequest.Title,
                    Status = item.PullRequest.State.ToString(),
                    IsLocked = item.PullRequest.Locked,
                    IsMerged = item.PullRequest.Merged,
                    CommentCount = item.PullRequest.Comments,
                    CommitCount = item.PullRequest.Commits
                };
                result.Add(cePullRequest);
            }

            return result;
        }
        private async Task<IList<ICEPullRequest>> SearchPullRequestsInternal(string repositoryName, string branchName)
        {
            var result = new List<ICEPullRequest>();

            var pullRequests = await _service.GetPullRequests(repositoryName, branchName);

            foreach (var pullRequest in pullRequests)
            {
                var cePullRequest = new CEPullRequest()
                {
                    Repo = repositoryName,
                    Sha = pullRequest.Head.Sha,
                    Id = pullRequest.Id,
                    Number = pullRequest.Number,
                    Title = pullRequest.Title,
                    Status = pullRequest.State.ToString(),
                    IsLocked = pullRequest.Locked,
                    IsMerged = pullRequest.Merged,
                    CommentCount = pullRequest.Comments,
                    CommitCount = pullRequest.Commits
                };
                result.Add(cePullRequest);
            }

            return result;
        }
        private async Task<IList<ICEPullRequest>> SearchPullRequestsByJiraKeyInternal(string repositoryName, string jiraIssueKey)
        {
            var result = new List<ICEPullRequest>();

            var pullRequests = await _service.SearchPullRequests(repositoryName, jiraIssueKey);

            foreach (var item in pullRequests.Items)
            {
                var pullRequestDetails = await _service.GetPullRequest(repositoryName, item.Number);

                var cePullRequest = new CEPullRequest()
                {
                    Repo = repositoryName,
                    Id = pullRequestDetails.Id,
                    Number = pullRequestDetails.Number,
                    Sha = pullRequestDetails.Base.Sha,
                    Title = pullRequestDetails.Title,
                    Status = pullRequestDetails.State.ToString(),
                    CreatedAt = pullRequestDetails.CreatedAt.UtcDateTime,
                    UpdatedAt = pullRequestDetails.UpdatedAt.UtcDateTime,

                    ChangedFiles = pullRequestDetails.ChangedFiles,
                    Additions = pullRequestDetails.Additions,
                    Deletions = pullRequestDetails.Deletions,

                    Url = pullRequestDetails.Url.AbsolutePath,
                    PatchUrl = pullRequestDetails.PatchUrl.AbsolutePath,
                    DiffUrl = pullRequestDetails.DiffUrl.AbsolutePath,
                    HtmlUrl = pullRequestDetails.HtmlUrl.AbsolutePath,

                    Head = pullRequestDetails.Head.Sha,
                    Base = pullRequestDetails.Base.Sha,
                    HeadRef = pullRequestDetails.Head.Ref,
                    BaseRef = pullRequestDetails.Base.Ref,

                    IsLocked = pullRequestDetails.Locked,
                    IsMerged = pullRequestDetails.Merged,
                    IsMergeable = pullRequestDetails.Mergeable,
                    User = pullRequestDetails.User.Login,

                    CommentCount = item.Comments,
                    CommitCount = pullRequestDetails.Commits
                };
                if (pullRequestDetails.Merged)
                {
                    cePullRequest.MergedBy = pullRequestDetails.MergedBy.Login;
                    cePullRequest.MergedAt = pullRequestDetails.MergedAt.Value.UtcDateTime;
                }
                if (pullRequestDetails.ClosedAt.HasValue)
                {
                    cePullRequest.ClosedAt = pullRequestDetails.ClosedAt.Value.UtcDateTime;
                }
                if (cePullRequest.CommitCount > 0)
                {
                    var commitSha = cePullRequest.Head;
                    for (int commitIdx = 0; commitIdx < cePullRequest.CommitCount; commitIdx++)
                    {
                        try
                        {
                            var commit = await _service.GetPullRequestCommits(repositoryName, commitSha);
                            var ceCommit = new CECommit()
                            {
                                Repo = repositoryName,
                                Branch = cePullRequest.HeadRef,
                                Sha = commit.Sha,
                                Message = commit.Commit.Message,
                                Files = commit.Files.Select(f => f.Filename).ToList()
                            };
                            cePullRequest.Commits.Add(ceCommit);
                            commitSha = commit.Commit.Tree.Sha;
                        }
                        catch (Octokit.NotFoundException)
                        {

                        }
                    }
                }

                result.Add(cePullRequest);
            }
            return result;
        }



        private async Task<IList<ICEPullRequest>> SearchPullRequestsInternal(PullRequestSearchArgs e)
        {
            var result = new List<ICEPullRequest>();

            var request = new PullRequestRequest
            {
                State = (ItemStateFilter)e.State,
                Base = e.Branch,
            };

            var options = new ApiOptions
            {
                PageCount = e.PageCount,
                StartPage = e.StartPage,
                PageSize = e.PageSize
            };

            var pullRequests = await _service.SearchPullRequests(e.Repository, request, options);

            foreach (var pullRequest in pullRequests)
            {
                var cePullRequest = new CEPullRequest()
                {
                    Repo = e.Repository,
                    Sha = pullRequest.Head.Sha,
                    Id = pullRequest.Id,
                    Number = pullRequest.Number,
                    Title = pullRequest.Title,
                    Status = pullRequest.State.ToString(),
                    IsLocked = pullRequest.Locked,
                    IsMerged = pullRequest.Merged,
                    CommentCount = pullRequest.Comments,
                    CommitCount = pullRequest.Commits,
                    UpdatedAt = pullRequest.UpdatedAt.DateTime,
                    CreatedAt = pullRequest.CreatedAt.DateTime
                };
                result.Add(cePullRequest);
            }

            return result;
        }
        // Commits 
        private async Task<IList<ICECommit>> GetCommitsInternal(string repositoryName, string branchName)
        {
            var result = new List<ICECommit>();

            var commits = await _service.GetCommits(repositoryName, branchName);

            foreach (var commit in commits)
            {
                var ceCommit = new CECommit()
                {
                    Repo = repositoryName,
                    Branch = branchName,
                    Sha = commit.Sha,
                    Message = commit.Commit.Message,
                    Files = commit.Files.Select(f => f.Filename).ToList()
                };

                result.Add(ceCommit);
            }

            return result;
        }
        private async Task<ICECommit> GetPullRequestCommitsInternal(string repositoryName, string sha)
        {
            var result = await _service.GetPullRequestCommits(repositoryName, sha);
            return (ICECommit)result;
        }
        private async Task<bool> CheckCommitInBranch(string repositoryName, string branchName, string sha)
        {
            var result = await _service.CheckCommitInBranch(repositoryName, branchName, sha);
            return (result.Status == "identical" || result.Status == "behind");
        }
        #endregion
    }
}
