using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.GitHub;
using Octokit;

namespace CECodeHelper.Forms
{
    public partial class GitHubView : Form
    {
        GitHubService _gitHubService;

        public GitHubView()
        {
            InitializeComponent();
        }

        public GitHubView(GitHubService service)
            : this()
        {
            _gitHubService = service;
        }

        private void btnGetBranch_Click(object sender, EventArgs e)
        {
            GetBranches();
        }

        private async void GetBranches()
        {
            try
            {
                var branches = await _gitHubService.GetBranches("Advantage");

                DisplayBranches(branches);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DisplayBranches(IReadOnlyList<Branch> branches)
        {
            trvBranch.Nodes.Clear();

            var rootNode = new TreeNode("Advantage");

            foreach (var branch in branches)
            {
                var branchNode = new TreeNode(branch.Name);
                branchNode.Tag = branch;
                var placeholder = new TreeNode("PLACEHOLDER");
                branchNode.Nodes.Add(placeholder);
                rootNode.Nodes.Add(branchNode);
            }

            rootNode.Expand();
            trvBranch.Nodes.Add(rootNode);
        }

        private async void trvBranch_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "PLACEHOLDER")
            {
                e.Node.Nodes.Clear();
                Branch selectedBranch = (Branch)e.Node.Tag;

                var commits = await _gitHubService.GetCommits("Advantage", selectedBranch.Name);

                foreach (var commit in commits)
                {
                    var commitNode = new TreeNode(String.Format("{0} {1} {2}", commit.Sha.Substring(0, 8), commit.Commit.Author.Name, commit.Commit.Message));
                    commitNode.Tag = commit;
                    e.Node.Nodes.Add(commitNode);
                }

                e.Node.Expand();
                e.Cancel = true;
            }
        }

        private void GetBranchCommits(string id)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (trvBranch.SelectedNode == null)
                return;

            GitHubCommit commit;
            string sha = String.Empty;
            if (trvBranch.SelectedNode.Tag is Branch)
            {
                var branch = (Branch)trvBranch.SelectedNode.Tag;
                sha = branch.Commit.Sha;
            }
            else if (trvBranch.SelectedNode.Tag is GitHubCommit)
            {
                commit = (GitHubCommit)trvBranch.SelectedNode.Tag;
                sha = commit.Sha;
            }

            txtBranchCheck.Clear();
            DisplayCommitInBranchStatus(sha, "master");
            DisplayCommitInBranchStatus(sha, "beta");
            DisplayCommitInBranchStatus(sha, "develop");
        }

        async void DisplayCommitInBranchStatus(string sha, string branchName)
        {
            var result = await _gitHubService.CheckCommitInBranch("Advantage", branchName, sha);
            var statusMessage = String.Format("Commit {0} is {1}in branch {2} [{3}]", sha.Substring(0, 8), CompareStatusIsTrue(result.Status) ? "" : "NOT ", branchName, result.Status);
            Console.WriteLine(statusMessage);
            txtBranchCheck.AppendText(statusMessage + "\r\n");
        }

        async Task<bool> CommitIsInBranch(string branchName, string sha)
        {
            var result = await _gitHubService.CheckCommitInBranch("Advantage", branchName, sha);
            return CompareStatusIsTrue(result.Status);
        }

        bool CompareStatusIsTrue(string status)
        {
            return (status == "identical" || status == "behind");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var rootNode = trvBranch.Nodes[0];
                var mainBranches = new List<string>() { "master", "beta", "develop" };
                foreach (TreeNode branchNode in rootNode.Nodes)
                {
                    var branch = (Branch)branchNode.Tag;
                    string sha = branch.Commit.Sha;

                    foreach (var mainBranch in mainBranches)
                    {
                        var isInBranch = await CommitIsInBranch(mainBranch, sha);
                        var statusMessage = String.Format("Feature branch '{0}' is {1}in main branch '{2}' [{3}]", branch.Name, isInBranch ? "" : "NOT ", mainBranch, sha.Substring(0, 8));
                        sb.AppendLine(statusMessage);
                    }
                }
                Console.WriteLine("Writing report...");
                System.IO.File.WriteAllText(@"C:\GitHubFeaturebranches\FeatureBranchReport.txt", sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
