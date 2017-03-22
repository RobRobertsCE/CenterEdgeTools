using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        ICEBuild GetAdvantageBuild();
        ICEBuild GetAdvantagePatches();
        ICEBuild GetBuild(long id);
        ICEBuild GetBuild(string number);
        ICEBuildDetails GetBuildDetails(long id);
        IList<ICEBuild> GetBuilds();
        IList<ICEBuild> GetBuilds(string locator);
        IList<ICEBuild> GetMergeBuilds(string mergeNumber);
        IList<ICEBuild> GetRunningBuilds();
    }
}
