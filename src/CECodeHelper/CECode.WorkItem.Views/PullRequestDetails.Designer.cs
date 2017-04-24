namespace CECode.WorkItem.Views
{
    partial class PullRequestDetails
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label statusLabel;
            System.Windows.Forms.Label shaLabel;
            System.Windows.Forms.Label repoLabel;
            System.Windows.Forms.Label numberLabel;
            System.Windows.Forms.Label createdAtLabel;
            System.Windows.Forms.Label headRefLabel;
            System.Windows.Forms.Label bodyLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label mergedAtLabel;
            System.Windows.Forms.Label closedAtLabel;
            System.Windows.Forms.Label headLabel;
            System.Windows.Forms.Label baseRefLabel;
            System.Windows.Forms.Label baseLabel;
            System.Windows.Forms.Label mergeCommitShaLabel;
            System.Windows.Forms.Label mergedByLabel;
            System.Windows.Forms.Label commentCountLabel;
            System.Windows.Forms.Label commitCountLabel;
            System.Windows.Forms.Label additionsLabel;
            System.Windows.Forms.Label deletionsLabel;
            System.Windows.Forms.Label changedFilesLabel;
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.shaTextBox = new System.Windows.Forms.TextBox();
            this.repoTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.createdAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.headRefTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.mergedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.closedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.headTextBox = new System.Windows.Forms.TextBox();
            this.baseRefTextBox = new System.Windows.Forms.TextBox();
            this.baseTextBox = new System.Windows.Forms.TextBox();
            this.isLockedCheckBox = new System.Windows.Forms.CheckBox();
            this.isMergeableCheckBox = new System.Windows.Forms.CheckBox();
            this.isMergedCheckBox = new System.Windows.Forms.CheckBox();
            this.isReviewedCheckBox = new System.Windows.Forms.CheckBox();
            this.mergeCommitShaTextBox = new System.Windows.Forms.TextBox();
            this.mergedByTextBox = new System.Windows.Forms.TextBox();
            this.commentCountTextBox = new System.Windows.Forms.TextBox();
            this.commitCountTextBox = new System.Windows.Forms.TextBox();
            this.additionsTextBox = new System.Windows.Forms.TextBox();
            this.deletionsTextBox = new System.Windows.Forms.TextBox();
            this.changedFilesTextBox = new System.Windows.Forms.TextBox();
            this.btnHtmlUrl = new System.Windows.Forms.Button();
            this.btnDiffUrl = new System.Windows.Forms.Button();
            this.btnPatchUrl = new System.Windows.Forms.Button();
            this.btnUrl = new System.Windows.Forms.Button();
            this.bodyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.iCEPullRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            titleLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            shaLabel = new System.Windows.Forms.Label();
            repoLabel = new System.Windows.Forms.Label();
            numberLabel = new System.Windows.Forms.Label();
            createdAtLabel = new System.Windows.Forms.Label();
            headRefLabel = new System.Windows.Forms.Label();
            bodyLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            mergedAtLabel = new System.Windows.Forms.Label();
            closedAtLabel = new System.Windows.Forms.Label();
            headLabel = new System.Windows.Forms.Label();
            baseRefLabel = new System.Windows.Forms.Label();
            baseLabel = new System.Windows.Forms.Label();
            mergeCommitShaLabel = new System.Windows.Forms.Label();
            mergedByLabel = new System.Windows.Forms.Label();
            commentCountLabel = new System.Windows.Forms.Label();
            commitCountLabel = new System.Windows.Forms.Label();
            additionsLabel = new System.Windows.Forms.Label();
            deletionsLabel = new System.Windows.Forms.Label();
            changedFilesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iCEPullRequestBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(8, 128);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(8, 144);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(608, 20);
            this.titleTextBox.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new System.Drawing.Point(216, 8);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(40, 13);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Status:";
            // 
            // statusTextBox
            // 
            this.statusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Status", true));
            this.statusTextBox.Location = new System.Drawing.Point(216, 24);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(100, 20);
            this.statusTextBox.TabIndex = 3;
            // 
            // shaLabel
            // 
            shaLabel.AutoSize = true;
            shaLabel.Location = new System.Drawing.Point(8, 320);
            shaLabel.Name = "shaLabel";
            shaLabel.Size = new System.Drawing.Size(29, 13);
            shaLabel.TabIndex = 4;
            shaLabel.Text = "Sha:";
            // 
            // shaTextBox
            // 
            this.shaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Sha", true));
            this.shaTextBox.Location = new System.Drawing.Point(8, 336);
            this.shaTextBox.Name = "shaTextBox";
            this.shaTextBox.Size = new System.Drawing.Size(304, 20);
            this.shaTextBox.TabIndex = 5;
            // 
            // repoLabel
            // 
            repoLabel.AutoSize = true;
            repoLabel.Location = new System.Drawing.Point(320, 8);
            repoLabel.Name = "repoLabel";
            repoLabel.Size = new System.Drawing.Size(36, 13);
            repoLabel.TabIndex = 6;
            repoLabel.Text = "Repo:";
            // 
            // repoTextBox
            // 
            this.repoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Repo", true));
            this.repoTextBox.Location = new System.Drawing.Point(320, 24);
            this.repoTextBox.Name = "repoTextBox";
            this.repoTextBox.Size = new System.Drawing.Size(100, 20);
            this.repoTextBox.TabIndex = 7;
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Location = new System.Drawing.Point(112, 8);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(47, 13);
            numberLabel.TabIndex = 8;
            numberLabel.Text = "Number:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Number", true));
            this.numberTextBox.Location = new System.Drawing.Point(112, 24);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox.TabIndex = 9;
            // 
            // createdAtLabel
            // 
            createdAtLabel.AutoSize = true;
            createdAtLabel.Location = new System.Drawing.Point(424, 8);
            createdAtLabel.Name = "createdAtLabel";
            createdAtLabel.Size = new System.Drawing.Size(60, 13);
            createdAtLabel.TabIndex = 10;
            createdAtLabel.Text = "Created At:";
            // 
            // createdAtDateTimePicker
            // 
            this.createdAtDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iCEPullRequestBindingSource, "CreatedAt", true));
            this.createdAtDateTimePicker.Location = new System.Drawing.Point(424, 24);
            this.createdAtDateTimePicker.Name = "createdAtDateTimePicker";
            this.createdAtDateTimePicker.Size = new System.Drawing.Size(192, 20);
            this.createdAtDateTimePicker.TabIndex = 11;
            // 
            // headRefLabel
            // 
            headRefLabel.AutoSize = true;
            headRefLabel.Location = new System.Drawing.Point(312, 48);
            headRefLabel.Name = "headRefLabel";
            headRefLabel.Size = new System.Drawing.Size(56, 13);
            headRefLabel.TabIndex = 12;
            headRefLabel.Text = "Head Ref:";
            // 
            // headRefTextBox
            // 
            this.headRefTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "HeadRef", true));
            this.headRefTextBox.Location = new System.Drawing.Point(312, 64);
            this.headRefTextBox.Name = "headRefTextBox";
            this.headRefTextBox.Size = new System.Drawing.Size(304, 20);
            this.headRefTextBox.TabIndex = 13;
            // 
            // bodyLabel
            // 
            bodyLabel.AutoSize = true;
            bodyLabel.Location = new System.Drawing.Point(8, 168);
            bodyLabel.Name = "bodyLabel";
            bodyLabel.Size = new System.Drawing.Size(34, 13);
            bodyLabel.TabIndex = 14;
            bodyLabel.Text = "Body:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(8, 8);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 16;
            idLabel.Text = "Id:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(8, 24);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 17;
            // 
            // mergedAtLabel
            // 
            mergedAtLabel.AutoSize = true;
            mergedAtLabel.Location = new System.Drawing.Point(8, 280);
            mergedAtLabel.Name = "mergedAtLabel";
            mergedAtLabel.Size = new System.Drawing.Size(59, 13);
            mergedAtLabel.TabIndex = 18;
            mergedAtLabel.Text = "Merged At:";
            // 
            // mergedAtDateTimePicker
            // 
            this.mergedAtDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iCEPullRequestBindingSource, "MergedAt", true));
            this.mergedAtDateTimePicker.Location = new System.Drawing.Point(8, 296);
            this.mergedAtDateTimePicker.Name = "mergedAtDateTimePicker";
            this.mergedAtDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.mergedAtDateTimePicker.TabIndex = 19;
            // 
            // closedAtLabel
            // 
            closedAtLabel.AutoSize = true;
            closedAtLabel.Location = new System.Drawing.Point(320, 320);
            closedAtLabel.Name = "closedAtLabel";
            closedAtLabel.Size = new System.Drawing.Size(55, 13);
            closedAtLabel.TabIndex = 20;
            closedAtLabel.Text = "Closed At:";
            // 
            // closedAtDateTimePicker
            // 
            this.closedAtDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iCEPullRequestBindingSource, "ClosedAt", true));
            this.closedAtDateTimePicker.Location = new System.Drawing.Point(320, 336);
            this.closedAtDateTimePicker.Name = "closedAtDateTimePicker";
            this.closedAtDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.closedAtDateTimePicker.TabIndex = 21;
            // 
            // headLabel
            // 
            headLabel.AutoSize = true;
            headLabel.Location = new System.Drawing.Point(8, 48);
            headLabel.Name = "headLabel";
            headLabel.Size = new System.Drawing.Size(36, 13);
            headLabel.TabIndex = 22;
            headLabel.Text = "Head:";
            // 
            // headTextBox
            // 
            this.headTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Head", true));
            this.headTextBox.Location = new System.Drawing.Point(8, 64);
            this.headTextBox.MaxLength = 500;
            this.headTextBox.Name = "headTextBox";
            this.headTextBox.Size = new System.Drawing.Size(296, 20);
            this.headTextBox.TabIndex = 23;
            // 
            // baseRefLabel
            // 
            baseRefLabel.AutoSize = true;
            baseRefLabel.Location = new System.Drawing.Point(312, 88);
            baseRefLabel.Name = "baseRefLabel";
            baseRefLabel.Size = new System.Drawing.Size(54, 13);
            baseRefLabel.TabIndex = 24;
            baseRefLabel.Text = "Base Ref:";
            // 
            // baseRefTextBox
            // 
            this.baseRefTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "BaseRef", true));
            this.baseRefTextBox.Location = new System.Drawing.Point(312, 104);
            this.baseRefTextBox.Name = "baseRefTextBox";
            this.baseRefTextBox.Size = new System.Drawing.Size(304, 20);
            this.baseRefTextBox.TabIndex = 25;
            // 
            // baseLabel
            // 
            baseLabel.AutoSize = true;
            baseLabel.Location = new System.Drawing.Point(8, 88);
            baseLabel.Name = "baseLabel";
            baseLabel.Size = new System.Drawing.Size(34, 13);
            baseLabel.TabIndex = 26;
            baseLabel.Text = "Base:";
            // 
            // baseTextBox
            // 
            this.baseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Base", true));
            this.baseTextBox.Location = new System.Drawing.Point(8, 104);
            this.baseTextBox.Name = "baseTextBox";
            this.baseTextBox.Size = new System.Drawing.Size(296, 20);
            this.baseTextBox.TabIndex = 27;
            // 
            // isLockedCheckBox
            // 
            this.isLockedCheckBox.AutoSize = true;
            this.isLockedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.iCEPullRequestBindingSource, "IsLocked", true));
            this.isLockedCheckBox.Location = new System.Drawing.Point(8, 256);
            this.isLockedCheckBox.Name = "isLockedCheckBox";
            this.isLockedCheckBox.Size = new System.Drawing.Size(62, 17);
            this.isLockedCheckBox.TabIndex = 29;
            this.isLockedCheckBox.Text = "Locked";
            this.isLockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isMergeableCheckBox
            // 
            this.isMergeableCheckBox.AutoSize = true;
            this.isMergeableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.iCEPullRequestBindingSource, "IsMergeable", true));
            this.isMergeableCheckBox.Location = new System.Drawing.Point(72, 256);
            this.isMergeableCheckBox.Name = "isMergeableCheckBox";
            this.isMergeableCheckBox.Size = new System.Drawing.Size(76, 17);
            this.isMergeableCheckBox.TabIndex = 31;
            this.isMergeableCheckBox.Text = "Mergeable";
            this.isMergeableCheckBox.UseVisualStyleBackColor = true;
            // 
            // isMergedCheckBox
            // 
            this.isMergedCheckBox.AutoSize = true;
            this.isMergedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.iCEPullRequestBindingSource, "IsMerged", true));
            this.isMergedCheckBox.Location = new System.Drawing.Point(232, 256);
            this.isMergedCheckBox.Name = "isMergedCheckBox";
            this.isMergedCheckBox.Size = new System.Drawing.Size(62, 17);
            this.isMergedCheckBox.TabIndex = 33;
            this.isMergedCheckBox.Text = "Merged";
            this.isMergedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isReviewedCheckBox
            // 
            this.isReviewedCheckBox.AutoSize = true;
            this.isReviewedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.iCEPullRequestBindingSource, "IsReviewed", true));
            this.isReviewedCheckBox.Location = new System.Drawing.Point(152, 256);
            this.isReviewedCheckBox.Name = "isReviewedCheckBox";
            this.isReviewedCheckBox.Size = new System.Drawing.Size(74, 17);
            this.isReviewedCheckBox.TabIndex = 35;
            this.isReviewedCheckBox.Text = "Reviewed";
            this.isReviewedCheckBox.UseVisualStyleBackColor = true;
            // 
            // mergeCommitShaLabel
            // 
            mergeCommitShaLabel.AutoSize = true;
            mergeCommitShaLabel.Location = new System.Drawing.Point(320, 280);
            mergeCommitShaLabel.Name = "mergeCommitShaLabel";
            mergeCommitShaLabel.Size = new System.Drawing.Size(99, 13);
            mergeCommitShaLabel.TabIndex = 36;
            mergeCommitShaLabel.Text = "Merge Commit Sha:";
            // 
            // mergeCommitShaTextBox
            // 
            this.mergeCommitShaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "MergeCommitSha", true));
            this.mergeCommitShaTextBox.Location = new System.Drawing.Point(320, 296);
            this.mergeCommitShaTextBox.Name = "mergeCommitShaTextBox";
            this.mergeCommitShaTextBox.Size = new System.Drawing.Size(296, 20);
            this.mergeCommitShaTextBox.TabIndex = 37;
            // 
            // mergedByLabel
            // 
            mergedByLabel.AutoSize = true;
            mergedByLabel.Location = new System.Drawing.Point(216, 280);
            mergedByLabel.Name = "mergedByLabel";
            mergedByLabel.Size = new System.Drawing.Size(61, 13);
            mergedByLabel.TabIndex = 38;
            mergedByLabel.Text = "Merged By:";
            // 
            // mergedByTextBox
            // 
            this.mergedByTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "MergedBy", true));
            this.mergedByTextBox.Location = new System.Drawing.Point(216, 296);
            this.mergedByTextBox.Name = "mergedByTextBox";
            this.mergedByTextBox.Size = new System.Drawing.Size(96, 20);
            this.mergedByTextBox.TabIndex = 39;
            // 
            // commentCountLabel
            // 
            commentCountLabel.AutoSize = true;
            commentCountLabel.Location = new System.Drawing.Point(624, 8);
            commentCountLabel.Name = "commentCountLabel";
            commentCountLabel.Size = new System.Drawing.Size(59, 13);
            commentCountLabel.TabIndex = 39;
            commentCountLabel.Text = "Comments:";
            // 
            // commentCountTextBox
            // 
            this.commentCountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "CommentCount", true));
            this.commentCountTextBox.Location = new System.Drawing.Point(624, 24);
            this.commentCountTextBox.Name = "commentCountTextBox";
            this.commentCountTextBox.Size = new System.Drawing.Size(64, 20);
            this.commentCountTextBox.TabIndex = 40;
            // 
            // commitCountLabel
            // 
            commitCountLabel.AutoSize = true;
            commitCountLabel.Location = new System.Drawing.Point(696, 8);
            commitCountLabel.Name = "commitCountLabel";
            commitCountLabel.Size = new System.Drawing.Size(49, 13);
            commitCountLabel.TabIndex = 40;
            commitCountLabel.Text = "Commits:";
            // 
            // commitCountTextBox
            // 
            this.commitCountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "CommitCount", true));
            this.commitCountTextBox.Location = new System.Drawing.Point(696, 24);
            this.commitCountTextBox.Name = "commitCountTextBox";
            this.commitCountTextBox.Size = new System.Drawing.Size(64, 20);
            this.commitCountTextBox.TabIndex = 41;
            // 
            // additionsLabel
            // 
            additionsLabel.AutoSize = true;
            additionsLabel.Location = new System.Drawing.Point(624, 48);
            additionsLabel.Name = "additionsLabel";
            additionsLabel.Size = new System.Drawing.Size(53, 13);
            additionsLabel.TabIndex = 41;
            additionsLabel.Text = "Additions:";
            // 
            // additionsTextBox
            // 
            this.additionsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Additions", true));
            this.additionsTextBox.Location = new System.Drawing.Point(624, 64);
            this.additionsTextBox.Name = "additionsTextBox";
            this.additionsTextBox.Size = new System.Drawing.Size(64, 20);
            this.additionsTextBox.TabIndex = 42;
            // 
            // deletionsLabel
            // 
            deletionsLabel.AutoSize = true;
            deletionsLabel.Location = new System.Drawing.Point(696, 48);
            deletionsLabel.Name = "deletionsLabel";
            deletionsLabel.Size = new System.Drawing.Size(54, 13);
            deletionsLabel.TabIndex = 42;
            deletionsLabel.Text = "Deletions:";
            // 
            // deletionsTextBox
            // 
            this.deletionsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Deletions", true));
            this.deletionsTextBox.Location = new System.Drawing.Point(696, 64);
            this.deletionsTextBox.Name = "deletionsTextBox";
            this.deletionsTextBox.Size = new System.Drawing.Size(64, 20);
            this.deletionsTextBox.TabIndex = 43;
            // 
            // changedFilesLabel
            // 
            changedFilesLabel.AutoSize = true;
            changedFilesLabel.Location = new System.Drawing.Point(768, 48);
            changedFilesLabel.Name = "changedFilesLabel";
            changedFilesLabel.Size = new System.Drawing.Size(77, 13);
            changedFilesLabel.TabIndex = 44;
            changedFilesLabel.Text = "Changed Files:";
            // 
            // changedFilesTextBox
            // 
            this.changedFilesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "ChangedFiles", true));
            this.changedFilesTextBox.Location = new System.Drawing.Point(768, 64);
            this.changedFilesTextBox.Name = "changedFilesTextBox";
            this.changedFilesTextBox.Size = new System.Drawing.Size(64, 20);
            this.changedFilesTextBox.TabIndex = 45;
            // 
            // btnHtmlUrl
            // 
            this.btnHtmlUrl.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.iCEPullRequestBindingSource, "HtmlUrl", true));
            this.btnHtmlUrl.Location = new System.Drawing.Point(624, 104);
            this.btnHtmlUrl.Name = "btnHtmlUrl";
            this.btnHtmlUrl.Size = new System.Drawing.Size(64, 23);
            this.btnHtmlUrl.TabIndex = 54;
            this.btnHtmlUrl.Text = "HTML";
            this.btnHtmlUrl.UseVisualStyleBackColor = true;
            this.btnHtmlUrl.Click += new System.EventHandler(this.btnHtmlUrl_Click);
            // 
            // btnDiffUrl
            // 
            this.btnDiffUrl.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.iCEPullRequestBindingSource, "DiffUrl", true));
            this.btnDiffUrl.Location = new System.Drawing.Point(696, 104);
            this.btnDiffUrl.Name = "btnDiffUrl";
            this.btnDiffUrl.Size = new System.Drawing.Size(64, 23);
            this.btnDiffUrl.TabIndex = 55;
            this.btnDiffUrl.Text = "Diff";
            this.btnDiffUrl.UseVisualStyleBackColor = true;
            this.btnDiffUrl.Click += new System.EventHandler(this.btnDiffUrl_Click);
            // 
            // btnPatchUrl
            // 
            this.btnPatchUrl.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.iCEPullRequestBindingSource, "PatchUrl", true));
            this.btnPatchUrl.Location = new System.Drawing.Point(624, 144);
            this.btnPatchUrl.Name = "btnPatchUrl";
            this.btnPatchUrl.Size = new System.Drawing.Size(64, 23);
            this.btnPatchUrl.TabIndex = 56;
            this.btnPatchUrl.Text = "Patch";
            this.btnPatchUrl.UseVisualStyleBackColor = true;
            this.btnPatchUrl.Click += new System.EventHandler(this.btnPatchUrl_Click);
            // 
            // btnUrl
            // 
            this.btnUrl.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.iCEPullRequestBindingSource, "Url", true));
            this.btnUrl.Location = new System.Drawing.Point(696, 144);
            this.btnUrl.Name = "btnUrl";
            this.btnUrl.Size = new System.Drawing.Size(64, 23);
            this.btnUrl.TabIndex = 57;
            this.btnUrl.Text = "URL";
            this.btnUrl.UseVisualStyleBackColor = true;
            this.btnUrl.Click += new System.EventHandler(this.btnUrl_Click);
            // 
            // bodyRichTextBox
            // 
            this.bodyRichTextBox.AcceptsTab = true;
            this.bodyRichTextBox.BulletIndent = 4;
            this.bodyRichTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iCEPullRequestBindingSource, "Body", true));
            this.bodyRichTextBox.Location = new System.Drawing.Point(8, 184);
            this.bodyRichTextBox.Name = "bodyRichTextBox";
            this.bodyRichTextBox.Size = new System.Drawing.Size(752, 64);
            this.bodyRichTextBox.TabIndex = 58;
            this.bodyRichTextBox.Text = "";
            // 
            // iCEPullRequestBindingSource
            // 
            this.iCEPullRequestBindingSource.DataSource = typeof(CECode.Business.ICEPullRequest);
            // 
            // PullRequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.bodyRichTextBox);
            this.Controls.Add(this.btnUrl);
            this.Controls.Add(this.btnPatchUrl);
            this.Controls.Add(this.btnDiffUrl);
            this.Controls.Add(this.btnHtmlUrl);
            this.Controls.Add(changedFilesLabel);
            this.Controls.Add(this.changedFilesTextBox);
            this.Controls.Add(deletionsLabel);
            this.Controls.Add(this.deletionsTextBox);
            this.Controls.Add(additionsLabel);
            this.Controls.Add(this.additionsTextBox);
            this.Controls.Add(commitCountLabel);
            this.Controls.Add(this.commitCountTextBox);
            this.Controls.Add(commentCountLabel);
            this.Controls.Add(this.commentCountTextBox);
            this.Controls.Add(mergedByLabel);
            this.Controls.Add(this.mergedByTextBox);
            this.Controls.Add(mergeCommitShaLabel);
            this.Controls.Add(this.mergeCommitShaTextBox);
            this.Controls.Add(this.isReviewedCheckBox);
            this.Controls.Add(this.isMergedCheckBox);
            this.Controls.Add(this.isMergeableCheckBox);
            this.Controls.Add(this.isLockedCheckBox);
            this.Controls.Add(baseLabel);
            this.Controls.Add(this.baseTextBox);
            this.Controls.Add(baseRefLabel);
            this.Controls.Add(this.baseRefTextBox);
            this.Controls.Add(headLabel);
            this.Controls.Add(this.headTextBox);
            this.Controls.Add(closedAtLabel);
            this.Controls.Add(this.closedAtDateTimePicker);
            this.Controls.Add(mergedAtLabel);
            this.Controls.Add(this.mergedAtDateTimePicker);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(bodyLabel);
            this.Controls.Add(headRefLabel);
            this.Controls.Add(this.headRefTextBox);
            this.Controls.Add(createdAtLabel);
            this.Controls.Add(this.createdAtDateTimePicker);
            this.Controls.Add(numberLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(repoLabel);
            this.Controls.Add(this.repoTextBox);
            this.Controls.Add(shaLabel);
            this.Controls.Add(this.shaTextBox);
            this.Controls.Add(statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Name = "PullRequestDetails";
            this.Size = new System.Drawing.Size(853, 376);
            ((System.ComponentModel.ISupportInitialize)(this.iCEPullRequestBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource iCEPullRequestBindingSource;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox shaTextBox;
        private System.Windows.Forms.TextBox repoTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.DateTimePicker createdAtDateTimePicker;
        private System.Windows.Forms.TextBox headRefTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.DateTimePicker mergedAtDateTimePicker;
        private System.Windows.Forms.DateTimePicker closedAtDateTimePicker;
        private System.Windows.Forms.TextBox headTextBox;
        private System.Windows.Forms.TextBox baseRefTextBox;
        private System.Windows.Forms.TextBox baseTextBox;
        private System.Windows.Forms.CheckBox isLockedCheckBox;
        private System.Windows.Forms.CheckBox isMergeableCheckBox;
        private System.Windows.Forms.CheckBox isMergedCheckBox;
        private System.Windows.Forms.CheckBox isReviewedCheckBox;
        private System.Windows.Forms.TextBox mergeCommitShaTextBox;
        private System.Windows.Forms.TextBox mergedByTextBox;
        private System.Windows.Forms.TextBox commentCountTextBox;
        private System.Windows.Forms.TextBox commitCountTextBox;
        private System.Windows.Forms.TextBox additionsTextBox;
        private System.Windows.Forms.TextBox deletionsTextBox;
        private System.Windows.Forms.TextBox changedFilesTextBox;
        private System.Windows.Forms.Button btnHtmlUrl;
        private System.Windows.Forms.Button btnDiffUrl;
        private System.Windows.Forms.Button btnPatchUrl;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.RichTextBox bodyRichTextBox;
    }
}
