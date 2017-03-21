using System.Collections.Generic;

namespace CECode.Business
{
    internal class CECommit : ICECommit
    {
        #region properties
        public string Sha { get; set; }
        public string Repo { get; set; }
        public string Branch { get; set; }
        public string Message { get; set; }
        public IList<string> Files { get; set; }
        #endregion

        #region ctor
        public CECommit()
        {
            Files = new List<string>();
        }
        #endregion
    }
}
