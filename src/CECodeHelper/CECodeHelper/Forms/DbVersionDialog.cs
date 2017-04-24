using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.AdvUpgrade;

namespace CECodeHelper
{
    public partial class DbVersionDialog : Form
    {
        public DbVersionHelper VersionHelper { get; set; }

        public DbVersionDialog()
        {
            InitializeComponent();

            VersionHelper = new DbVersionHelper("Advantage", "rroberts");

            PopulateControls();
        }

        void PopulateControls()
        {
            try
            {
                lblVersionTextFile.Text = "Version.txt: " + VersionHelper.VersionFileVersion.ToString();
                lblTempVersion.Text = "Temporary Version: " + VersionHelper.PendingDbVersion.ToString();
                lblPendingVersion.Text = "New Version: " + VersionHelper.NewDbVersion.ToString();

                var projectPath = Path.GetFileName(VersionHelper.UpgradeProjectFolder.TrimEnd('\\'));
                var projectNode = tvPending.Nodes.Add(projectPath);
                projectNode.ExpandAll();

                FileInfo projectFileInfo = new FileInfo(VersionHelper.UpgradeProjectVbProjectFile);
                var projectFileNode = projectNode.Nodes.Add(projectFileInfo.Name);
                projectFileNode.Tag = projectFileInfo;
                projectFileNode.ExpandAll();

                var minorVersionFolderPath = Path.GetFileName(VersionHelper.MinorVersionFolder.TrimEnd('\\'));
                var minorVersionNode = projectNode.Nodes.Add(minorVersionFolderPath);
                minorVersionNode.ExpandAll();

                foreach (var minorFolderItem in Directory.GetFileSystemEntries(VersionHelper.MinorVersionFolder, "*.*"))
                {
                    if (Directory.Exists(minorFolderItem))
                    {
                        DirectoryInfo di = new DirectoryInfo(minorFolderItem);
                        var node = minorVersionNode.Nodes.Add(di.Name);
                        node.Tag = di;
                        if (di.Name.EndsWith("100"))
                        {
                            node.ForeColor = Color.Black;
                            node.ExpandAll();
                        }
                        else
                        {
                            node.ForeColor = Color.Gray;
                        }
                        foreach (var directoryFile in di.GetFiles())
                        {
                            var fileNode = node.Nodes.Add(directoryFile.Name);
                            fileNode.Tag = directoryFile;
                            if (di.Name.Contains("100"))
                            {
                                fileNode.ForeColor = Color.Black;
                            }
                            else
                            {
                                fileNode.ForeColor = Color.Gray;
                            }
                        }
                    }
                }

                foreach (var item in Directory.GetFileSystemEntries(VersionHelper.MinorVersionFolder, "*.vb"))
                {
                    if (File.Exists(item))
                    {
                        FileInfo fi = new FileInfo(item);
                        var node = minorVersionNode.Nodes.Add(fi.Name);
                        node.Tag = fi;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tsbRunProcess_Click(object sender, EventArgs e)
        {
            try
            {
                var result = VersionHelper.UpdateProject();

                if (result.Errors.Count > 0)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        Console.WriteLine(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tvPending_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (null != tvPending.SelectedNode)
                {
                    var selectedFileInfo = (FileInfo)tvPending.SelectedNode.Tag;
                    var fileContent = File.ReadAllText(selectedFileInfo.FullName);
                    this.txtFile.Text = fileContent;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
