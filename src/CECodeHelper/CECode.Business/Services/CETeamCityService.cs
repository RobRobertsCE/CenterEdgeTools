using CECode.Business.Adapters;
using CECode.TeamCity.Service;
using System;
using System.Collections.Generic;

namespace CECode.Business.Services
{
    internal class CETeamCityService : ICETeamCityService
    {
        #region fields
        private ITeamCityService _service;
        #endregion

        #region ctor
        internal CETeamCityService(string user, string password)
        {
            _service = new TeamCityService(user, password);
        }
        #endregion

        #region public methods
        public ICEBuild GetAdvantageBuild()
        {
            var build = _service.GetAdvantageBuild();

            return TeamCityBuildAdapter.Translate(build);
        }

        public ICEBuild GetAdvantagePatches()
        {
            var build = _service.GetAdvantagePatches();

            return TeamCityBuildAdapter.Translate(build);
        }

        public ICEBuild GetBuild(long id)
        {
            var build = _service.GetBuildById(id);

            return TeamCityBuildAdapter.Translate(build);
        }
        
        public ICEBuildDetails GetBuildDetails(long id)
        {
            var build = _service.GetBuildDetails(id);

            return TeamCityBuildAdapter.Translate(build);
        }

        public IList<ICEBuild> GetBuilds()
        {
            var builds = _service.GetBuilds("(default:any)");

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetBuilds(string locator)
        {
            var builds = _service.GetBuilds(locator);

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetMergeBuilds(string mergeNumber)
        {
            var builds = _service.GetBuilds(String.Format("locator=branch:({0}/merge),running:any", mergeNumber));

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetBuildsByMergeNumber(int mergeNumber)
        {
            var builds = _service.GetBuildsByMergeNumber(mergeNumber);

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetRunningBuilds()
        {
            var builds = _service.GetRunningBuilds();

            return TeamCityBuildAdapter.Translate(builds);
        }
        public IList<ICEBuild> GetRunningBuilds(int number)
        {
            var builds = _service.GetRunningBuilds(number);

            return TeamCityBuildAdapter.Translate(builds);
        }
        #endregion
    }
}
