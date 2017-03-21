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

namespace CECodeHelper
{
    public partial class IssueDashboard : Form, IIssueDashboard
    {
        #region events
        delegate void SafeDisplayMessageDelegate(string message);
        delegate void SafeExceptionHandlerDelegate(Exception ex);
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
                var service = ServiceFactory.GetCEWorkItemService();
                _presenter = new IssueDashboardPresenter(this, service);

                _presenter.PropertyChanged += _presenter_PropertyChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region common
        // TODO: Implement logging
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
        #endregion

        public void DisplayPullRequests()
        {

        }

        private void _presenter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "Items")
                {
                    lstIssues.Items.Clear();
                    foreach (var item in _presenter.Items)
                    {
                        var lvi = new ListViewItem(item.JiraIssue.ItemNumber);
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
                else if (e.PropertyName == "PullRequests")
                {
                    dgvPullRequest.DataSource = _presenter.PullRequests;
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
            _presenter.UpdateIssues();
        }

        private void lstIssues_DoubleClick(object sender, EventArgs e)
        {
            if (lstIssues.SelectedItems.Count == 0) return;
            var selected = (ICEWorkItem)lstIssues.SelectedItems[0].Tag;
            _presenter.WorkItemSelected(selected);
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
                OnPropertyChanged(nameof(Items));
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
                OnPropertyChanged(nameof(PullRequests));
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
                // UpdateIssues();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        public async virtual void UpdateIssues()
        {
            try
            {
                var updatedItems = await _workItemService.GetWorkItems("Advantage", "Advantage");

                foreach (var item in updatedItems)
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

                OnPropertyChanged(nameof(Items));

                _lastUpdate = DateTime.Now;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void WorkItemSelected(ICEWorkItem workItem)
        {
            PullRequests = workItem.PullRequests;
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            _window.ExceptionHandler(ex);
        }

        protected virtual void DisplayMessage(string message)
        {
            _window.DisplayMessage(message);
        }
    }
}
