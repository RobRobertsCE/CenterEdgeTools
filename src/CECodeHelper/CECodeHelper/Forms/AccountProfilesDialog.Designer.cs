namespace CECodeHelper.Forms
{
    partial class AccountProfilesDialog
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
            this.lblWinUser = new System.Windows.Forms.Label();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelClose = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.pnlAccountDetails = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlToken = new System.Windows.Forms.Panel();
            this.pnlUrl = new System.Windows.Forms.Panel();
            this.pnlOwner = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblToken = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlAccountDetails.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlToken.SuspendLayout();
            this.pnlUrl.SuspendLayout();
            this.pnlOwner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWinUser);
            this.panel1.Controls.Add(this.cboAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 56);
            this.panel1.TabIndex = 0;
            // 
            // lblWinUser
            // 
            this.lblWinUser.AutoSize = true;
            this.lblWinUser.Location = new System.Drawing.Point(8, 8);
            this.lblWinUser.Name = "lblWinUser";
            this.lblWinUser.Size = new System.Drawing.Size(84, 13);
            this.lblWinUser.TabIndex = 3;
            this.lblWinUser.Text = "Accounts for {0}";
            // 
            // cboAccounts
            // 
            this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(8, 24);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(224, 21);
            this.cboAccounts.TabIndex = 2;
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancelClose);
            this.panel2.Controls.Add(this.btnEditSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 40);
            this.panel2.TabIndex = 1;
            // 
            // btnCancelClose
            // 
            this.btnCancelClose.Location = new System.Drawing.Point(312, 8);
            this.btnCancelClose.Name = "btnCancelClose";
            this.btnCancelClose.Size = new System.Drawing.Size(80, 24);
            this.btnCancelClose.TabIndex = 2;
            this.btnCancelClose.Text = "Close";
            this.btnCancelClose.UseVisualStyleBackColor = true;
            this.btnCancelClose.Click += new System.EventHandler(this.btnCancelClose_Click);
            // 
            // btnEditSave
            // 
            this.btnEditSave.Location = new System.Drawing.Point(8, 8);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(80, 24);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Add";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // pnlAccountDetails
            // 
            this.pnlAccountDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAccountDetails.Controls.Add(this.flowLayoutPanel1);
            this.pnlAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccountDetails.Location = new System.Drawing.Point(0, 56);
            this.pnlAccountDetails.Name = "pnlAccountDetails";
            this.pnlAccountDetails.Size = new System.Drawing.Size(399, 182);
            this.pnlAccountDetails.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlLogin);
            this.flowLayoutPanel1.Controls.Add(this.pnlPassword);
            this.flowLayoutPanel1.Controls.Add(this.pnlToken);
            this.flowLayoutPanel1.Controls.Add(this.pnlUrl);
            this.flowLayoutPanel1.Controls.Add(this.pnlOwner);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(399, 182);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.txtLogin);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Location = new System.Drawing.Point(3, 3);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(389, 53);
            this.pnlLogin.TabIndex = 0;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(8, 24);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(164, 20);
            this.txtLogin.TabIndex = 15;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(5, 8);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 14;
            this.lblLogin.Text = "Login";
            // 
            // pnlPassword
            // 
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Controls.Add(this.label2);
            this.pnlPassword.Location = new System.Drawing.Point(3, 62);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(389, 53);
            this.pnlPassword.TabIndex = 1;
            // 
            // pnlToken
            // 
            this.pnlToken.Controls.Add(this.txtToken);
            this.pnlToken.Controls.Add(this.lblToken);
            this.pnlToken.Location = new System.Drawing.Point(3, 121);
            this.pnlToken.Name = "pnlToken";
            this.pnlToken.Size = new System.Drawing.Size(389, 53);
            this.pnlToken.TabIndex = 2;
            // 
            // pnlUrl
            // 
            this.pnlUrl.Controls.Add(this.txtUrl);
            this.pnlUrl.Controls.Add(this.label3);
            this.pnlUrl.Location = new System.Drawing.Point(3, 180);
            this.pnlUrl.Name = "pnlUrl";
            this.pnlUrl.Size = new System.Drawing.Size(389, 53);
            this.pnlUrl.TabIndex = 2;
            // 
            // pnlOwner
            // 
            this.pnlOwner.Controls.Add(this.txtOwner);
            this.pnlOwner.Controls.Add(this.label4);
            this.pnlOwner.Location = new System.Drawing.Point(3, 239);
            this.pnlOwner.Name = "pnlOwner";
            this.pnlOwner.Size = new System.Drawing.Size(389, 53);
            this.pnlOwner.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(8, 24);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(164, 20);
            this.txtPassword.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(8, 24);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(374, 20);
            this.txtToken.TabIndex = 17;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(5, 8);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(38, 13);
            this.lblToken.TabIndex = 16;
            this.lblToken.Text = "Token";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(9, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(374, 20);
            this.txtUrl.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "URL";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(8, 24);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(164, 20);
            this.txtOwner.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Owner";
            // 
            // AccountProfilesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 278);
            this.Controls.Add(this.pnlAccountDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AccountProfilesDialog";
            this.Text = "Account Profiles";
            this.Load += new System.EventHandler(this.Accounts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlAccountDetails.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlToken.ResumeLayout(false);
            this.pnlToken.PerformLayout();
            this.pnlUrl.ResumeLayout(false);
            this.pnlUrl.PerformLayout();
            this.pnlOwner.ResumeLayout(false);
            this.pnlOwner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWinUser;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelClose;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Panel pnlAccountDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlToken;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Panel pnlUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label4;
    }
}