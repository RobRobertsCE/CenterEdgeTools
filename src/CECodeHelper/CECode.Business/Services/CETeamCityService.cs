using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.TeamCity;

namespace CECode.Business.Services
{
    public class CETeamCityService : CECode.Business.Services.ICETeamCityService
    {
        private ITeamCityService _service;

        public CETeamCityService(string user, string password)
        {
            _service = new TeamCityService(user, password);
        }

        public IList<CEBuild> GetRunningBuilds()
        {
            var results = new List<CEBuild>();

            var builds = _service.GetRunningBuilds();

            foreach (var build in builds)
            {
                var ceBuild = new CEBuild()
                {
                    id = build.id,
                    state = build.state,
                    status = build.status,
                    branchName = build.branchName,
                    number = build.number,
                    buildTypeId = build.buildTypeId,
                    href = build.href,
                    percentageComplete = build.percentageComplete,
                    running = build.running,
                    webUrl = build.webUrl
                };

                results.Add(ceBuild);
            }

            return results;
        }
    }
}
