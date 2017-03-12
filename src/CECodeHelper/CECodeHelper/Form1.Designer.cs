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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAMS = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lstProjects = new System.Windows.Forms.CheckedListBox();
            this.btnRD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Items by Project";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Item by Key";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(416, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnAMS
            // 
            this.btnAMS.Location = new System.Drawing.Point(312, 112);
            this.btnAMS.Name = "btnAMS";
            this.btnAMS.Size = new System.Drawing.Size(96, 32);
            this.btnAMS.TabIndex = 3;
            this.btnAMS.Text = "AMS";
            this.btnAMS.UseVisualStyleBackColor = true;
            this.btnAMS.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 152);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1042, 253);
            this.dgv.TabIndex = 4;
            // 
            // lstProjects
            // 
            this.lstProjects.FormattingEnabled = true;
            this.lstProjects.Location = new System.Drawing.Point(8, 8);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(160, 139);
            this.lstProjects.TabIndex = 5;
            // 
            // btnRD
            // 
            this.btnRD.Location = new System.Drawing.Point(312, 72);
            this.btnRD.Name = "btnRD";
            this.btnRD.Size = new System.Drawing.Size(96, 32);
            this.btnRD.TabIndex = 6;
            this.btnRD.Text = "R&&D";
            this.btnRD.UseVisualStyleBackColor = true;
            this.btnRD.Click += new System.EventHandler(this.btnRD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 405);
            this.Controls.Add(this.btnRD);
            this.Controls.Add(this.lstProjects);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAMS);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAMS;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckedListBox lstProjects;
        private System.Windows.Forms.Button btnRD;
    }
}