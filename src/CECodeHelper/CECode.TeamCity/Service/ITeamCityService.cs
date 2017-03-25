using System;
using System.Collections.Generic;
using CECode.TeamCity.Results;

namespace CECode.TeamCity.Service
{
    public interface ITeamCityService
    {
        BuildDetails GetAdvantageBuild();
        BuildDetails GetAdvantagePatchBuild();
        BuildDetails GetAdvantageAutoMergeBuild();
        BuildDetails GetBuildByType(string buildType);
        BuildDetails GetBuild(long buildId);

        IList<BuildDetails> GetBuildsByMergeNumber(int number);

        IList<RunningBuild> GetQueuedBuilds();
        IList<RunningBuild> GetRunningBuilds();

        IList<RunningBuild> GetBuilds();
        IList<RunningBuild> GetBuilds(string locator);
        IList<RunningBuild> GetBuildTypeBuilds(string buildType);
    }
}
