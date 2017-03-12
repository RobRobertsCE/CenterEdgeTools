using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Jira
{
    public interface IJiraListItem
    {
        int ItemNumber { get; set; }

        string ProjectName { get; set; }

        string Key { get; }

        string Description { get; set; }

        string ItemStatus { get; set; }

        int ItemType { get; set; }
    }
}
