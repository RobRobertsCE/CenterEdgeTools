using System.Collections.Generic;

namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        ICEBuildDetails GetAdvantageBuild();
        ICEBuildDetails GetPatchBuild();
        ICEBuildDetails GetAutoMergeBuild();
        ICEBuildDetails GetBuild(long id);
        
        IList<ICEBuild> GetBuilds();
        IList<ICEBuild> GetBuildsQuery(string locator);
        IList<ICEBuild> GetBuildTypeBuildsQuery(string buildType);

        IList<ICEBuildDetails> GetBuildsByMergeNumber(int number);

        IList<ICEBuild> GetQueuedBuilds();
        IList<ICEBuild> GetRunningBuilds();
    }
}
