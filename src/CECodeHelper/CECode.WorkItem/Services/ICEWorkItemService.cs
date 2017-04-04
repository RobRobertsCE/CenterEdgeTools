using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CECode.Business;
using CECode.Business.Services;

namespace CECode.WorkItem.Services
{
    public interface ICEWorkItemService
    {
        string ProjectName { get; set; }
        string BranchName { get; set; }

        Task<IList<ICEWorkItem>> GetPullRequests();
        Task<IList<ICEWorkItem>> GetPullRequests(RequestState? state, DateTime? updatedSince);

        Task<ICEWorkItem> GetPullRequestDetails(ICEWorkItem item);

        Task<ICEWorkItem> UpdateBuilds(ICEWorkItem workItem);
        Task<ICEBuildDetails> GetBuildDetails(ICEPullRequest pullRequest);

        //Task<ICEBuildDetails> GetBuildDetails(ICEPullRequest pullRequest);
        //Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber);
        //Task<IList<ICEWorkItem>> GetWorkItems(string gitHubRepositoryName, string jiraProjectName);
        //Task<IList<ICEWorkItem>> GetWorkItems(string jiraProjectName);
        //Task UpdateBuild(ICEPullRequest pullRequest);
        //Task UpdateBuilds(ICEWorkItem workItem);
        //Task UpdateCommit(ICEPullRequest pullRequest, string gitHubProjectName);
        //Task UpdateCommits(IList<ICEPullRequest> pullRequests, string gitHubProjectName);
        //Task UpdatePullRequests(ICEWorkItem workItem, string gitHubProjectName);
        //Task UpdatePullRequests(IList<ICEWorkItem> workItems, string gitHubProjectName);


    }
}
