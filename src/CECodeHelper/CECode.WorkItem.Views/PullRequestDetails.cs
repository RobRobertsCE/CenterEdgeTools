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
    public partial class PullRequestDetails : UserControl
    {
        private ICEPullRequest _pullRequest;
        public ICEPullRequest PullRequest
        {
            get
            {
                return _pullRequest;
            }
            set
            {
                _pullRequest = value;
                if (null != _pullRequest)
                    this.iCEPullRequestBindingSource.DataSource = _pullRequest;
            }
        }

        public PullRequestDetails()
        {
            InitializeComponent();
        }

        private void btnHtmlUrl_Click(object sender, EventArgs e)
        {
            GoToUrl(((Button)sender).Tag.ToString());
        }

        private void btnDiffUrl_Click(object sender, EventArgs e)
        {
            GoToUrl(((Button)sender).Tag.ToString());
        }

        private void btnPatchUrl_Click(object sender, EventArgs e)
        {
            GoToUrl(((Button)sender).Tag.ToString());
        }

        private void btnUrl_Click(object sender, EventArgs e)
        {
            GoToUrl(((Button)sender).Tag.ToString());
        }

        private void btnJiraUrl_Click(object sender, EventArgs e)
        {
            GoToUrl(((Button)sender).Tag.ToString());
        }

        private void GoToUrl(string url)
        {
            Console.WriteLine(url);
        }
    }
}
