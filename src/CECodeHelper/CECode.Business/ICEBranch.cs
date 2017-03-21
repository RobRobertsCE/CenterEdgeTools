using System;
namespace CECode.Business
{
    public interface ICEBranch
    {
        string Name { get; set; }
        string RepositoryName { get; set; }
        string Sha { get; set; }
    }
}
