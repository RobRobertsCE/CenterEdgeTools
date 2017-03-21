using System.Collections.Generic;

namespace CECode.TeamCity
{
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

    public class RootObject
    {
        public List<Branch> branch { get; set; }
    }
}
