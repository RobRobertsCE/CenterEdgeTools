using CECode.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CECode.Business.Services;
using CECode.Business;

namespace CECode.WorkItem.Services
{
    internal class CEWorkItemService : ICEWorkItemService
    {
        #region fields
        private ICEJiraService _jiraService;
        private ICEGitHubService _gitHubService;
        private ICETeamCityService _teamCityService;
        #endregion

        #region properties
        public virtual string ProjectName { get; set; }
        public virtual string BranchName { get; set; }
        #endregion

        #region ctor
        internal CEWorkItemService(ICEJiraService jiraService, ICEGitHubService gitHubService, ICETeamCityService teamCityService)
        {
            _jiraService = jiraService;
            _gitHubService = gitHubService;
            _teamCityService = teamCityService;
        }
        #endregion

        #region public methods
        // Jira 
        public async Task<IList<ICEWorkItem>> GetJiraIssues(IList<ICEWorkItem> workItems)
        {
            return await GetJiraIssuesInternal(workItems);
        }

        // GitHub 
        public async Task<IList<ICEWorkItem>> GetPullRequests()
        {
            var requestArgs = new PullRequestSearchArgs()
            {
                Repository = ProjectName,
                Branch = BranchName,
                State = RequestState.All,
                UpdatedSince = DateTime.Now.AddDays(-1),
                PageSize = 10
            };

            return await GetPullRequests(requestArgs);
        }
        public async Task<IList<ICEWorkItem>> GetPullRequests(RequestState? state, DateTime? updatedSince)
        {
            var requestArgs = new PullRequestSearchArgs()
            {
                Repository = ProjectName,
                Branch = BranchName,
                State = state.HasValue ? state.Value : RequestState.All,
                UpdatedSince = updatedSince,
                PageSize = 10
            };

            return await GetPullRequests(requestArgs);
        }
        public async Task<IList<ICEWorkItem>> GetPullRequests(PullRequestSearchArgs e)
        {
            IList<ICEWorkItem> workItems = new List<ICEWorkItem>();

            var pullRequests = await GetPullRequestsInternal(e);

            foreach (var pullRequest in pullRequests)
            {
                workItems.Add(new CEWorkItem()
                {
                    PullRequest = pullRequest
                });
            }

            workItems = await GetJiraIssues(workItems);

            return workItems;
        }
        public async Task<ICEWorkItem> GetPullRequestDetails(ICEWorkItem item)
        {
            return await GetPullRequestDetailsInternal(item);
        }

        // TeamCity 
        public async Task<ICEWorkItem> UpdateBuilds(ICEWorkItem workItem)
        {
            return await Task.Run(() =>
            {
                workItem.PullRequest.Builds = GetBuilds(workItem.PullRequest.Number);
                return workItem;
            });
        }
        public async Task<ICEBuildDetails> GetBuildDetails(ICEPullRequest pullRequest)
        {
            return await Task<ICEBuildDetails>.Run(() =>
            {
                return GetBuildDetails(pullRequest.Id);
            });
        }

        //public async Task<IList<ICEWorkItem>> GetWorkItems(string jiraProjectName)
        //{
        //    return await Task.Run(() =>
        //        {
        //            var workItems = new List<ICEWorkItem>();

        //            var jiraIssues = GetInProgressIssues();

        //            foreach (var jiraIssue in jiraIssues)
        //            {
        //                var workItem = new CEWorkItem() { JiraIssue = jiraIssue };
        //                workItems.Add(workItem);
        //            }

        //            return workItems;
        //        });
        //}

        //public async Task<IList<ICEWorkItem>> GetWorkItems(string gitHubRepositoryName, string jiraProjectName)
        //{
        //    var workItems = new List<ICEWorkItem>();

        //    var jiraIssues = GetInProgressIssues();

        //    foreach (var jiraIssue in jiraIssues)
        //    {
        //        var workItem = new CEWorkItem() { JiraIssue = jiraIssue };
        //        try
        //        {
        //            var pullRequestTask = await GetPullRequestsByJiraIssue(gitHubRepositoryName, jiraIssue.IssueNumber.ToString());
        //            workItem.PullRequests = pullRequestTask;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }

        //        workItems.Add(workItem);
        //    }

        //    return workItems;
        //}

        //public async Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber)
        //{
        //    var workItem = new CEWorkItem();

        //    workItem.JiraIssue = GetJiraIssue(jiraProjectName, jiraIssueNumber);

        //    var pullRequestTask = await GetPullRequestsByJiraIssue(gitHubRepositoryName, jiraIssueNumber);

        //    workItem.PullRequests = pullRequestTask;

        //    return workItem;
        //}

        // GitHub 
        //public async Task UpdateCommits(IList<ICEPullRequest> pullRequests, string gitHubProjectName)
        //{
        //    foreach (var pullRequest in pullRequests)
        //    {
        //        await UpdateCommit(pullRequest, gitHubProjectName);
        //    }
        //}

        //public async Task UpdateCommit(ICEPullRequest pullRequest, string gitHubProjectName)
        //{
        //    pullRequest.Commits = await GetCommitsByPullRequest(gitHubProjectName, pullRequest.Sha);
        //}

        //public async Task UpdatePullRequests(IList<ICEWorkItem> workItems, string gitHubProjectName)
        //{
        //    foreach (var workItem in workItems)
        //    {
        //        await UpdatePullRequests(workItem, gitHubProjectName);
        //    }
        //}

        //public async Task UpdatePullRequests(ICEWorkItem workItem, string gitHubProjectName)
        //{
        //    workItem.PullRequests = await GetPullRequestsByJiraIssue(gitHubProjectName, workItem.JiraIssue.IssueNumber.ToString());
        //}


        // TeamCity 

        #endregion

        #region private methods
        #region Jira
        protected virtual async Task<IList<ICEWorkItem>> GetJiraIssuesInternal(IList<ICEWorkItem> workItems)
        {
            return await Task.Run(() =>
            {
                foreach (var workItem in workItems)
                {
                    var jiraIssueKeys = workItem.PullRequest.GetIssueKeys(ProjectName);

                    foreach (var jiraIssueKey in jiraIssueKeys)
                    {
                        var jiraIssue = GetJiraIssue(jiraIssueKey);
                        workItem.JiraIssues.Add(jiraIssue);
                    }
                }
                return workItems;
            });
        }

        protected virtual ICEJiraIssue GetJiraIssue(string jiraProjectName, string jiraIssueNumber)
        {
            var jiraIssueKey = String.Format("{0}-{1}", jiraProjectName, jiraIssueNumber);
            return GetJiraIssue(jiraIssueKey);
        }
        protected virtual ICEJiraIssue GetJiraIssue(string jiraIssueKey)
        {
            return _jiraService.GetItem(jiraIssueKey);
        }
        protected virtual IList<ICEJiraIssue> GetInProgressIssues()
        {
            return _jiraService.GetInProgressIssues();
        }
        protected virtual IList<ICEJiraIssue> GetJiraIssues(string jiraProjectName)
        {
            return _jiraService.GetOpenItems(new List<string>() { jiraProjectName });
        }
        protected virtual IList<ICEJiraIssue> GetJiraIssues(string jiraProjectName, int count, int start)
        {
            return _jiraService.GetItems(jiraProjectName, count, start);
        }
        #endregion

        #region GitHub
        protected async virtual Task<IList<ICEPullRequest>> GetPullRequestsInternal(PullRequestSearchArgs e)
        {
            var pullRequestsResult = await _gitHubService.SearchPullRequests(e);

            if (null != pullRequestsResult)
                return pullRequestsResult;
            else
                return new List<ICEPullRequest>();
        }
        protected async Task<ICEWorkItem> GetPullRequestDetailsInternal(ICEWorkItem item)
        {
            var pullRequestDetailsResult = await _gitHubService.GetPullRequestDetails(item.PullRequest.Repo, item.PullRequest.Number);
            item.PullRequest = pullRequestDetailsResult;
            return item;
        }

        //protected async virtual Task<IList<ICEPullRequest>> GetPullRequestsByJiraIssue(string gitHubRepositoryName, string jiraIssueNumber)
        //{
        //    var pullRequestsResult = await _gitHubService.SearchPullRequests(gitHubRepositoryName, jiraIssueNumber);

        //    if (null != pullRequestsResult)
        //        return pullRequestsResult.Select(p => (ICEPullRequest)p).ToList();
        //    else
        //        return new List<ICEPullRequest>();
        //}

        //protected async virtual Task<IList<ICECommit>> GetCommitsByPullRequest(string gitHubRepositoryName, string sha)
        //{
        //    var commitResults = await _gitHubService.GetPullRequestCommits(gitHubRepositoryName, sha);
        //    if (null != commitResults)
        //        return new List<ICECommit>() { (ICECommit)commitResults };
        //    else
        //        return new List<ICECommit>();
        //}
        #endregion

        #region TeamCity
        protected virtual IList<ICEBuildDetails> GetBuilds(int mergeNumber)
        {
            return _teamCityService.GetBuildsByPullRequest(mergeNumber);
        }
        protected virtual ICEBuildDetails GetBuildDetails(long pullRequestId)
        {
            return _teamCityService.GetBuild(pullRequestId);
        }
        #endregion
        #endregion
    }
}
