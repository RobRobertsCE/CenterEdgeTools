using System.Collections.Generic;

namespace CECode.Business
{
    public interface ICECommit
    {
        string Branch { get; set; }
        IList<string> Files { get; set; }
        string Message { get; set; }
        string Repo { get; set; }
        string Sha { get; set; }
    }
}
