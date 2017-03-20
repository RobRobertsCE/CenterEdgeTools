using System;
namespace CECode.Business.Services
{
    public interface ICETeamCityService
    {
        System.Collections.Generic.IList<CECode.Business.CEBuild> GetRunningBuilds();
    }
}
