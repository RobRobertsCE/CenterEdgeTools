using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.Business;

namespace CECode.WorkItem.Views
{
    public partial class BuildDetails : UserControl
    {
        private IList<ICEBuildDetails> _builds;
        public IList<ICEBuildDetails> Builds
        {
            get
            {
                return _builds;
            }
            set
            {
                _builds=value;
                if (null!=_builds)
                    this.iCEBuildDetailsBindingSource.DataSource=_builds;
            }
        }

        public BuildDetails()
        {
            InitializeComponent();
        }
    }
}
