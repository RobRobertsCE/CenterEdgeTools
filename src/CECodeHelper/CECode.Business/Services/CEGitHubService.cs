﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CECode.Business;
using CECode.GitHub;

namespace CECode.Business.Services
{
    /// <summary>
    /// Adapter class for GitHubService
    /// </summary>
    public class CEGitHubService : ICEGitHubService
    {
        #region fields
        private IGitHubService _service;
        #endregion

        #region ctor
        public CEGitHubService(string user, string token, string owner)
        {
            _service = new GitHubService(user, token, owner);
        }
        public CEGitHubService(IGitHubService service)
        {
            _service = service;
        }
        #endregion

        #region public methods
        public async Task<IList<CEBranch>> GetBranches(string repositoryName)
        {
            return await GetBranchesInternal(repositoryName);
        }

        public async Task<IList<CECommit>> GetCommits(string repoName, string branchName)
        {
            return await GetCommitsInternal(repoName, branchName);
        }

        public async Task<ICECommit> GetPullRequestCommits(string repositoryName, string sha)
        {
            return await GetPullRequestCommitsInternal(repositoryName, sha);
        }

        public async Task<IList<CEPullRequest>> GetPullRequests(string repoName, string branchName)
        {
            return await GetPullRequestsInternal(repoName, branchName);
        }

        public async Task<IList<CEPullRequest>> SearchPullRequests(IList<string> repoNames)
        {
            return await GetPullRequestsInternal(repoNames);
        }

        public async Task<IList<CEPullRequest>> SearchPullRequests(string repoName, string jiraIssueKey)
        {
            return await GetPullRequestsByJiraKeyInternal(repoName, jiraIssueKey);
        }

        public async Task<bool> IsCommitInBranch(string repositoryName, string branchName, string sha)
        {
            return await CheckCommitInBranch(repositoryName, branchName, sha);
        }
        #endregion

        #region private methods
        private async Task<IList<CEBranch>> GetBranchesInternal(string repositoryName)
        {
            IList<CEBranch> result = new List<CEBranch>();

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

        private async Task<IList<CECommit>> GetCommitsInternal(string repositoryName, string branchName)
        {
            IList<CECommit> result = new List<CECommit>();

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

        private async Task<IList<CEPullRequest>> GetPullRequestsInternal(string repositoryName, string branchName)
        {
            IList<CEPullRequest> result = new List<CEPullRequest>();

            var pullRequests = await _service.GetPullRequests(repositoryName, branchName);

            foreach (var pullRequest in pullRequests)
            {
                var cePullRequest = new CEPullRequest()
                {
                    Repo = repositoryName,
                    Branch = branchName,
                    Sha = pullRequest.Head.Sha,
                    Id = pullRequest.Id,
                    Number = pullRequest.Number,
                    Title = pullRequest.Title,
                    Status = pullRequest.State.ToString(),
                    IsOnHold = pullRequest.Locked,
                    IsMerged = pullRequest.Merged,
                    CommentCount = pullRequest.Comments,
                    CommitCount = pullRequest.Commits
                };

                //foreach (var commit in pullRequest.Commits)
                //{
                //    var ceCommit = new CECommit()
                //    {
                //        Repo = repositoryName,
                //        Branch = branchName,
                //        Sha = commit.Sha,
                //        Message = commit.Commit.Message,
                //        Files = commit.Files.Select(f => f.Filename).ToList()
                //    };

                //    cePullRequest.Commits.Add(ceCommit);
                //}

                result.Add(cePullRequest);
            }

            return result;
        }

        private async Task<IList<CEPullRequest>> GetPullRequestsByJiraKeyInternal(string repositoryName, string jiraIssueKey)
        {
            IList<CEPullRequest> result = new List<CEPullRequest>();

            var pullRequests = await _service.SearchPullRequests(repositoryName, jiraIssueKey);

            foreach (var item in pullRequests.Items)
            {
                var pullRequestDetails = await _service.GetPullRequest(repositoryName, item.Number);

                var cePullRequest = new CEPullRequest()
                {
                    Repo = repositoryName,
                    Id = item.PullRequest.Id,
                    Number = item.PullRequest.Number,
                    Title = item.PullRequest.Title,
                    Status = item.State.ToString(),
                    IsOnHold = item.PullRequest.Locked,
                    IsMerged = item.PullRequest.Merged,
                    CommentCount = item.PullRequest.Comments,
                    CommitCount = item.PullRequest.Commits
                    //MergeCommitSha	!
                    // do not have commit details, need to make a new call for each . (Commit count? head/base counting back from each?
                };





                //foreach (var commit in pullRequest.Commits)
                //{
                //    var ceCommit = new CECommit()
                //    {
                //        Repo = repositoryName,
                //        Branch = branchName,
                //        Sha = commit.Sha,
                //        Message = commit.Commit.Message,
                //        Files = commit.Files.Select(f => f.Filename).ToList()
                //    };

                //    cePullRequest.Commits.Add(ceCommit);
                //}

                result.Add(cePullRequest);
            }

            return result;
        }

        private async Task<ICECommit> GetPullRequestCommitsInternal(string repositoryName, string sha)
        {
            var result = await _service.GetPullRequestCommits(repositoryName, sha);
            return (ICECommit)result;
        }

        private async Task<IList<CEPullRequest>> GetPullRequestsInternal(IList<string> repositoryNames)
        {
            IList<CEPullRequest> result = new List<CEPullRequest>();

            var searchResults = await _service.SearchPullRequests(repositoryNames);

            foreach (var item in searchResults.Items)
            {
                var cePullRequest = new CEPullRequest()
                {
                    Repo = item.Repository.Name,
                    Branch = item.PullRequest.Head.Ref,
                    Sha = item.PullRequest.Head.Sha,
                    Id = item.PullRequest.Id,
                    Number = item.PullRequest.Number,
                    Title = item.PullRequest.Title,
                    Status = item.PullRequest.State.ToString(),
                    IsOnHold = item.PullRequest.Locked,
                    IsMerged = item.PullRequest.Merged,
                    CommentCount = item.PullRequest.Comments,
                    CommitCount = item.PullRequest.Commits
                };

                //foreach (var commit in pullRequest.Commits)
                //{
                //    var ceCommit = new CECommit()
                //    {
                //        Repo = repositoryName,
                //        Branch = branchName,
                //        Sha = commit.Sha,
                //        Message = commit.Commit.Message,
                //        Files = commit.Files.Select(f => f.Filename).ToList()
                //    };

                //    cePullRequest.Commits.Add(ceCommit);
                //}

                result.Add(cePullRequest);
            }

            return result;
        }

        private async Task<bool> CheckCommitInBranch(string repositoryName, string branchName, string sha)
        {
            var result = await _service.CheckCommitInBranch(repositoryName, branchName, sha);
            return (result.Status == "identical" || result.Status == "behind");
        }
        #endregion
    }
}