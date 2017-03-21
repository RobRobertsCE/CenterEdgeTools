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
    }
}
