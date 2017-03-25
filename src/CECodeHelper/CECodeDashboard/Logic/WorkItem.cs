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
        public WorkItemJiraIssue JiraIssue { get; set; }
        public IList<WorkItemBuild> Builds { get; set; }

        public WorkItem()
        {
            Builds = new List<WorkItemBuild>();
            JiraIssue = new WorkItemJiraIssue();
        }
    }
}
