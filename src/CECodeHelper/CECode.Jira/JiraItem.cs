using System;
using System.Collections.Generic;

namespace CECode.Jira
{
    public class JiraItem
    {
        public string ItemNumber { get; set; }

        public string ProjectName { get; set; }

        public string Key { get; set; }

        public string Summary { get; set; }

        public JiraPriority Priority { get; set; }

        public JiraStatus ItemStatus { get; set; }

        public JiraIssueType ItemType { get; set; }

        public IList<string> AffectsVersions { get; set; }

        public IList<string> FixVersions { get; set; }

        public string Team { get; set; }

        public string Sprint { get; set; }
        
        public string AssignedTo { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public JiraItem()
        {
            AffectsVersions = new List<string>();
            FixVersions = new List<string>();
        }        
    }
}
