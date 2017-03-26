using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.TeamCity.Results
{
    public class BuildIssuesRequestResult
    {
        public int count { get; set; }
        public Issueusage[] issueUsage { get; set; }
        public string href { get; set; }
    }

    public class Issueusage
    {
        public Issue issue { get; set; }
        public Changes changes { get; set; }
    }

    public class Issue
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Changes
    {
        public int count { get; set; }
        public Change[] change { get; set; }
    }

    public class Change
    {
        public int id { get; set; }
        public string version { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
    }

}


