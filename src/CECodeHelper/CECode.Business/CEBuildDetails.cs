using System;

namespace CECode.Business
{
    internal class CEBuildDetails : CEBuild, ICEBuildDetails
    {
        #region properties
        public string artifacts { get; set; }
        public string changes { get; set; }
        public DateTime? queuedDate { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? finishDate { get; set; }
        #endregion
    }
}
