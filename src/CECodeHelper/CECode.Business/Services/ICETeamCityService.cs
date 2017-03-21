using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        ICEBuild GetAdvantageBuild();
        ICEBuild GetAdvantagePatches();
        ICEBuild GetBuild(int id);
        ICEBuild GetBuild(string number);
        ICEBuildDetails GetBuildDetails(int id);
        IList<ICEBuild> GetBuilds();
        IList<ICEBuild> GetBuilds(string locator);
        IList<ICEBuild> GetMergeBuilds(string mergeNumber);
        IList<ICEBuild> GetRunningBuilds();
    }
}
