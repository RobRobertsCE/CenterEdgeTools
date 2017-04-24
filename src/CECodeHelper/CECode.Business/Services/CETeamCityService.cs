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
        public ICEBuildDetails GetAdvantageBuild()
        {
            var build = _service.GetAdvantageBuild();

            return TeamCityBuildAdapter.Translate(build);
        }

        public ICEBuildDetails GetPatchBuild()
        {
            var build = _service.GetAdvantagePatchBuild();

            return TeamCityBuildAdapter.Translate(build);
        }

        public ICEBuildDetails GetAutoMergeBuild()
        {
            var build = _service.GetAdvantageAutoMergeBuild();

            return TeamCityBuildAdapter.Translate(build);
        }

        public ICEBuildDetails GetBuild(long id)
        {
            var build = _service.GetBuild(id);

            return TeamCityBuildAdapter.Translate(build);
        }

        public IList<ICEBuild> GetBuilds()
        {
            var builds = _service.GetBuilds();

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetBuildsQuery(string locator)
        {
            var builds = _service.GetBuilds(locator);

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetBuildTypeBuildsQuery(string buildType)
        {
            var builds = _service.GetBuildTypeBuilds(buildType);

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuildDetails> GetBuildsByPullRequest(int pullRequestNumber)
        {
            var builds = _service.GetBuildsByPullRequest(pullRequestNumber);
            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetRunningBuilds()
        {
            var builds = _service.GetRunningBuilds();

            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuild> GetQueuedBuilds()
        {
            var builds = _service.GetQueuedBuilds();
            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuildIssue> GetBuildRelatedIssues(long buildId)
        {
            var builds = _service.GetBuildRelatedIssues(buildId);
            return TeamCityBuildAdapter.Translate(builds);
        }

        public IList<ICEBuildArtifact> GetBuildArtifacts(long buildId)
        {
            var builds = _service.GetBuildArtifacts(buildId);
            return TeamCityBuildAdapter.Translate(builds);
        }
        #endregion
    }
}
