using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.Authentication;
using CECode.Business.Services;

namespace CECode.WorkItem.Services
{
    public static class ServiceFactory
    {
        public static ICEWorkItemService GetCEWorkItemService()
        {
            var teamCityProfile = AccountProfileHelper.GetTeamCityAccountInfo();
            var teamCityService = CECode.Business.Services.ServiceFactory.GetCETeamCityService(teamCityProfile.Login, teamCityProfile.Password);
            var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
            var gitHubService = CECode.Business.Services.ServiceFactory.GetCEGitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);
            var jiraProfile = AccountProfileHelper.GetJIRAAccountInfo();
            var jiraService = CECode.Business.Services.ServiceFactory.GetCEJiraService(jiraProfile.URL, jiraProfile.Login, jiraProfile.Password);
            return new CEWorkItemService(jiraService, gitHubService, teamCityService);
        }

        public static ICEWorkItemService GetCEWorkItemService(ICEJiraService jiraService, ICEGitHubService gitHubService, ICETeamCityService teamCityService)
        {
            return new CEWorkItemService(jiraService, gitHubService, teamCityService);
        }
    }
}
