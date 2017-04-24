using System;
using System.Collections.Generic;
using System.Linq;

namespace CECode.Branches
{
    public class BranchMap
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private List<BranchDetails> _branches;
        public List<BranchDetails> Branches
        {
            get
            {
                return _branches.OrderBy(b => (int)b.BranchName).ToList();
            }
            set
            {
                _branches = value;
            }
        }

        public Version GetVersion(BranchNames branch)
        {
            return Branches.FirstOrDefault(b => b.BranchName == branch).Version;
        }
        public BranchDetails GetBranch(Version version)
        {
            return Branches.FirstOrDefault(b => b.Version.Major == version.Major && b.Version.Minor == version.Minor);
        }

        public BranchMap()
        {
            _branches = new List<BranchDetails>();
        }
    }
}
