using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CECode.Business.Services
{
    public interface ICEGitHubService
    {
        Task<IList<CEPullRequest>> SearchPullRequests(string repositoryName, string jiraIssueKey);
        Task<IList<CEBranch>> GetBranches(string repositoryName);
        Task<IList<CECommit>> GetCommits(string repoName, string branchName);
        Task<ICECommit> GetPullRequestCommits(string repositoryName, string sha);
        Task<IList<CEPullRequest>> GetPullRequests(string repoName, string branchName);
        Task<bool> IsCommitInBranch(string repositoryName, string branchName, string sha);
        Task<IList<CEPullRequest>> SearchPullRequests(IList<string> repoNames);
    }
}
