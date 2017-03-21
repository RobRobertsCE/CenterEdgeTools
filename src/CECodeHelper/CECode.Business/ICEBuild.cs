using System;
namespace CECode.Business
{
    public interface ICEBuild
    {
        string branchName { get; set; }
        string buildTypeId { get; set; }
        string href { get; set; }
        int id { get; set; }
        string number { get; set; }
        int percentageComplete { get; set; }
        bool running { get; set; }
        string state { get; set; }
        string status { get; set; }
        string webUrl { get; set; }
    }
}
