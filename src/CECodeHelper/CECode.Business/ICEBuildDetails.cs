using System;

namespace CECode.Business
{
    public interface ICEBuildDetails
    {
        string artifacts { get; set; }
        string changes { get; set; }
        DateTime? finishDate { get; set; }
        DateTime? queuedDate { get; set; }
        DateTime? startDate { get; set; }
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
