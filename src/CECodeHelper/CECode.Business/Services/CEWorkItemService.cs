using CECode.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    internal class CEWorkItemService : ICEWorkItemService
    {
        #region fields
        private ICEJiraService _jiraService;
        private ICEGitHubService _gitHubService;
        private ICETeamCityService _teamCityService;
        #endregion

        #region ctor
        internal CEWorkItemService(ICEJiraService jiraService, ICEGitHubService gitHubService, ICETeamCityService teamCityService)
        {
            _jiraService = jiraService;
            _gitHubService = gitHubService;
            _teamCityService = teamCityService;
        }

        internal CEWorkItemService()
        {
            var jiraProfile = AccountProfileHelper.GetJIRAAccountInfo();
            _jiraService = new CEJiraService(jiraProfile.URL, jiraProfile.Login, jiraProfile.Password);

            var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
            _gitHubService = new CEGitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);

            var teamCityProfile = AccountProfileHelper.GetTeamCityAccountInfo();
            _teamCityService = new CETeamCityService(teamCityProfile.Login, teamCityProfile.Password);
        }
        #endregion

        #region public methods
        // Jira 
        public async Task<IList<ICEWorkItem>> GetWorkItems(string jiraProjectName)
        {
            return await Task.Run(() =>
                {
                    var workItems = new List<ICEWorkItem>();

                    var jiraIssues = GetInProgressIssues();

                    foreach (var jiraIssue in jiraIssues)
                    {
                        var workItem = new CEWorkItem() { JiraIssue = jiraIssue };
                        workItems.Add(workItem);
                    }

                    return workItems;
                });
        }

        public async Task<IList<ICEWorkItem>> GetWorkItems(string gitHubRepositoryName, string jiraProjectName)
        {
            var workItems = new List<ICEWorkItem>();

            var jiraIssues = GetInProgressIssues();

            foreach (var jiraIssue in jiraIssues)
            {
                var workItem = new CEWorkItem() { JiraIssue = jiraIssue };
                try
                {
                    var pullRequestTask = await GetPullRequestsByJiraIssue(gitHubRepositoryName, jiraIssue.IssueNumber.ToString());
                    workItem.PullRequests = pullRequestTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                workItems.Add(workItem);
            }

            return workItems;
        }

        public async Task<ICEWorkItem> GetWorkItem(string gitHubRepositoryName, string jiraProjectName, string jiraIssueNumber)
        {
            var workItem = new CEWorkItem();

            workItem.JiraIssue = GetJiraIssue(jiraProjectName, jiraIssueNumber);

            var pullRequestTask = await GetPullRequestsByJiraIssue(gitHubRepositoryName, jiraIssueNumber);

            workItem.PullRequests = pullRequestTask;

            return workItem;
        }

        // GitHub 
        public async Task UpdateCommits(IList<ICEPullRequest> pullRequests, string gitHubProjectName)
        {
            foreach (var pullRequest in pullRequests)
            {
                await UpdateCommit(pullRequest, gitHubProjectName);
            }
        }

        public async Task UpdateCommit(ICEPullRequest pullRequest, string gitHubProjectName)
        {
            pullRequest.Commits = await GetCommitsByPullRequest(gitHubProjectName, pullRequest.Sha);
        }

        public async Task UpdatePullRequests(IList<ICEWorkItem> workItems, string gitHubProjectName)
        {
            foreach (var workItem in workItems)
            {
                await UpdatePullRequests(workItem, gitHubProjectName);
            }
        }

        public async Task UpdatePullRequests(ICEWorkItem workItem, string gitHubProjectName)
        {
            workItem.PullRequests = await GetPullRequestsByJiraIssue(gitHubProjectName, workItem.JiraIssue.IssueNumber.ToString());
        }

        // TeamCity 
        public async Task UpdateBuilds(ICEWorkItem workItem)
        {
            foreach (var pullRequest in workItem.PullRequests)
            {
                await UpdateBuild(pullRequest);
            }
        }

        public async Task UpdateBuild(ICEPullRequest pullRequest)
        {
            await Task.Run(() =>
                {
                    pullRequest.Builds = GetBuilds(pullRequest.Number);
                });
        }

        public async Task<ICEBuildDetails> GetBuildDetails(ICEPullRequest pullRequest)
        {
            return await Task<ICEBuildDetails>.Run(() =>
            {
                return GetBuildDetails(pullRequest.Id);
            });
        }
        #endregion

        #region private methods
        // Jira 
        protected virtual ICEJiraIssue GetJiraIssue(string jiraProjectName, string jiraIssueNumber)
        {
            var jiraIssueKey = String.Format("{0}-{1}", jiraProjectName, jiraIssueNumber);
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

        // GitHub 
        protected async virtual Task<IList<ICEPullRequest>> GetPullRequestsByJiraIssue(string gitHubRepositoryName, string jiraIssueNumber)
        {
            var pullRequestsResult = await _gitHubService.SearchPullRequests(gitHubRepositoryName, jiraIssueNumber);

            if (null != pullRequestsResult)
                return pullRequestsResult.Select(p => (ICEPullRequest)p).ToList();
            else
                return new List<ICEPullRequest>();
        }

        protected async virtual Task<IList<ICECommit>> GetCommitsByPullRequest(string gitHubRepositoryName, string sha)
        {
            var commitResults = await _gitHubService.GetPullRequestCommits(gitHubRepositoryName, sha);
            if (null != commitResults)
                return new List<ICECommit>() { (ICECommit)commitResults };
            else
                return new List<ICECommit>();
        }

        // TeamCity 
        protected virtual IList<ICEBuildDetails> GetBuilds(int mergeNumber)
        {
            return _teamCityService.GetBuildsByPullRequest(mergeNumber);
        }

        protected virtual ICEBuildDetails GetBuildDetails(long pullRequestId)
        {
            return _teamCityService.GetBuild(pullRequestId);
        }
        #endregion
    }
}
