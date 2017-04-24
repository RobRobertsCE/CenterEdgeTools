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
            this.btnAdvantagePatches = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBuildNumber = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.txtBuildId = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.txtMergeNumber = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtLocator = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamCity)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dgvTeamCity.Size = new System.Drawing.Size(1307, 159);
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
            this.btnCEWorkItem.Location = new System.Drawing.Point(280, 88);
            this.btnCEWorkItem.Name = "btnCEWorkItem";
            this.btnCEWorkItem.Size = new System.Drawing.Size(120, 24);
            this.btnCEWorkItem.TabIndex = 14;
            this.btnCEWorkItem.Text = "CEWorkItem";
            this.btnCEWorkItem.UseVisualStyleBackColor = true;
            this.btnCEWorkItem.Click += new System.EventHandler(this.btnCEWorkItem_Click);
            // 
            // txtJiraKey
            // 
            this.txtJiraKey.Location = new System.Drawing.Point(280, 120);
            this.txtJiraKey.Name = "txtJiraKey";
            this.txtJiraKey.Size = new System.Drawing.Size(120, 20);
            this.txtJiraKey.TabIndex = 15;
            this.txtJiraKey.Text = "9035";
            // 
            // btnTeamCity
            // 
            this.btnTeamCity.Location = new System.Drawing.Point(128, 48);
            this.btnTeamCity.Name = "btnTeamCity";
            this.btnTeamCity.Size = new System.Drawing.Size(120, 24);
            this.btnTeamCity.TabIndex = 16;
            this.btnTeamCity.Text = "Running Builds";
            this.btnTeamCity.UseVisualStyleBackColor = true;
            this.btnTeamCity.Click += new System.EventHandler(this.btnTeamCity_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "All Builds";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 24);
            this.button2.TabIndex = 18;
            this.button2.Text = "Advantage_Build";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdvantagePatches
            // 
            this.btnAdvantagePatches.Location = new System.Drawing.Point(8, 48);
            this.btnAdvantagePatches.Name = "btnAdvantagePatches";
            this.btnAdvantagePatches.Size = new System.Drawing.Size(120, 24);
            this.btnAdvantagePatches.TabIndex = 20;
            this.btnAdvantagePatches.Text = "Advantage_Patches";
            this.btnAdvantagePatches.UseVisualStyleBackColor = true;
            this.btnAdvantagePatches.Click += new System.EventHandler(this.btnAdvantagePatches_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuildNumber);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.txtBuildId);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.txtMergeNumber);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.txtLocator);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnAdvantagePatches);
            this.groupBox1.Controls.Add(this.btnTeamCity);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(416, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 72);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team City";
            // 
            // txtBuildNumber
            // 
            this.txtBuildNumber.Location = new System.Drawing.Point(768, 16);
            this.txtBuildNumber.Name = "txtBuildNumber";
            this.txtBuildNumber.Size = new System.Drawing.Size(56, 20);
            this.txtBuildNumber.TabIndex = 31;
            this.txtBuildNumber.Text = "3144";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(680, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 24);
            this.button9.TabIndex = 29;
            this.button9.Text = "Builds by #";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtBuildId
            // 
            this.txtBuildId.Location = new System.Drawing.Point(624, 16);
            this.txtBuildId.Name = "txtBuildId";
            this.txtBuildId.Size = new System.Drawing.Size(48, 20);
            this.txtBuildId.TabIndex = 28;
            this.txtBuildId.Text = "12107";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(536, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 24);
            this.button6.TabIndex = 27;
            this.button6.Text = "Detail by Id";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(536, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 24);
            this.button7.TabIndex = 26;
            this.button7.Text = "Builds by Id";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtMergeNumber
            // 
            this.txtMergeNumber.Location = new System.Drawing.Point(384, 48);
            this.txtMergeNumber.Name = "txtMergeNumber";
            this.txtMergeNumber.Size = new System.Drawing.Size(56, 20);
            this.txtMergeNumber.TabIndex = 24;
            this.txtMergeNumber.Text = "6008";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(256, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 24);
            this.button5.TabIndex = 23;
            this.button5.Text = "Builds by Merge #";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(256, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 24);
            this.button4.TabIndex = 22;
            this.button4.Text = "Builds by Locator";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtLocator
            // 
            this.txtLocator.Location = new System.Drawing.Point(384, 16);
            this.txtLocator.Name = "txtLocator";
            this.txtLocator.Size = new System.Drawing.Size(144, 20);
            this.txtLocator.TabIndex = 21;
            this.txtLocator.Text = "locator=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 610);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnAdvantagePatches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtLocator;
        private System.Windows.Forms.TextBox txtMergeNumber;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtBuildId;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtBuildNumber;
        private System.Windows.Forms.Button button9;
    }
}