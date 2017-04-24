using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.BranchHelper
{
    public class RepoBranch
    {
        public Version Version { get; set; }
        public string Name { get; set; }
        public BranchTitle Title { get; set; }
        public bool RequiresPatches { get; set; }
        public RepoBranch Parent { get; set; }
        public RepoBranch Child { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
