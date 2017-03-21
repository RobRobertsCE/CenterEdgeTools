using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business.Services
{
    public static class ServiceFactory
    {
        public static ICEJiraService GetCEJiraService(string url, string userName, string password)
        {
            return new CEJiraService(url, userName, password);
        }

        public static ICEGitHubService GetCEGitHubService(string user, string token, string owner)
        {
            return new CEGitHubService(user, token, owner);
        }

        public static ICETeamCityService GetCETeamCityService(string user, string password)
        {
            return new CETeamCityService(user, password);
        }

        public static ICEWorkItemService GetCEWorkItemService()
        {
            return new CEWorkItemService();
        }

        public static ICEWorkItemService GetCEWorkItemService(ICEJiraService jiraService, ICEGitHubService gitHubService, ICETeamCityService teamCityService)
        {
            return new CEWorkItemService(jiraService, gitHubService, teamCityService);
        }
    }
}
