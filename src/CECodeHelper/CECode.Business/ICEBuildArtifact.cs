using System;
namespace CECode.Business
{
    public interface ICEBuildArtifact
    {
        string contentHref { get; set; }
        string metadataHref { get; set; }
        DateTime modificationTime { get; set; }
        string name { get; set; }
        long size { get; set; }
    }
}
