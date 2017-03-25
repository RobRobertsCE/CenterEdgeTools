using System.Collections.Generic;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public interface ICEGitHubService
    {
        Task<IList<ICEBranch>> GetBranches(string repositoryName);
        Task<IList<ICECommit>> GetCommits(string repositoryName, string branchName);
        Task<ICECommit> GetPullRequestCommits(string repositoryName, string sha);
        Task<bool> IsCommitInBranch(string repositoryName, string branchName, string sha);
        Task<IList<ICEPullRequest>> SearchOpenPullRequests(string repositoryName);
        Task<IList<ICEPullRequest>> SearchPullRequests(string repositoryName);
        Task<IList<ICEPullRequest>> SearchPullRequests(IList<string> repositoryNames);
        Task<IList<ICEPullRequest>> SearchPullRequests(string repositoryName, string branchName);
        Task<IList<ICEPullRequest>> SearchPullRequestsByJiraKey(string repositoryName, string jiraIssueKey);


        Task<IList<ICEPullRequest>> SearchPullRequests(PullRequestSearchArgs e);
    }
}
