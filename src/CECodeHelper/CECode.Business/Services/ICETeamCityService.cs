using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        IList<CEBuild> GetRunningBuilds();
        IList<CEBuild> GetBuilds();
        IList<CEBuild> GetPatchBuilds();
        CEBuild GetAdvantageBuild();
        CEBuild GetAdvantagePatches();

        //IList<TeamCityService.Branch> GetBranches();

        //BuildDetails GetBuildDetails(Build build);
    }
}
