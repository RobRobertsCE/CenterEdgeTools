using System;
using System.Collections.Generic;

namespace CECode.TeamCity.Service
{
    public interface ITeamCityService
    {
        Build GetAdvantageBuild();
        Build GetAdvantagePatches();
        Build GetBuildByType(string buildType);
        Build GetBuildById(long id);
        IList<Build> GetBuildsByMergeNumber(int number);
        IList<RunningBuild.Build> GetRunningBuilds();
        IList<RunningBuild.Build> GetRunningBuilds(int number);
        IList<RunningBuild.Build> GetBuilds(string locator);
        BuildDetails GetBuildDetails(Build build);
        BuildDetails GetBuildDetails(long id);
    }
}
