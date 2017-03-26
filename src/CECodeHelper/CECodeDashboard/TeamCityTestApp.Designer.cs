namespace CECodeDashboard
{
    partial class TeamCityTestApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuildTypesQuery = new System.Windows.Forms.Button();
            this.btnGetQueuedBuilds = new System.Windows.Forms.Button();
            this.btnGetBuildsByMergeNumber = new System.Windows.Forms.Button();
            this.btnGetBuilds = new System.Windows.Forms.Button();
            this.btnGetRunningBuilds = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetBuildsByLocator = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetBuildArtifacts = new System.Windows.Forms.Button();
            this.btnGetBuildIssues = new System.Windows.Forms.Button();
            this.btnAutoMergeBuild = new System.Windows.Forms.Button();
            this.btnAdvBuilds = new System.Windows.Forms.Button();
            this.btnAdvPatches = new System.Windows.Forms.Button();
            this.btnGetBuildById = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "WorkItems";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 288);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1565, 398);
            this.dgv.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtParam);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1565, 288);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Parameter:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBuildTypesQuery);
            this.groupBox2.Controls.Add(this.btnGetQueuedBuilds);
            this.groupBox2.Controls.Add(this.btnGetBuildsByMergeNumber);
            this.groupBox2.Controls.Add(this.btnGetBuilds);
            this.groupBox2.Controls.Add(this.btnGetRunningBuilds);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnGetBuildsByLocator);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(576, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(971, 187);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "string buildType:";
            // 
            // btnBuildTypesQuery
            // 
            this.btnBuildTypesQuery.Location = new System.Drawing.Point(216, 128);
            this.btnBuildTypesQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuildTypesQuery.Name = "btnBuildTypesQuery";
            this.btnBuildTypesQuery.Size = new System.Drawing.Size(192, 39);
            this.btnBuildTypesQuery.TabIndex = 22;
            this.btnBuildTypesQuery.Text = "GetBuildsTypesQuery";
            this.btnBuildTypesQuery.UseVisualStyleBackColor = true;
            this.btnBuildTypesQuery.Click += new System.EventHandler(this.btnBuildTypesQuery_Click);
            // 
            // btnGetQueuedBuilds
            // 
            this.btnGetQueuedBuilds.Location = new System.Drawing.Point(11, 128);
            this.btnGetQueuedBuilds.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetQueuedBuilds.Name = "btnGetQueuedBuilds";
            this.btnGetQueuedBuilds.Size = new System.Drawing.Size(192, 39);
            this.btnGetQueuedBuilds.TabIndex = 21;
            this.btnGetQueuedBuilds.Text = "GetQueuedBuilds";
            this.btnGetQueuedBuilds.UseVisualStyleBackColor = true;
            this.btnGetQueuedBuilds.Click += new System.EventHandler(this.btnGetQueuedBuilds_Click);
            // 
            // btnGetBuildsByMergeNumber
            // 
            this.btnGetBuildsByMergeNumber.Location = new System.Drawing.Point(213, 30);
            this.btnGetBuildsByMergeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuildsByMergeNumber.Name = "btnGetBuildsByMergeNumber";
            this.btnGetBuildsByMergeNumber.Size = new System.Drawing.Size(192, 39);
            this.btnGetBuildsByMergeNumber.TabIndex = 8;
            this.btnGetBuildsByMergeNumber.Text = "GetBuildsByPullRequest";
            this.btnGetBuildsByMergeNumber.UseVisualStyleBackColor = true;
            this.btnGetBuildsByMergeNumber.Click += new System.EventHandler(this.btnGetBuildsByMergeNumber_Click);
            // 
            // btnGetBuilds
            // 
            this.btnGetBuilds.Location = new System.Drawing.Point(11, 30);
            this.btnGetBuilds.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuilds.Name = "btnGetBuilds";
            this.btnGetBuilds.Size = new System.Drawing.Size(192, 39);
            this.btnGetBuilds.TabIndex = 5;
            this.btnGetBuilds.Text = "GetBuilds";
            this.btnGetBuilds.UseVisualStyleBackColor = true;
            this.btnGetBuilds.Click += new System.EventHandler(this.btnGetBuilds_Click);
            // 
            // btnGetRunningBuilds
            // 
            this.btnGetRunningBuilds.Location = new System.Drawing.Point(11, 79);
            this.btnGetRunningBuilds.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetRunningBuilds.Name = "btnGetRunningBuilds";
            this.btnGetRunningBuilds.Size = new System.Drawing.Size(192, 39);
            this.btnGetRunningBuilds.TabIndex = 7;
            this.btnGetRunningBuilds.Text = "GetRunningBuilds";
            this.btnGetRunningBuilds.UseVisualStyleBackColor = true;
            this.btnGetRunningBuilds.Click += new System.EventHandler(this.btnGetRunningBuilds_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "int mergeNumber:";
            // 
            // btnGetBuildsByLocator
            // 
            this.btnGetBuildsByLocator.Location = new System.Drawing.Point(213, 79);
            this.btnGetBuildsByLocator.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuildsByLocator.Name = "btnGetBuildsByLocator";
            this.btnGetBuildsByLocator.Size = new System.Drawing.Size(192, 39);
            this.btnGetBuildsByLocator.TabIndex = 10;
            this.btnGetBuildsByLocator.Text = "GetBuildsQuery";
            this.btnGetBuildsByLocator.UseVisualStyleBackColor = true;
            this.btnGetBuildsByLocator.Click += new System.EventHandler(this.btnGetBuildsByLocator_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "string locator:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnGetBuildArtifacts);
            this.groupBox1.Controls.Add(this.btnGetBuildIssues);
            this.groupBox1.Controls.Add(this.btnAutoMergeBuild);
            this.groupBox1.Controls.Add(this.btnAdvBuilds);
            this.groupBox1.Controls.Add(this.btnAdvPatches);
            this.groupBox1.Controls.Add(this.btnGetBuildById);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(139, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(427, 187);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Item Result";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "long id:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "long id:";
            // 
            // btnGetBuildArtifacts
            // 
            this.btnGetBuildArtifacts.Location = new System.Drawing.Point(184, 128);
            this.btnGetBuildArtifacts.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuildArtifacts.Name = "btnGetBuildArtifacts";
            this.btnGetBuildArtifacts.Size = new System.Drawing.Size(149, 39);
            this.btnGetBuildArtifacts.TabIndex = 17;
            this.btnGetBuildArtifacts.Text = "GetBuildArtifacts";
            this.btnGetBuildArtifacts.UseVisualStyleBackColor = true;
            this.btnGetBuildArtifacts.Click += new System.EventHandler(this.btnGetBuildArtifacts_Click);
            // 
            // btnGetBuildIssues
            // 
            this.btnGetBuildIssues.Location = new System.Drawing.Point(184, 80);
            this.btnGetBuildIssues.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuildIssues.Name = "btnGetBuildIssues";
            this.btnGetBuildIssues.Size = new System.Drawing.Size(149, 39);
            this.btnGetBuildIssues.TabIndex = 16;
            this.btnGetBuildIssues.Text = "GetBuildIssues";
            this.btnGetBuildIssues.UseVisualStyleBackColor = true;
            this.btnGetBuildIssues.Click += new System.EventHandler(this.btnGetBuildIssues_Click);
            // 
            // btnAutoMergeBuild
            // 
            this.btnAutoMergeBuild.Location = new System.Drawing.Point(21, 128);
            this.btnAutoMergeBuild.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoMergeBuild.Name = "btnAutoMergeBuild";
            this.btnAutoMergeBuild.Size = new System.Drawing.Size(149, 39);
            this.btnAutoMergeBuild.TabIndex = 15;
            this.btnAutoMergeBuild.Text = "Auto Merge";
            this.btnAutoMergeBuild.UseVisualStyleBackColor = true;
            this.btnAutoMergeBuild.Click += new System.EventHandler(this.btnAutoMergeBuild_Click);
            // 
            // btnAdvBuilds
            // 
            this.btnAdvBuilds.Location = new System.Drawing.Point(21, 30);
            this.btnAdvBuilds.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdvBuilds.Name = "btnAdvBuilds";
            this.btnAdvBuilds.Size = new System.Drawing.Size(149, 39);
            this.btnAdvBuilds.TabIndex = 1;
            this.btnAdvBuilds.Text = "Advantage";
            this.btnAdvBuilds.UseVisualStyleBackColor = true;
            this.btnAdvBuilds.Click += new System.EventHandler(this.btnAdvBuilds_Click);
            // 
            // btnAdvPatches
            // 
            this.btnAdvPatches.Location = new System.Drawing.Point(21, 79);
            this.btnAdvPatches.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdvPatches.Name = "btnAdvPatches";
            this.btnAdvPatches.Size = new System.Drawing.Size(149, 39);
            this.btnAdvPatches.TabIndex = 2;
            this.btnAdvPatches.Text = "Patches";
            this.btnAdvPatches.UseVisualStyleBackColor = true;
            this.btnAdvPatches.Click += new System.EventHandler(this.btnAdvPatches_Click);
            // 
            // btnGetBuildById
            // 
            this.btnGetBuildById.Location = new System.Drawing.Point(181, 30);
            this.btnGetBuildById.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBuildById.Name = "btnGetBuildById";
            this.btnGetBuildById.Size = new System.Drawing.Size(149, 39);
            this.btnGetBuildById.TabIndex = 3;
            this.btnGetBuildById.Text = "GetBuild";
            this.btnGetBuildById.UseVisualStyleBackColor = true;
            this.btnGetBuildById.Click += new System.EventHandler(this.btnGetBuildById_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "long id:";
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(139, 236);
            this.txtParam.Margin = new System.Windows.Forms.Padding(4);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(436, 22);
            this.txtParam.TabIndex = 11;
            // 
            // TeamCityTestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 686);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeamCityTestApp";
            this.Text = "TeamCity Test App";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Button btnGetBuildsByLocator;
        private System.Windows.Forms.Button btnGetBuildsByMergeNumber;
        private System.Windows.Forms.Button btnGetRunningBuilds;
        private System.Windows.Forms.Button btnGetBuilds;
        private System.Windows.Forms.Button btnGetBuildById;
        private System.Windows.Forms.Button btnAdvPatches;
        private System.Windows.Forms.Button btnAdvBuilds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetQueuedBuilds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAutoMergeBuild;
        private System.Windows.Forms.Button btnBuildTypesQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGetBuildArtifacts;
        private System.Windows.Forms.Button btnGetBuildIssues;
    }
}

