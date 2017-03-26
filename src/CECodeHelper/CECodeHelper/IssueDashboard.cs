using CECode.Business;
using CECode.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.Branches;
using CECodeHelper.Forms;
using CECode.WorkItem.Services;

namespace CECodeHelper
{
    public partial class IssueDashboard : Form, IIssueDashboard
    {
        #region events
        delegate void SafeDisplayMessageDelegate(string message);
        delegate void SafeExceptionHandlerDelegate(Exception ex);
        delegate void SafeListUpdateDelegate(IList<ICEWorkItem> items);
        delegate void SafePullRequestUpdateDelegate(IList<ICEPullRequest> pullRequests);
        delegate void SafeBuildUpdateDelegate(IList<ICEBuildDetails> builds);
        #endregion

        #region fields
        IssueDashboardPresenter _presenter;
        #endregion

        #region properties

        #endregion

        #region ctor/init
        public IssueDashboard()
        {
            InitializeComponent();
        }

        private void IssueDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                var service = CECode.WorkItem.Services.ServiceFactory.GetCEWorkItemService();
                _presenter = new IssueDashboardPresenter(this, service);

                _presenter.PropertyChanged += _presenter_PropertyChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region public methods
        public virtual void ExceptionHandler(Exception ex)
        {
            if (this.InvokeRequired)
            {
                SafeExceptionHandlerDelegate d = new SafeExceptionHandlerDelegate(ExceptionHandler);
                Invoke(d, new object[] { ex });
            }
            else
            {
                Console.WriteLine(ex.ToString());
                DisplayMessage(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        public virtual void DisplayMessage(string message)
        {
            if (txtMessages.InvokeRequired)
            {
                SafeDisplayMessageDelegate d = new SafeDisplayMessageDelegate(DisplayMessage);
                Invoke(d, new object[] { message });
            }
            else
            {
                string formattedMessage = String.Format("{0}: {1}\r\n", DateTime.Now, message);
                txtMessages.AppendText(formattedMessage);
            }
        }
        public virtual void DisplayAccountsDialog()
        {
            var dialog = new AccountProfilesDialog();
            dialog.ShowDialog(this);
        }
        public virtual void DisplayDbVersionDialog()
        {
            var dialog = new DbVersionDialog();
            dialog.ShowDialog(this);
        }
        #endregion

        #region protected methods
        protected virtual void UpdateListView(IList<ICEWorkItem> items)
        {
            if (this.lstIssues.InvokeRequired)
            {
                SafeListUpdateDelegate d = new SafeListUpdateDelegate(UpdateListView);
                Invoke(d, new object[] { items });
            }
            else
            {
                lstIssues.Items.Clear();
                foreach (var item in _presenter.Items)
                {
                    var lvi = new ListViewItem(item.JiraIssue.ItemNumber);
                    if (item.PullRequests.Count > 0)
                        lvi.SubItems.Add(item.PullRequests[0].Number.ToString());
                    else
                        lvi.SubItems.Add("-");
                    lvi.SubItems.Add(item.JiraIssue.Key);
                    lvi.SubItems.Add(item.JiraIssue.Team);
                    lvi.SubItems.Add(item.JiraIssue.ItemStatus.ToString());
                    lvi.SubItems.Add(item.JiraIssue.Summary);
                    if (item.PullRequests.Count > 0)
                        lvi.SubItems.Add(item.PullRequests.Count.ToString());
                    else
                        lvi.SubItems.Add("-");

                    lvi.Tag = item;
                    lstIssues.Items.Add(lvi);
                }
            }
        }

        protected virtual void UpdatePullRequestGrid(IList<ICEPullRequest> pullRequests)
        {
            if (this.dgvPullRequest.InvokeRequired)
            {
                SafePullRequestUpdateDelegate d = new SafePullRequestUpdateDelegate(UpdatePullRequestGrid);
                Invoke(d, new object[] { pullRequests });
            }
            else
            {
                dgvPullRequest.DataSource = pullRequests;
            }
        }

        protected virtual void UpdateBuildGrid(IList<ICEBuildDetails> builds)
        {
            if (this.dgvPullRequest.InvokeRequired)
            {
                SafeBuildUpdateDelegate d = new SafeBuildUpdateDelegate(UpdateBuildGrid);
                Invoke(d, new object[] { builds });
            }
            else
            {
                dgvBuilds.DataSource = builds;
            }
        }

        protected virtual void UpdatePullRequests()
        {
            if (lstIssues.SelectedItems.Count == 0) return;
            var selected = (ICEWorkItem)lstIssues.SelectedItems[0].Tag;
            _presenter.UpdatePullRequests(selected);
        }

        protected virtual void UpdatePullRequestBuilds()
        {
            if (this.dgvPullRequest.SelectedRows.Count == 0) return;
            var selected = (ICEPullRequest)this.dgvPullRequest.SelectedRows[0].DataBoundItem;
            _presenter.UpdateBuilds(selected);
        }

        protected async virtual void UpdateIssueList()
        {
            await _presenter.UpdateIssues();
        }
        #endregion

        #region event handlers
        private void _presenter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "Items")
                {
                    UpdateListView(_presenter.Items);

                    //updatePullRequestsToolStripMenuItem.Enabled = (_presenter.Items.Count > 0);
                    //btnUpdatePullRequests.Enabled = (_presenter.Items.Count > 0);
                    //updateBuildsToolStripMenuItem.Enabled = (_presenter.PullRequests.Count > 0);
                    //btnUpdateBuilds.Enabled = (_presenter.PullRequests.Count > 0);
                }
                else if (e.PropertyName == "PullRequests")
                {
                    UpdatePullRequestGrid(_presenter.PullRequests);

                    //updateBuildsToolStripMenuItem.Enabled = (_presenter.PullRequests.Count > 0);
                    //btnUpdateBuilds.Enabled = (_presenter.PullRequests.Count > 0);
                }
                else if (e.PropertyName == "Builds")
                {
                    UpdateBuildGrid(_presenter.Builds);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateIssues_Click(object sender, EventArgs e)
        {
            UpdateIssueList();
        }

        private void lstIssues_DoubleClick(object sender, EventArgs e)
        {
            if (lstIssues.SelectedItems.Count == 0) return;
            var selected = (ICEWorkItem)lstIssues.SelectedItems[0].Tag;
            _presenter.WorkItemSelected(selected);
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.DisplayAccountsDialog();
        }

        private void lstIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePullRequestsToolStripMenuItem.Enabled = (lstIssues.SelectedItems.Count > 0);
            btnUpdatePullRequests.Enabled = (lstIssues.SelectedItems.Count > 0);
            updateBuildsToolStripMenuItem.Enabled = (lstIssues.SelectedItems.Count > 0);
            btnUpdateBuilds.Enabled = (lstIssues.SelectedItems.Count > 0);

            if (lstIssues.SelectedItems.Count == 0) return;
            var selected = (ICEWorkItem)lstIssues.SelectedItems[0].Tag;
            _presenter.WorkItemSelected(selected);
        }

        #region work item context menu
        private void updatePullRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePullRequests();
        }

        private void updateBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuilds();
        }
        #endregion

        #region pull request context menu
        private void updateBuildsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuilds();
        }
        #endregion

        private void btnUpdatePullRequests_Click(object sender, EventArgs e)
        {
            UpdatePullRequests();
        }

        private void btnUpdateBuilds_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuilds();
        }
        #endregion

        private void dBUpgradeHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.DisplayDbVersionDialog();
        }
    }

    public class IssueDashboardPresenter : INotifyPropertyChanged
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region fields
        ICEWorkItemService _workItemService;
        IIssueDashboard _window;
        DateTime _lastUpdate;
        BranchMap _currentBranchMap;
        #endregion

        #region properties
        private IList<ICEWorkItem> _items = new List<ICEWorkItem>();
        public IList<ICEWorkItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private IList<ICEPullRequest> _pullRequests = new List<ICEPullRequest>();
        public IList<ICEPullRequest> PullRequests
        {
            get
            {
                return _pullRequests;
            }
            set
            {
                _pullRequests = value;
                OnPropertyChanged("PullRequests");
            }
        }

        private IList<ICEBuildDetails> _builds = new List<ICEBuildDetails>();
        public IList<ICEBuildDetails> Builds
        {
            get
            {
                return _builds;
            }
            set
            {
                _builds = value;
                OnPropertyChanged("Builds");
            }
        }
        #endregion

        #region ctor/init
        public IssueDashboardPresenter(IIssueDashboard window, ICEWorkItemService workItemService)
        {
            _window = window;
            _workItemService = workItemService;
            _lastUpdate = DateTime.MinValue;

            InitializePresenter();
        }

        protected virtual void InitializePresenter()
        {
            try
            {
                var branchMapFactory = new BranchMapFactory();
                _currentBranchMap = branchMapFactory.GetCurrentMap();               
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region public methods
        public async virtual Task UpdateIssues()
        {
            await Task.Run(() =>
                   {
                       try
                       {
                           var updatedItems = _workItemService.GetWorkItems("Advantage", "Advantage");

                           foreach (var item in updatedItems.Result)
                           {
                               if (this.Items.Any(i => i.JiraIssue.ItemNumber == item.JiraIssue.ItemNumber))
                               {
                                   // TODO: update it
                               }
                               else
                               {
                                   // add it
                                   Items.Add(item);
                               }
                           }

                           OnPropertyChanged("Items");

                           _lastUpdate = DateTime.Now;
                       }
                       catch (Exception ex)
                       {
                           ExceptionHandler(ex);
                       }
                   });
        }

        public virtual void WorkItemSelected(ICEWorkItem workItem)
        {
            PullRequests = workItem.PullRequests;
            Builds = workItem.PullRequests.SelectMany(p => p.Builds).ToList();
        }

        public virtual void DisplayAccountsDialog()
        {
            try
            {
                _window.DisplayAccountsDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public virtual void UpdatePullRequests(ICEWorkItem workItem)
        {
            try
            {
                _workItemService.UpdatePullRequests(workItem, _currentBranchMap.Name);
                PullRequests = workItem.PullRequests;
                Builds = new List<ICEBuildDetails>();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public virtual void UpdateBuilds(ICEPullRequest pullRequest)
        {
            try
            {
                _workItemService.UpdateBuild(pullRequest);
                Builds = pullRequest.Builds;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        } 

        public virtual void DisplayDbVersionDialog()
        {
            try
            {
                _window.DisplayDbVersionDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region protected virtual methods
        protected virtual void ExceptionHandler(Exception ex)
        {
            _window.ExceptionHandler(ex);
        }

        protected virtual void DisplayMessage(string message)
        {
            _window.DisplayMessage(message);
        } 
        #endregion
    }
}
