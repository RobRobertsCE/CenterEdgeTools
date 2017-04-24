using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CECode.Business;
using CECodeHelper.Forms;

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
                service.ProjectName = "Advantage";

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
        protected virtual void UpdateWorkItemsListView(IList<ICEWorkItem> items)
        {
            if (this.lstIssues.InvokeRequired)
            {
                SafeListUpdateDelegate d = new SafeListUpdateDelegate(UpdateWorkItemsListView);
                Invoke(d, new object[] { items });
            }
            else
            {
                lstIssues.Items.Clear();
                foreach (var item in _presenter.Items)
                {
                    var itemText = "-";
                    if (item.JiraIssues.Count > 0)
                    {
                        itemText = item.JiraIssues[0].IssueNumber.ToString();
                    }
                    var lvi = new ListViewItem(itemText);

                    lvi.SubItems.Add(item.PullRequest.Number.ToString());

                    if (item.JiraIssues.Count > 0)
                    {
                        lvi.SubItems.Add(item.JiraIssues[0].Key);
                        lvi.SubItems.Add(item.JiraIssues[0].Team);
                        lvi.SubItems.Add(item.JiraIssues[0].ItemStatus.ToString());
                        lvi.SubItems.Add(item.JiraIssues[0].Summary);
                    }
                    else
                    {
                        lvi.SubItems.Add("-");
                        lvi.SubItems.Add("-");
                        lvi.SubItems.Add("-");
                        lvi.SubItems.Add("-");
                    }

                    lvi.SubItems.Add(item.PullRequest.Status);
                    lvi.SubItems.Add(item.PullRequest.CommitCount.ToString());
                    lvi.SubItems.Add(item.PullRequest.CommentCount.ToString());
                    lvi.SubItems.Add(item.PullRequest.Title);
                    lvi.SubItems.Add(item.PullRequest.Body);
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

        protected virtual void UpdateBuildsView(IList<ICEBuildDetails> builds)
        {
            if (this.buildDetails1.InvokeRequired)
            {
                SafeBuildUpdateDelegate d = new SafeBuildUpdateDelegate(UpdateBuildsView);
                Invoke(d, new object[] { builds });
            }
            else
            {
                this.buildDetails1.Builds = builds;
            }
        }

        protected virtual void UpdatePullRequestBuildsList()
        {
            if (this.dgvPullRequest.SelectedRows.Count == 0) return;
            this.buildDetails1.Builds = null;
            var selected = (ICEPullRequest)this.dgvPullRequest.SelectedRows[0].DataBoundItem;
            _presenter.UpdateBuilds(selected);
        }

        protected async virtual void UpdateWorkItemsList()
        {
            await _presenter.UpdateIssues();
        }
        #endregion

        #region presenter events
        private void _presenter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "Items")
                {
                    UpdateWorkItemsListView(_presenter.Items);
                    //updatePullRequestsToolStripMenuItem.Enabled = (_presenter.Items.Count > 0);
                    //btnUpdatePullRequests.Enabled = (_presenter.Items.Count > 0);
                    //updateBuildsToolStripMenuItem.Enabled = (_presenter.PullRequests.Count > 0);
                    //btnUpdateBuilds.Enabled = (_presenter.PullRequests.Count > 0);
                }
                else if (e.PropertyName == "PullRequests")
                {
                    //UpdatePullRequestGrid(_presenter.PullRequests);

                    //updateBuildsToolStripMenuItem.Enabled = (_presenter.PullRequests.Count > 0);
                    //btnUpdateBuilds.Enabled = (_presenter.PullRequests.Count > 0);
                }
                else if (e.PropertyName == "Builds")
                {
                    //UpdateBuildsView(_presenter.Builds);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region work item list events
        private async void lstIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBuildsToolStripMenuItem.Enabled = (lstIssues.SelectedItems.Count > 0);
            btnUpdateBuilds.Enabled = (lstIssues.SelectedItems.Count > 0);

            if (lstIssues.SelectedItems.Count == 0) return;
            var selected = (ICEWorkItem)lstIssues.SelectedItems[0].Tag;

            await _presenter.UpdatePullRequest(selected);

            UpdatePullRequestGrid(new List<ICEPullRequest>() { selected.PullRequest });

            pullRequestDetailsView.PullRequest = selected.PullRequest;

            this.buildDetails1.Builds = selected.PullRequest.Builds;
        }
        #endregion

        #region main menu item event handlers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.DisplayAccountsDialog();
        }

        private void dBUpgradeHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.DisplayDbVersionDialog();
        }
        #endregion

        #region main toolbar event handlers
        private void btnUpdateIssues_Click(object sender, EventArgs e)
        {
            UpdateWorkItemsList();
        }
        private void btnUpdateBuilds_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuildsList();
        }
        #endregion

        #region context menu event handlers
        private void updateBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuildsList();
        }
       
        private void updateBuildsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdatePullRequestBuildsList();
        }
        #endregion
    }
}
