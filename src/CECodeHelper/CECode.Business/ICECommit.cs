using System;
namespace CECode.Business
{
    public interface ICECommit
    {
        string Branch { get; set; }
        System.Collections.Generic.IList<string> Files { get; set; }
        string Message { get; set; }
        string Repo { get; set; }
        string Sha { get; set; }
    }
}
