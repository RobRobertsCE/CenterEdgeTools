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
using CECode.GitHub;
using CECode.Jira;
using CECode.Jira.Service;
using CECode.TeamCity;

namespace CECodeHelper
{
    public partial class Form1 : Form
    {
        JiraService _jiraService;
        GitHubService _gitHubService;
        TeamCityService _teamCityService;

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
                _jiraService = new JiraService(jiraProfile.URL, jiraProfile.Login, jiraProfile.Password);

                var gitHubProfile = AccountProfileHelper.GetGitHubAccountInfo();
                _gitHubService = new GitHubService(gitHubProfile.Login, gitHubProfile.Token, gitHubProfile.Owner);

                var teamCityProfile = AccountProfileHelper.GetGitHubAccountInfo();
                _teamCityService = new TeamCityService(teamCityProfile.Login, teamCityProfile.Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string[] GetSelectedProjects()
        {
            string[] projects = new string[lstProjects.CheckedItems.Count];
            lstProjects.CheckedItems.CopyTo(projects, 0);
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
                    lstProjects.Items.Add(project);
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
                if (lstProjects.CheckedItems.Count == 0)
                {
                    var items = _jiraService.GetOpenItems();
                    dgvJira.DataSource = items;
                }
                else
                {
                    string[] projects = GetSelectedProjects();
                    var items = _jiraService.GetOpenItems(projects);
                    dgvJira.DataSource = items;
                }

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
                dgvJira.DataSource = new List<JiraItem>() { item };
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
                var items = await _gitHubService.GetRequests(projects.ToList());
                dgvGitHub.DataSource = items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
