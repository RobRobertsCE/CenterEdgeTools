using System;

namespace CECode.Business
{
    internal class CEBuildDetails : ICEBuildDetails
    {
        public string artifacts { get; set; }
        public string changes { get; set; }
        public DateTime? queuedDate { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? finishDate { get; set; }
        public int id { get; set; }
        public string buildTypeId { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public bool running { get; set; }
        public int percentageComplete { get; set; }
        public string branchName { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
    }
}
