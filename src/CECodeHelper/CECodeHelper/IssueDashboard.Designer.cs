namespace CECodeHelper
{
    partial class IssueDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueDashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUpdateIssues = new System.Windows.Forms.ToolStripButton();
            this.btnUpdatePullRequests = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateBuilds = new System.Windows.Forms.ToolStripButton();
            this.lstIssues = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxWorkItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updatePullRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dgvBuilds = new System.Windows.Forms.DataGridView();
            this.dgvPullRequest = new System.Windows.Forms.DataGridView();
            this.ctxPullRequests = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateBuildsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ctxWorkItem.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPullRequest)).BeginInit();
            this.ctxPullRequests.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.accountsToolStripMenuItem.Text = "&Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpdateIssues,
            this.btnUpdatePullRequests,
            this.btnUpdateBuilds});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUpdateIssues
            // 
            this.btnUpdateIssues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdateIssues.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateIssues.Image")));
            this.btnUpdateIssues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateIssues.Name = "btnUpdateIssues";
            this.btnUpdateIssues.Size = new System.Drawing.Size(83, 22);
            this.btnUpdateIssues.Text = "Update Issues";
            this.btnUpdateIssues.Click += new System.EventHandler(this.btnUpdateIssues_Click);
            // 
            // btnUpdatePullRequests
            // 
            this.btnUpdatePullRequests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdatePullRequests.Enabled = false;
            this.btnUpdatePullRequests.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePullRequests.Image")));
            this.btnUpdatePullRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdatePullRequests.Name = "btnUpdatePullRequests";
            this.btnUpdatePullRequests.Size = new System.Drawing.Size(122, 22);
            this.btnUpdatePullRequests.Text = "Update Pull Requests";
            this.btnUpdatePullRequests.Click += new System.EventHandler(this.btnUpdatePullRequests_Click);
            // 
            // btnUpdateBuilds
            // 
            this.btnUpdateBuilds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdateBuilds.Enabled = false;
            this.btnUpdateBuilds.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateBuilds.Image")));
            this.btnUpdateBuilds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateBuilds.Name = "btnUpdateBuilds";
            this.btnUpdateBuilds.Size = new System.Drawing.Size(84, 22);
            this.btnUpdateBuilds.Text = "Update Builds";
            this.btnUpdateBuilds.Click += new System.EventHandler(this.btnUpdateBuilds_Click);
            // 
            // lstIssues
            // 
            this.lstIssues.BackColor = System.Drawing.SystemColors.Info;
            this.lstIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader6});
            this.lstIssues.ContextMenuStrip = this.ctxWorkItem;
            this.lstIssues.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstIssues.FullRowSelect = true;
            this.lstIssues.GridLines = true;
            this.lstIssues.HideSelection = false;
            this.lstIssues.Location = new System.Drawing.Point(0, 49);
            this.lstIssues.Name = "lstIssues";
            this.lstIssues.Size = new System.Drawing.Size(1008, 183);
            this.lstIssues.TabIndex = 2;
            this.lstIssues.UseCompatibleStateImageBehavior = false;
            this.lstIssues.View = System.Windows.Forms.View.Details;
            this.lstIssues.SelectedIndexChanged += new System.EventHandler(this.lstIssues_SelectedIndexChanged);
            this.lstIssues.DoubleClick += new System.EventHandler(this.lstIssues_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Jira #";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "GitHub Issue #";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Project";
            this.columnHeader3.Width = 111;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Team";
            this.columnHeader4.Width = 61;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Summary";
            this.columnHeader2.Width = 443;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Pull Request";
            this.columnHeader6.Width = 128;
            // 
            // ctxWorkItem
            // 
            this.ctxWorkItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePullRequestsToolStripMenuItem,
            this.updateBuildsToolStripMenuItem});
            this.ctxWorkItem.Name = "ctxWorkItem";
            this.ctxWorkItem.Size = new System.Drawing.Size(186, 48);
            // 
            // updatePullRequestsToolStripMenuItem
            // 
            this.updatePullRequestsToolStripMenuItem.Enabled = false;
            this.updatePullRequestsToolStripMenuItem.Name = "updatePullRequestsToolStripMenuItem";
            this.updatePullRequestsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.updatePullRequestsToolStripMenuItem.Text = "Update Pull Requests";
            this.updatePullRequestsToolStripMenuItem.Click += new System.EventHandler(this.updatePullRequestsToolStripMenuItem_Click);
            // 
            // updateBuildsToolStripMenuItem
            // 
            this.updateBuildsToolStripMenuItem.Enabled = false;
            this.updateBuildsToolStripMenuItem.Name = "updateBuildsToolStripMenuItem";
            this.updateBuildsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.updateBuildsToolStripMenuItem.Text = "Update Builds";
            this.updateBuildsToolStripMenuItem.Click += new System.EventHandler(this.updateBuildsToolStripMenuItem_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessages.Location = new System.Drawing.Point(0, 449);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(1008, 71);
            this.txtMessages.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 232);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1008, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.dgvBuilds);
            this.panel1.Controls.Add(this.dgvPullRequest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 214);
            this.panel1.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 104);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1004, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // dgvBuilds
            // 
            this.dgvBuilds.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvBuilds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBuilds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuilds.Location = new System.Drawing.Point(0, 104);
            this.dgvBuilds.Name = "dgvBuilds";
            this.dgvBuilds.Size = new System.Drawing.Size(1004, 106);
            this.dgvBuilds.TabIndex = 1;
            // 
            // dgvPullRequest
            // 
            this.dgvPullRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPullRequest.ContextMenuStrip = this.ctxPullRequests;
            this.dgvPullRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPullRequest.Location = new System.Drawing.Point(0, 0);
            this.dgvPullRequest.MultiSelect = false;
            this.dgvPullRequest.Name = "dgvPullRequest";
            this.dgvPullRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPullRequest.Size = new System.Drawing.Size(1004, 104);
            this.dgvPullRequest.TabIndex = 0;
            // 
            // ctxPullRequests
            // 
            this.ctxPullRequests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateBuildsToolStripMenuItem1});
            this.ctxPullRequests.Name = "ctxPullRequests";
            this.ctxPullRequests.Size = new System.Drawing.Size(148, 26);
            // 
            // updateBuildsToolStripMenuItem1
            // 
            this.updateBuildsToolStripMenuItem1.Name = "updateBuildsToolStripMenuItem1";
            this.updateBuildsToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.updateBuildsToolStripMenuItem1.Text = "Update Builds";
            this.updateBuildsToolStripMenuItem1.Click += new System.EventHandler(this.updateBuildsToolStripMenuItem1_Click);
            // 
            // IssueDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lstIssues);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IssueDashboard";
            this.Text = "IssueDashboard";
            this.Load += new System.EventHandler(this.IssueDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ctxWorkItem.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPullRequest)).EndInit();
            this.ctxPullRequests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUpdateIssues;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.ListView lstIssues;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.DataGridView dgvPullRequest;
        private System.Windows.Forms.DataGridView dgvBuilds;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip ctxWorkItem;
        private System.Windows.Forms.ToolStripMenuItem updatePullRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBuildsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnUpdatePullRequests;
        private System.Windows.Forms.ToolStripButton btnUpdateBuilds;
        private System.Windows.Forms.ContextMenuStrip ctxPullRequests;
        private System.Windows.Forms.ToolStripMenuItem updateBuildsToolStripMenuItem1;
        private System.Windows.Forms.Splitter splitter2;
    }
}