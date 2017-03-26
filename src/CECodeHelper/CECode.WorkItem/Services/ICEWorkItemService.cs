using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CECode.Business;

namespace CECode.WorkItem.Services
{
    public interface ICEWorkItemService
    {
        Task<ICEBuildDetails> GetBuildDetails(ICEPullRequest pullRequest);
        Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber);
        Task<IList<ICEWorkItem>> GetWorkItems(string gitHubRepositoryName, string jiraProjectName);
        Task<IList<ICEWorkItem>> GetWorkItems(string jiraProjectName);
        Task UpdateBuild(ICEPullRequest pullRequest);
        Task UpdateBuilds(ICEWorkItem workItem);
        Task UpdateCommit(ICEPullRequest pullRequest, string gitHubProjectName);
        Task UpdateCommits(IList<ICEPullRequest> pullRequests, string gitHubProjectName);
        Task UpdatePullRequests(ICEWorkItem workItem, string gitHubProjectName);
        Task UpdatePullRequests(IList<ICEWorkItem> workItems, string gitHubProjectName);
    }
}
