using CECode.Business.Services;
using CECodeDashboard.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.Authentication;
using CECode.Business;
using CECode.Logging;

namespace CECodeDashboard
{
    public partial class TeamCityTestApp : Form
    {
        #region fields
        //WorkItemService _service;
        ICETeamCityService _teamCity;
        #endregion

        #region ctor
        public TeamCityTestApp()
        {
            InitializeComponent();

            //_service = new WorkItemService();
            var teamCityProfile = AccountProfileHelper.GetTeamCityAccountInfo();
            _teamCity = ServiceFactory.GetCETeamCityService(teamCityProfile.Login, teamCityProfile.Password);
            Logger.Log.Debug("TeamCity Test App Started");
        }
        #endregion

        #region common
        void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        int GetIntParam()
        {
            return Int32.Parse(txtParam.Text);
        }

        long GetLongParam()
        {
            return long.Parse(txtParam.Text);
        }

        string GetStringParam()
        {
            return txtParam.Text;
        }
        #endregion

        #region work item
        private void button1_Click(object sender, EventArgs e)
        {
            RunTest();
        }

        void RunTest()
        {
            try
            {
                //var workItems = new List<WorkItem>();

                //var pullRequests = await _service.GetPullRequests("Advantage", DateTime.Now.AddDays(-10), 20);
                //foreach (var pullRequest in pullRequests)
                //{
                //    var workItem = new WorkItem()
                //    {
                //        Number = pullRequest.Number,
                //        Id = pullRequest.Id,
                //        Status = pullRequest.Status,
                //        Title = pullRequest.Title,
                //        Developer = pullRequest.User
                //    };

                //    var jiraIssues = await _service.GetJiraIssues(workItem.JiraIssueKeys());
                //    foreach (var jiraIssue in jiraIssues)
                //    {
                //        var workItemJiraIssue = new WorkItemJiraIssue()
                //        {
                //            JiraKey = jiraIssue.Key,
                //            JiraTitle = jiraIssue.Summary,
                //            JiraStatus = jiraIssue.ItemStatus.ToString(),
                //            AffectsVersion = String.Join(",", jiraIssue.AffectsVersions.ToArray()),
                //            FixVersion = String.Join(",",jiraIssue.FixVersions.ToArray()),
                //            Team = jiraIssue.Team
                //        };
                //        workItem.JiraIssues.Add(workItemJiraIssue);
                //    }

                //    if (workItem.Status == "Open")
                //    {
                //        var builds = await _service.GetBuilds(pullRequest.Number);

                //        foreach (var build in builds)
                //        {
                //            var workItemBuild = new WorkItemBuild()
                //            {
                //                Id = build.id,
                //                Number = build.number,
                //                Status = build.status,
                //                State = build.state,
                //                Branch = build.branchName,
                //                PercentComplete = build.percentageComplete
                //            };

                //            workItem.Builds.Add(workItemBuild);
                //        }
                //    }

                //    workItems.Add(workItem);
                //}
                //foreach (var workItem in workItems)
                //{
                //    Console.WriteLine("**************************************************************");
                //    Console.WriteLine("{0} {1} {2} {3}", workItem.Number, workItem.Status, workItem.Developer, workItem.Title);
                //    Console.WriteLine("------------- JIRA ------------");
                //    foreach (var issue in workItem.JiraIssues)
                //    {
                //        Console.WriteLine("\t{0} {1} [{2}] [{3}] {4}", issue.JiraKey, issue.Team, issue.JiraStatus, issue.JiraTitle, issue.AffectsVersion);
                //    }
                //    Console.WriteLine("------------- GitHib ------------");
                //    foreach (var build in workItem.Builds)
                //    {
                //        Console.WriteLine("\t{0} {1} {2} {3} {4}", build.Number, build.Status, build.State, build.Branch, build.PercentComplete);
                //    }
                //    Console.WriteLine();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        private void btnAdvBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _teamCity.GetAdvantageBuild();
                dgv.DataSource = new List<ICEBuildDetails>() { result };
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnAdvPatches_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _teamCity.GetPatchBuild();
                dgv.DataSource = new List<ICEBuildDetails>() { result };
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnAutoMergeBuild_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _teamCity.GetAutoMergeBuild();
                dgv.DataSource = new List<ICEBuildDetails>() { result };
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildById_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _teamCity.GetBuild(GetLongParam());
                dgv.DataSource = new List<ICEBuildDetails>() { result };
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildDetails_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _teamCity.GetBuild(GetLongParam());
                dgv.DataSource = new List<ICEBuildDetails>() { result };
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetBuilds();
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildsByLocator_Click(object sender, EventArgs e)
        {
            try
            {
                var paramString = String.Format("locator={0}", GetStringParam());
                var results = _teamCity.GetBuildsQuery(paramString);
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnBuildTypesQuery_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetBuildTypeBuildsQuery(GetStringParam());
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildsByMergeNumber_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetBuildsByPullRequest(GetIntParam());
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetRunningBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetRunningBuilds();
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetQueuedBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetQueuedBuilds();
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildArtifacts_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetBuildArtifacts(GetLongParam());
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnGetBuildIssues_Click(object sender, EventArgs e)
        {
            try
            {
                var results = _teamCity.GetBuildRelatedIssues(GetLongParam());
                dgv.DataSource = results;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}
