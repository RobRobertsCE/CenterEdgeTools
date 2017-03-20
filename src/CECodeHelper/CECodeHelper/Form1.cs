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
using CECode.Business.Services;
using CECode.GitHub;
using CECode.Jira;
using CECode.Jira.Service;
using CECode.TeamCity;

namespace CECodeHelper
{
    public partial class Form1 : Form
    {
        ICEJiraService _jiraService;
        ICEGitHubService _gitHubService;
        ICETeamCityService _teamCityService;

        CEWorkItemService _service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeAccounts();

                LoadJiraProjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void InitializeAccounts()
        {
            try
            {
                var jiraProfile = AccountProfileHelper.GetJIRAAccountInfo();
                _jiraService = new CEJiraService(jiraProfile.URL, jiraProfile.Login, jiraProfile.Password);

                var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
                _gitHubService = new CEGitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);

                var teamCityProfile = AccountProfileHelper.GetGitHubAccountInfo();
                _teamCityService = new CETeamCityService(teamCityProfile.Login, teamCityProfile.Password);

                _service = new CEWorkItemService(_jiraService, _gitHubService, _teamCityService);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private string GetFirstSelectedProject()
        {
            return lstProjects.CheckedItems[0].ToString();
        }
        private string[] GetSelectedProjects()
        {
            string[] projects = new string[lstProjects.CheckedItems.Count];
            lstProjects.CheckedItems.CopyTo(projects, 0);
            return projects;
        }
        private string[] GetAllProjects()
        {
            string[] projects = new string[lstProjects.Items.Count];
            lstProjects.Items.CopyTo(projects, 0);
            return projects;
        }

        #region jira
        private void LoadJiraProjects()
        {
            try
            {
                lstProjects.Items.Clear();
                IList<string> projects = _jiraService.GetProjects();
                foreach (var project in projects.OrderBy(p => p))
                {
                    var itemIdx = lstProjects.Items.Add(project);
                    if ("ADVANTAGE" == project.ToUpper())
                    {
                        lstProjects.SetItemChecked(itemIdx, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnItemsByProject_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                string[] projects;
                if (lstProjects.CheckedItems.Count == 0)
                {
                    projects = GetSelectedProjects();
                }
                else
                {
                    projects = GetSelectedProjects();
                }

                var items = _jiraService.GetOpenItems(projects);
                dgvJira.DataSource = items;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnItemByKey_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                var item = _jiraService.GetItem(textBox1.Text);
                dgvJira.DataSource = new List<CEJiraIssue>() { item };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnAMS_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                var item = _jiraService.GetAMSIssues();
                dgvJira.DataSource = item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnJql_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                var item = _jiraService.GetByJql(txtJql.Text);
                dgvJira.DataSource = item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnRD_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                var item = _jiraService.GetRAndDIssues();
                dgvJira.DataSource = item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            DisplayAccountsDialog();
        }
        private void DisplayAccountsDialog()
        {
            try
            {
                var dialog = new AccountsDialog();
                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void GetJiraProperties()
        {
            try
            {
                _jiraService.GetFilters();
                _jiraService.GetTypes();
                _jiraService.GetStatuses();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region github
        private async void btnPullRequest_Click(object sender, EventArgs e)
        {
            try
            {
                dgvGitHub.DataSource = null;
                string[] projects = GetSelectedProjects();
                var items = await _gitHubService.SearchPullRequests(projects.ToList());
                dgvGitHub.DataSource = items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnGitHubView_Click(object sender, EventArgs e)
        {
            DisplayGitHubView();
        }
        private void DisplayGitHubView()
        {
            try
            {
                var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
                var gitHubService = new GitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);
                var dialog = new CECodeHelper.Forms.GitHubView(gitHubService);
                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        private async void btnCEWorkItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJira.DataSource = null;
                dgvGitHub.DataSource = null;
                dgvTeamCity.DataSource = null;

                var gitHubRepoName = "Advantage";
                var jiraProjectName = "Advantage";
                var jiraIssueId = txtJiraKey.Text; // 9035

                var result = await _service.GetWorkItem(gitHubRepoName, jiraProjectName, jiraIssueId);

                dgvJira.DataSource = new List<ICEJiraIssue>() { result.JiraIssue }; //;
                dgvGitHub.DataSource = result.PullRequests;
                //dgvTeamCity.DataSource = result.;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
