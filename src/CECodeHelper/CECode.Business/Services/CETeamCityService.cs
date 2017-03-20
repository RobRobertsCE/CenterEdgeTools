using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECode.TeamCity;

namespace CECode.Business.Services
{
    public class CETeamCityService : ICETeamCityService
    {
        private ITeamCityService _service;

        public CETeamCityService(string user, string password)
        {
            _service = new TeamCityService(user, password);
        }

        public CEBuild GetAdvantageBuild()
        {
            var build = _service.GetAdvantageBuild();

            var result = new CEBuild()
                {
                    id = build.id,
                    state = build.state,
                    status = build.status,
                    branchName = build.branchName,
                    number = build.number,
                    buildTypeId = build.buildTypeId,
                    href = build.href,
                    webUrl = build.webUrl
                };

            return result;
        }

        public CEBuild GetAdvantagePatches()
        {
            var build = _service.GetAdvantagePatches();

            var result = new CEBuild()
            {
                id = build.id,
                state = build.state,
                status = build.status,
                branchName = build.branchName,
                number = build.number,
                buildTypeId = build.buildTypeId,
                href = build.href,
                webUrl = build.webUrl
            };

            return result;
        }

        public IList<CEBuild> GetBuilds()
        {
            var results = new List<CEBuild>();

            var builds = _service.GetBuilds();

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
                    webUrl = build.webUrl
                };

                results.Add(ceBuild);
            }

            return results;
        }

        public IList<CEBuild> GetPatchBuilds()
        {
            var results = new List<CEBuild>();

            var builds = _service.GetBuilds("Advantage_Patches");

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
                    webUrl = build.webUrl
                };

                results.Add(ceBuild);
            }

            return results;
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
