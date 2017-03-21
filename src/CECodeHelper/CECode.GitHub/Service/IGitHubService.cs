using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace CECode.GitHub.Service
{
    public interface IGitHubService
    {
        Task<IReadOnlyList<Branch>> GetBranches(string repositoryName);

        Task<IReadOnlyList<GitHubCommit>> GetCommits(string repositoryName, string branchName);
        Task<GitHubCommit> GetPullRequestCommits(string repositoryName, string sha);
        Task<CompareResult> CheckCommitInBranch(string repositoryName, string branchName, string sha);

        Task<PullRequest> GetPullRequest(string repositoryName, int number);
        Task<IReadOnlyList<PullRequest>> GetPullRequests(string repositoryName, string branchName);
        Task<IReadOnlyList<PullRequest>> GetPullRequests(ItemState? state, string repositoryName, string branchName);
        
        Task<SearchIssuesResult> SearchPullRequests(IList<string> repositoryNames);
        Task<SearchIssuesResult> SearchPullRequests(string repositoryName, string jiraIssueKey);
        Task<SearchIssuesResult> SearchPullRequests(ItemState? state, IList<string> repositoryNames);
        Task<SearchIssuesResult> SearchPullRequests(ItemState? state, DateRange updatedDateRange, IList<string> repositoryNames);
    }
}
