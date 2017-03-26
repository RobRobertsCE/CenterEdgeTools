using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Business
{
    class CEBuildArtifact : ICEBuildArtifact
    {
        public string name { get; set; }
        public long size { get; set; }
        public DateTime modificationTime { get; set; }
        public string metadataHref { get; set; }
        public string contentHref { get; set; }
    }
}
