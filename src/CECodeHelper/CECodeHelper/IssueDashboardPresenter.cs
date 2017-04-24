using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using CECode.Branches;
using CECode.Business;
using CECode.Business.Services;
using CECode.WorkItem.Services;

namespace CECodeHelper
{
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

        //private IList<ICEPullRequest> _pullRequests = new List<ICEPullRequest>();
        //public IList<ICEPullRequest> PullRequests
        //{
        //    get
        //    {
        //        return _pullRequests;
        //    }
        //    set
        //    {
        //        _pullRequests = value;
        //        OnPropertyChanged("PullRequests");
        //    }
        //}

        //private IList<ICEBuildDetails> _builds = new List<ICEBuildDetails>();
        //public IList<ICEBuildDetails> Builds
        //{
        //    get
        //    {
        //        return _builds;
        //    }
        //    set
        //    {
        //        _builds = value;
        //        OnPropertyChanged("Builds");
        //    }
        //}
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
                    var updatedItems = _workItemService.GetPullRequests(RequestState.All, DateTime.Now.AddDays(-3));

                    foreach (var item in updatedItems.Result)
                    {
                        //if (this.Items.Any(i => i.JiraIssues[0].ItemNumber == item.JiraIssues[0].ItemNumber))
                        //{
                        //    // TODO: update it
                        //}
                        //else
                        //{
                        //    // add it
                        //    Items.Add(item);
                        //}

                        Items.Add(item);
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
            //PullRequests = new List<ICEPullRequest>() { workItem.PullRequest };
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

        public async virtual Task<ICEWorkItem> UpdatePullRequest(ICEWorkItem item)
        {
            ICEWorkItem result = item;
            try
            {
                result = await _workItemService.GetPullRequestDetails(item);
                result = await _workItemService.UpdateBuilds(result);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return result;
        }

        public virtual void UpdateBuilds(ICEPullRequest pullRequest)
        {
            try
            {
                //_workItemService.UpdateBuild(pullRequest);
                //Builds = pullRequest.Builds;
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
