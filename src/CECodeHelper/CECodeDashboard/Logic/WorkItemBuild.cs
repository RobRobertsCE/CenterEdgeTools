namespace CECodeDashboard.Logic
{
    public class WorkItemBuild
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Branch { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public int PercentComplete { get; set; }
    }
}
