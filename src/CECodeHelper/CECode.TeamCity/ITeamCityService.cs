using System;
namespace CECode.TeamCity
{
    public interface ITeamCityService
    {
        Build GetAdvantageBuild();
        System.Collections.Generic.IList<TeamCityService.Branch> GetBranches();
        BuildDetails GetBuildDetails(Build build);
        System.Collections.Generic.IList<Build> GetBuilds();
        System.Collections.Generic.IList<RunningBuild.Build> GetRunningBuilds();
    }
}
