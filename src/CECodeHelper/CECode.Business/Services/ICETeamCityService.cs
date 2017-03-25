using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        ICEBuild GetAdvantageBuild();
        ICEBuild GetAdvantagePatches();
        ICEBuild GetBuild(long id);
        IList<ICEBuild> GetBuildsByMergeNumber(int number);
        IList<ICEBuild> GetBuilds();
        IList<ICEBuild> GetBuilds(string locator);
        IList<ICEBuild> GetMergeBuilds(string mergeNumber);
        IList<ICEBuild> GetRunningBuilds();
        IList<ICEBuild> GetRunningBuilds(int number);
        ICEBuildDetails GetBuildDetails(long id);
    }
}
