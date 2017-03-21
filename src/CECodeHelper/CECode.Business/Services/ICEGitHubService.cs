using System.Collections.Generic;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public interface ICEGitHubService
    {
        Task<IList<ICEPullRequest>> SearchPullRequests(string repositoryName, string jiraIssueKey);
        Task<IList<ICEBranch>> GetBranches(string repositoryName);
        Task<IList<ICECommit>> GetCommits(string repoName, string branchName);
        Task<ICECommit> GetPullRequestCommits(string repositoryName, string sha);
        Task<IList<ICEPullRequest>> GetPullRequests(string repoName, string branchName);
        Task<bool> IsCommitInBranch(string repositoryName, string branchName, string sha);
        Task<IList<ICEPullRequest>> SearchPullRequests(IList<string> repoNames);
    }
}
