using System.Collections.Generic;

namespace CECode.TeamCity.Results
{ 
    public class BranchesRequestResult
    {
        public List<Branch> branch { get; set; }       
    }

    public class Branch
    {
        public string name { get; set; }
        public bool @default { get; set; }

        public override string ToString()
        {
            if (true == @default)
            {
                return name + " (default)";
            }
            else
            {
                return name;
            }
        }
    }
}
