using System.Collections.Generic;

namespace CECode.Business
{
    public class CECommit : CECode.Business.ICECommit
    {
        public string Sha { get; set; }
        public string Repo { get; set; }
        public string Branch { get; set; }
        public string Message { get; set; }

        public IList<string> Files { get; set; }

        public CECommit()
        {
            Files = new List<string>();
        }
    }
}
