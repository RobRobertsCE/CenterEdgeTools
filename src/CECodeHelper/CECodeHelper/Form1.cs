using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.Jira.Service;

namespace CECodeHelper
{
    public partial class Form1 : Form
    {
        JiraService _jiraService;

        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _jiraService = new JiraService("https://centeredge.atlassian.net", "", "");
                IList<string> projects = _jiraService.GetProjects();
                lstProjects.Items.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = null;
                if (lstProjects.CheckedItems.Count == 0)
                {
                    var items = _jiraService.GetOpenItems();
                    dgv.DataSource = items;
                }
                else
                {
                    string[] projects = new string[lstProjects.CheckedItems.Count];
                    lstProjects.CheckedItems.CopyTo(projects, 0);
                    var items = _jiraService.GetOpenItems(projects);
                    dgv.DataSource = items;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = null;
                var item = _jiraService.GetItem(textBox1.Text);
                dgv.DataSource = item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = null;
                var item = _jiraService.GetAMSIssues();
                dgv.DataSource = item;
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
                dgv.DataSource = null;
                var item = _jiraService.GetRAndDIssues();
                dgv.DataSource = item;
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
    }
}
