using System;
using System.Collections.Generic;

namespace CECode.Branches
{
    public class BranchDetails
    {
        public string Name
        {
            get
            {
                return BranchName.ToString();
            }
            set
            {

            }
        }
        public BranchNames BranchName { get; set; }
        public Version Version { get; set; }
        public bool HasPatches { get; set; }

        public BranchDetails()
        {

        }
    }
}
