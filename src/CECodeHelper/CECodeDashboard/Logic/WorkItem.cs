using System.Collections.Generic;

namespace CECodeDashboard.Logic
{
    public class WorkItem
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public string Project { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Developer { get; set; }
        public IList<WorkItemJiraIssue> JiraIssues { get; set; }
        public IList<WorkItemBuild> Builds { get; set; }

        public WorkItem()
        {
            Builds = new List<WorkItemBuild>();
            JiraIssues = new List<WorkItemJiraIssue>();
        }

        public IList<string> JiraIssueKeys()
        {
            var keys = new List<string>();
            var tag = "ADVANTAGE-";
            if (Title.ToUpper().Contains(tag))
            {
                var i = Title.ToUpper().IndexOf(tag);
                var key = Title.Substring(i, tag.Length + 4);
                keys.Add(key);
            }
            return keys;
        }
    }
}
