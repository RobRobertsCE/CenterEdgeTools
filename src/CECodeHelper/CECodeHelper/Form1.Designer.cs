namespace CECodeHelper
{
    partial class Form1
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
            this.btnItemsByProject = new System.Windows.Forms.Button();
            this.btnItemByKey = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAMS = new System.Windows.Forms.Button();
            this.dgvJira = new System.Windows.Forms.DataGridView();
            this.lstProjects = new System.Windows.Forms.CheckedListBox();
            this.btnRD = new System.Windows.Forms.Button();
            this.txtJql = new System.Windows.Forms.TextBox();
            this.btnJql = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.dgvGitHub = new System.Windows.Forms.DataGridView();
            this.dgvTeamCity = new System.Windows.Forms.DataGridView();
            this.btnPullRequest = new System.Windows.Forms.Button();
            this.btnGitHubView = new System.Windows.Forms.Button();
            this.btnCEWorkItem = new System.Windows.Forms.Button();
            this.txtJiraKey = new System.Windows.Forms.TextBox();
            this.btnTeamCity = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAdvantagePatches = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamCity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnItemsByProject
            // 
            this.btnItemsByProject.Location = new System.Drawing.Point(8, 104);
            this.btnItemsByProject.Name = "btnItemsByProject";
            this.btnItemsByProject.Size = new System.Drawing.Size(120, 24);
            this.btnItemsByProject.TabIndex = 0;
            this.btnItemsByProject.Text = "Open Items by Project";
            this.btnItemsByProject.UseVisualStyleBackColor = true;
            this.btnItemsByProject.Click += new System.EventHandler(this.btnItemsByProject_Click);
            // 
            // btnItemByKey
            // 
            this.btnItemByKey.Location = new System.Drawing.Point(176, 8);
            this.btnItemByKey.Name = "btnItemByKey";
            this.btnItemByKey.Size = new System.Drawing.Size(96, 24);
            this.btnItemByKey.TabIndex = 1;
            this.btnItemByKey.Text = "Item by Key";
            this.btnItemByKey.UseVisualStyleBackColor = true;
            this.btnItemByKey.Click += new System.EventHandler(this.btnItemByKey_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnAMS
            // 
            this.btnAMS.Location = new System.Drawing.Point(176, 120);
            this.btnAMS.Name = "btnAMS";
            this.btnAMS.Size = new System.Drawing.Size(96, 24);
            this.btnAMS.TabIndex = 3;
            this.btnAMS.Text = "AMS";
            this.btnAMS.UseVisualStyleBackColor = true;
            this.btnAMS.Click += new System.EventHandler(this.btnAMS_Click);
            // 
            // dgvJira
            // 
            this.dgvJira.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJira.Location = new System.Drawing.Point(0, 160);
            this.dgvJira.Name = "dgvJira";
            this.dgvJira.Size = new System.Drawing.Size(1208, 136);
            this.dgvJira.TabIndex = 4;
            // 
            // lstProjects
            // 
            this.lstProjects.FormattingEnabled = true;
            this.lstProjects.Location = new System.Drawing.Point(8, 8);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(160, 94);
            this.lstProjects.TabIndex = 5;
            // 
            // btnRD
            // 
            this.btnRD.Location = new System.Drawing.Point(176, 88);
            this.btnRD.Name = "btnRD";
            this.btnRD.Size = new System.Drawing.Size(96, 24);
            this.btnRD.TabIndex = 6;
            this.btnRD.Text = "R&&D";
            this.btnRD.UseVisualStyleBackColor = true;
            this.btnRD.Click += new System.EventHandler(this.btnRD_Click);
            // 
            // txtJql
            // 
            this.txtJql.Location = new System.Drawing.Point(280, 48);
            this.txtJql.Name = "txtJql";
            this.txtJql.Size = new System.Drawing.Size(544, 20);
            this.txtJql.TabIndex = 7;
            // 
            // btnJql
            // 
            this.btnJql.Location = new System.Drawing.Point(176, 48);
            this.btnJql.Name = "btnJql";
            this.btnJql.Size = new System.Drawing.Size(96, 24);
            this.btnJql.TabIndex = 8;
            this.btnJql.Text = "JQL";
            this.btnJql.UseVisualStyleBackColor = true;
            this.btnJql.Click += new System.EventHandler(this.btnJql_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(832, 8);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(96, 24);
            this.btnAccounts.TabIndex = 9;
            this.btnAccounts.Text = "Accounts";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // dgvGitHub
            // 
            this.dgvGitHub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGitHub.Location = new System.Drawing.Point(0, 304);
            this.dgvGitHub.Name = "dgvGitHub";
            this.dgvGitHub.Size = new System.Drawing.Size(1208, 128);
            this.dgvGitHub.TabIndex = 10;
            // 
            // dgvTeamCity
            // 
            this.dgvTeamCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeamCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamCity.Location = new System.Drawing.Point(0, 440);
            this.dgvTeamCity.Name = "dgvTeamCity";
            this.dgvTeamCity.Size = new System.Drawing.Size(1208, 159);
            this.dgvTeamCity.TabIndex = 11;
            // 
            // btnPullRequest
            // 
            this.btnPullRequest.Location = new System.Drawing.Point(480, 8);
            this.btnPullRequest.Name = "btnPullRequest";
            this.btnPullRequest.Size = new System.Drawing.Size(96, 24);
            this.btnPullRequest.TabIndex = 12;
            this.btnPullRequest.Text = "Pull Request";
            this.btnPullRequest.UseVisualStyleBackColor = true;
            this.btnPullRequest.Click += new System.EventHandler(this.btnPullRequest_Click);
            // 
            // btnGitHubView
            // 
            this.btnGitHubView.Location = new System.Drawing.Point(832, 40);
            this.btnGitHubView.Name = "btnGitHubView";
            this.btnGitHubView.Size = new System.Drawing.Size(96, 24);
            this.btnGitHubView.TabIndex = 13;
            this.btnGitHubView.Text = "GitHub View";
            this.btnGitHubView.UseVisualStyleBackColor = true;
            this.btnGitHubView.Click += new System.EventHandler(this.btnGitHubView_Click);
            // 
            // btnCEWorkItem
            // 
            this.btnCEWorkItem.Location = new System.Drawing.Point(424, 120);
            this.btnCEWorkItem.Name = "btnCEWorkItem";
            this.btnCEWorkItem.Size = new System.Drawing.Size(120, 24);
            this.btnCEWorkItem.TabIndex = 14;
            this.btnCEWorkItem.Text = "CEWorkItem";
            this.btnCEWorkItem.UseVisualStyleBackColor = true;
            this.btnCEWorkItem.Click += new System.EventHandler(this.btnCEWorkItem_Click);
            // 
            // txtJiraKey
            // 
            this.txtJiraKey.Location = new System.Drawing.Point(552, 120);
            this.txtJiraKey.Name = "txtJiraKey";
            this.txtJiraKey.Size = new System.Drawing.Size(192, 20);
            this.txtJiraKey.TabIndex = 15;
            this.txtJiraKey.Text = "9035";
            // 
            // btnTeamCity
            // 
            this.btnTeamCity.Location = new System.Drawing.Point(1016, 112);
            this.btnTeamCity.Name = "btnTeamCity";
            this.btnTeamCity.Size = new System.Drawing.Size(192, 24);
            this.btnTeamCity.TabIndex = 16;
            this.btnTeamCity.Text = "Team City - Running Builds";
            this.btnTeamCity.UseVisualStyleBackColor = true;
            this.btnTeamCity.Click += new System.EventHandler(this.btnTeamCity_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1016, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "Team City - Builds";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(816, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 24);
            this.button2.TabIndex = 18;
            this.button2.Text = "Team City - Advantage_Build";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1016, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "Team City - Advantage Patch Builds";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAdvantagePatches
            // 
            this.btnAdvantagePatches.Location = new System.Drawing.Point(816, 112);
            this.btnAdvantagePatches.Name = "btnAdvantagePatches";
            this.btnAdvantagePatches.Size = new System.Drawing.Size(192, 24);
            this.btnAdvantagePatches.TabIndex = 20;
            this.btnAdvantagePatches.Text = "Team City - Advantage_Patches";
            this.btnAdvantagePatches.UseVisualStyleBackColor = true;
            this.btnAdvantagePatches.Click += new System.EventHandler(this.btnAdvantagePatches_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 610);
            this.Controls.Add(this.btnAdvantagePatches);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTeamCity);
            this.Controls.Add(this.txtJiraKey);
            this.Controls.Add(this.btnCEWorkItem);
            this.Controls.Add(this.btnGitHubView);
            this.Controls.Add(this.btnPullRequest);
            this.Controls.Add(this.dgvTeamCity);
            this.Controls.Add(this.dgvGitHub);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnJql);
            this.Controls.Add(this.txtJql);
            this.Controls.Add(this.btnRD);
            this.Controls.Add(this.lstProjects);
            this.Controls.Add(this.dgvJira);
            this.Controls.Add(this.btnAMS);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnItemByKey);
            this.Controls.Add(this.btnItemsByProject);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJira)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitHub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamCity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnItemsByProject;
        private System.Windows.Forms.Button btnItemByKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAMS;
        private System.Windows.Forms.DataGridView dgvJira;
        private System.Windows.Forms.CheckedListBox lstProjects;
        private System.Windows.Forms.Button btnRD;
        private System.Windows.Forms.TextBox txtJql;
        private System.Windows.Forms.Button btnJql;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.DataGridView dgvGitHub;
        private System.Windows.Forms.DataGridView dgvTeamCity;
        private System.Windows.Forms.Button btnPullRequest;
        private System.Windows.Forms.Button btnGitHubView;
        private System.Windows.Forms.Button btnCEWorkItem;
        private System.Windows.Forms.TextBox txtJiraKey;
        private System.Windows.Forms.Button btnTeamCity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAdvantagePatches;
    }
}