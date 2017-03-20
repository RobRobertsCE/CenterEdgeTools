using System;
using System.Collections.Generic;

namespace CECode.TeamCity
{
    public interface ITeamCityService
    {
        Build GetAdvantageBuild();
        Build GetAdvantagePatches();
        IList<TeamCityService.Branch> GetBranches();
        BuildDetails GetBuildDetails(Build build);
        IList<Build> GetBuilds();
        IList<Build> GetBuilds(string buildType);
        Build GetBuild(string buildType);
        IList<RunningBuild.Build> GetRunningBuilds();
    }
}
