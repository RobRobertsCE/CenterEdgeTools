namespace CECodeHelper.Forms
{
    partial class GitHubView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trvBranch = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnGetBranch = new System.Windows.Forms.Button();
            this.pnlCommit = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBranchCheck = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlCommit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetBranch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 48);
            this.panel1.TabIndex = 0;
            // 
            // trvBranch
            // 
            this.trvBranch.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvBranch.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvBranch.Location = new System.Drawing.Point(0, 48);
            this.trvBranch.Name = "trvBranch";
            this.trvBranch.Size = new System.Drawing.Size(288, 360);
            this.trvBranch.TabIndex = 1;
            this.trvBranch.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBranch_BeforeExpand);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(288, 48);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 360);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnGetBranch
            // 
            this.btnGetBranch.Location = new System.Drawing.Point(8, 8);
            this.btnGetBranch.Name = "btnGetBranch";
            this.btnGetBranch.Size = new System.Drawing.Size(88, 32);
            this.btnGetBranch.TabIndex = 0;
            this.btnGetBranch.Text = "Load";
            this.btnGetBranch.UseVisualStyleBackColor = true;
            this.btnGetBranch.Click += new System.EventHandler(this.btnGetBranch_Click);
            // 
            // pnlCommit
            // 
            this.pnlCommit.Controls.Add(this.txtBranchCheck);
            this.pnlCommit.Controls.Add(this.button1);
            this.pnlCommit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommit.Location = new System.Drawing.Point(291, 48);
            this.pnlCommit.Name = "pnlCommit";
            this.pnlCommit.Size = new System.Drawing.Size(879, 152);
            this.pnlCommit.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBranchCheck
            // 
            this.txtBranchCheck.Location = new System.Drawing.Point(32, 56);
            this.txtBranchCheck.Multiline = true;
            this.txtBranchCheck.Name = "txtBranchCheck";
            this.txtBranchCheck.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBranchCheck.Size = new System.Drawing.Size(336, 80);
            this.txtBranchCheck.TabIndex = 1;
            // 
            // GitHubView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 408);
            this.Controls.Add(this.pnlCommit);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.trvBranch);
            this.Controls.Add(this.panel1);
            this.Name = "GitHubView";
            this.Text = "GitHubView";
            this.panel1.ResumeLayout(false);
            this.pnlCommit.ResumeLayout(false);
            this.pnlCommit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView trvBranch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnGetBranch;
        private System.Windows.Forms.Panel pnlCommit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBranchCheck;
    }
}