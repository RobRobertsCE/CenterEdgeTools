using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Jira.Service
{
    public class JiraItemRequest
    {
        public IList<string> Projects { get; set; }
        public DateTime UpdatedSince { get; set; }
        public IList<string> Status { get; set; }
    }
}
