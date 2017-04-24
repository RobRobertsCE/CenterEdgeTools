using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.TeamCity.Results
{
    public class BuildArtifactsRequestResult
    {
        public int count { get; set; }
        public File[] file { get; set; }
    }

    public class File
    {
        public string name { get; set; }
        public int size { get; set; }
        public string modificationTime { get; set; }
        public string href { get; set; }
        public Content content { get; set; }
    }

    public class Content
    {
        public string href { get; set; }
    }

}
