using CECode.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public class WorkItemService
    {
        #region fields
        private ICEJiraService _jiraService;
        private ICEGitHubService _gitHubService;
        private ICETeamCityService _teamCityService;
        #endregion

        #region ctor
        internal WorkItemService(ICEJiraService jiraService, ICEGitHubService gitHubService, ICETeamCityService teamCityService)
        {
            _jiraService = jiraService;
            _gitHubService = gitHubService;
            _teamCityService = teamCityService;
        }

        public WorkItemService()
        {
            var jiraProfile = AccountProfileHelper.GetJIRAAccountInfo();
            _jiraService = new CEJiraService(jiraProfile.URL, jiraProfile.Login, jiraProfile.Password);

            var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
            _gitHubService = new CEGitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);

            var teamCityProfile = AccountProfileHelper.GetTeamCityAccountInfo();
            _teamCityService = new CETeamCityService(teamCityProfile.Login, teamCityProfile.Password);
        }
        #endregion

        #region public methods - pull requests
        public async Task<IList<ICEJiraIssue>> GetJiraIssues(IList<string> keys)
        {
            IList<ICEJiraIssue> results = new List<ICEJiraIssue>();
            foreach (var key in keys)
            {
                var jiraIssue = await GetJiraIssue(key);
                results.Add(jiraIssue);
            }
            return results;
        }

        public async Task<ICEJiraIssue> GetJiraIssue(string key)
        {
            return await GetJiraIssueInternal(key);
        }
        #endregion

        #region public methods - pull requests
        public async Task<IList<ICEPullRequest>> GetPullRequests(PullRequestSearchArgs e)
        {
            return await GetPullRequestsInternal(e);
        }

        public async Task<IList<ICEPullRequest>> GetOpenPullRequests(string repository)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                State = RequestState.Open
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetOpenPullRequests(string repository, int count)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                State = RequestState.Open,
                PageSize = count
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetOpenPullRequests(string repository, DateTime updatedSince)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                State = RequestState.Open,
                UpdatedSince = updatedSince
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetOpenPullRequests(string repository, DateTime updatedSince, int count)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                State = RequestState.Open,
                UpdatedSince = updatedSince,
                PageSize = count
            };

            return await GetPullRequestsInternal(e);
        }

        public async Task<IList<ICEPullRequest>> GetPullRequests(string repository)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetPullRequests(string repository, int count)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                PageSize = count
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetPullRequests(string repository, DateTime updatedSince)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                UpdatedSince = updatedSince
            };

            return await GetPullRequestsInternal(e);
        }
        public async Task<IList<ICEPullRequest>> GetPullRequests(string repository, DateTime updatedSince, int count)
        {
            PullRequestSearchArgs e = new PullRequestSearchArgs()
            {
                Repository = repository,
                UpdatedSince = updatedSince,
                PageSize = count
            };

            return await GetPullRequestsInternal(e);
        }
        #endregion

        #region public methods - builds
        public async Task<ICEBuildDetails> GetBuildDetails(long id)
        {
            return await GetBuildDetailsInternal(id);
        }
        public async Task<IList<ICEBuildDetails>> GetBuilds(int number)
        {
            return await GetBuildsInternal(number);
        }
        #endregion

        #region protected virtual methods - jira issues
        protected async virtual Task<ICEJiraIssue> GetJiraIssueInternal(string key)
        {
            return await Task.Run(() =>
            {
                return _jiraService.GetItem(key);
            });
        }
        #endregion

        #region protected virtual methods - pull requests
        protected async virtual Task<IList<ICEPullRequest>> GetPullRequestsInternal(PullRequestSearchArgs e)
        {
            return await _gitHubService.SearchPullRequests(e);
        }
        #endregion

        #region protected virtual methods - builds
        protected virtual async Task<ICEBuildDetails> GetBuildDetailsInternal(long id)
        {
            return await Task.Run(() =>
            {
                return _teamCityService.GetBuild(id);
            });
        }

        protected virtual async Task<IList<ICEBuildDetails>> GetBuildsInternal(int number)
        {
            return await Task.Run(() =>
            {
                return _teamCityService.GetBuildsByPullRequest(number);
            });
        }
        #endregion
    }
}
