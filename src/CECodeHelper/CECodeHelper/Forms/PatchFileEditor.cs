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

namespace CECodeHelper
{
    public partial class PatchFileEditor : Form
    {
        private const int MinVersion = 15;
        private const string TestProgramSetupDirectory = @"\\ceserver\Development\Test Program Setups\Advantage";

        private IDictionary<int, List<PatchNotes>> _majorVersionPatchNotes = null;

        public PatchFileEditor()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadPatchNotes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void PatchFileEditor_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPatchNotes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void LoadPatchNotes()
        {
            _majorVersionPatchNotes = new Dictionary<int, List<PatchNotes>>();
            List<PatchNotes> minorVersionPatchNotes = new List<PatchNotes>();

            var rootDirectory = new DirectoryInfo(TestProgramSetupDirectory);

            foreach (var versionDirectory in rootDirectory.GetDirectories())
            {
                if (IsNumeric(versionDirectory.Name))
                {
                    Single versionNumber = 0;
                    if (Single.TryParse(versionDirectory.Name, out versionNumber))
                    {
                        if (versionNumber > MinVersion)
                        {
                            foreach (var buildDirectory in versionDirectory.GetDirectories("Version *"))
                            {
                                var buildVersion = new Version(buildDirectory.Name.Replace("Version ", ""));
                                var majorVersion = buildVersion.Major;
                                var patchFolderPath = Path.Combine(buildDirectory.FullName, "Patch");
                                var patchFilePath = Path.Combine(patchFolderPath, "Patch Notes.txt");
                                if (File.Exists(patchFilePath))
                                {
                                    var patchVersion = new PatchNotes() { Folder = patchFolderPath, Path = patchFilePath, Version = buildVersion };
                                    if (_majorVersionPatchNotes.ContainsKey(majorVersion))
                                        minorVersionPatchNotes = _majorVersionPatchNotes[majorVersion];
                                    else
                                    {
                                        minorVersionPatchNotes = new List<PatchNotes>();
                                        _majorVersionPatchNotes.Add(majorVersion, minorVersionPatchNotes);
                                    }
                                    patchVersion.ParsePatchFile();
                                    minorVersionPatchNotes.Add(patchVersion);
                                }
                            }
                        }
                    }
                }
            }

            DebugDisplay();

            DisplayPatchNoteFiles();
        }

        private void DebugDisplay()
        {
            try
            {
                /***** DEV *****/
                txtDisplay.Text += "Found the following versions:\r\n";
                var majorVersions = _majorVersionPatchNotes.Keys.ToList();
                foreach (var majorVersion in majorVersions.Where(v => v >= 16).OrderBy(v => v))
                {
                    txtDisplay.Text += majorVersion.ToString() + "\r\n";
                    var minorVersionPatchNotes = _majorVersionPatchNotes[majorVersion];
                    foreach (PatchNotes patchVersion in minorVersionPatchNotes.OrderBy(v => v.Version))
                    {
                        txtDisplay.Text += "\t" + patchVersion.Version.ToString() + "\r\n";
                        foreach (var update in patchVersion.Updates)
                        {
                            txtDisplay.Text += "\t\t" + String.Format("{0}: {1}", update.UpdateNumber, update.UpdateDate) + "\r\n";

                            foreach (var entry in update.Entries)
                            {
                                txtDisplay.Text += "\t\t\t" + entry.Comment + "\r\n";
                                foreach (var jiraKey in entry.JiraKeys)
                                {
                                    txtDisplay.Text += "\t\t\t\t" + jiraKey + "\r\n";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool IsNumeric(string value)
        {
            Single buffer = -1;
            return Single.TryParse(value, out buffer);
        }

        private void DisplayPatchNoteFiles()
        {
            try
            {
                patchNotesTree.SuspendLayout();
                patchNotesTree.Nodes.Clear();
                IList<PatchNotes> minorVersionPatchNotes = null;

                var majorVersions = _majorVersionPatchNotes.Keys.ToList();
                foreach (var majorVersion in majorVersions.Where(v => v >= 16).OrderBy(v => v))
                {
                    var majorVersionNode = new TreeNode(majorVersion.ToString());
                    minorVersionPatchNotes = _majorVersionPatchNotes[majorVersion];
                    foreach (PatchNotes patchVersion in minorVersionPatchNotes.OrderBy(v => v.Version))
                    {
                        var patchVersionNode = new TreeNode(String.Format("{0} [{1} updates]", patchVersion.Version.ToString(), patchVersion.Updates.Count)) { Tag = patchVersion };
                        foreach (var update in patchVersion.Updates)
                        {
                            var updateNode = new TreeNode(String.Format("{0} [{1} entries]", update.Line, update.Entries.Count)) { Tag = update };

                            foreach (var entry in update.Entries)
                            {
                                var entryNode = new TreeNode(String.Format("{0} [{1} JIRA issues]", entry.Comment, entry.JiraKeys.Count)) { Tag = entry };

                                foreach (var jiraKey in entry.JiraKeys)
                                {
                                    var jiraNode = new TreeNode(jiraKey);
                                    entryNode.Nodes.Add(jiraNode);
                                }
                                updateNode.Nodes.Add(entryNode);
                            }
                            patchVersionNode.Nodes.Add(updateNode);
                        }
                        majorVersionNode.Nodes.Add(patchVersionNode);
                    }
                    patchNotesTree.Nodes.Add(majorVersionNode);
                }

                var selectedMajorVersionNode = patchNotesTree.Nodes[patchNotesTree.Nodes.Count - 1];
                selectedMajorVersionNode.Expand();
                var selectedPatchVersionNode = selectedMajorVersionNode.Nodes[selectedMajorVersionNode.Nodes.Count - 1];
                selectedPatchVersionNode.Expand();
                var selectedUpdateVersionNode = selectedPatchVersionNode.Nodes[0];
                selectedUpdateVersionNode.Expand();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                patchNotesTree.ResumeLayout();
            }
        }

        private class PatchNotes
        {
            public Version Version { get; set; }
            public string Folder { get; set; }
            public string Path { get; set; }
            public IList<PatchNotesUpdate> Updates { get; set; }

            public PatchNotes()
            {
                Updates = new List<PatchNotesUpdate>();
            }

            public void ParsePatchFile()
            {
                var patchFileLines = File.ReadAllLines(Path);
                PatchNotesUpdate update = null;
                foreach (string patchFileLine in patchFileLines.Select(l => l.Trim()))
                {
                    if (patchFileLine.StartsWith("Update"))
                    {
                        var updateNumber = -1;
                        var updateLine = patchFileLine.Split(' ');
                        if (updateLine.Length == 3)
                        {
                            updateNumber = Convert.ToInt32(updateLine[1].Replace("#", ""));
                        }

                        update = Updates.FirstOrDefault(u => u.UpdateNumber == updateNumber);

                        if (null == update)
                        {
                            update = new PatchNotesUpdate(patchFileLine) { UpdateNumber = updateNumber };
                            update.UpdateDate = DateTime.Parse(updateLine[2]);
                            Updates.Add(update);
                        }
                    }
                    else if (!String.IsNullOrEmpty(patchFileLine))
                    {
                        update.Entries.Add(new PatchNotesEntry(patchFileLine));
                    }
                }
            }
        }

        private class PatchNotesUpdate
        {
            public string Line { get; set; }
            public int UpdateNumber { get; set; }
            public DateTime UpdateDate { get; set; }
            public IList<PatchNotesEntry> Entries { get; set; }

            public PatchNotesUpdate(string patchFileLine)
            {
                Line = patchFileLine;
                Entries = new List<PatchNotesEntry>();
                UpdateNumber = -1;
            }
        }

        private class PatchNotesEntry
        {
            public string Line { get; set; }
            public string Comment { get; set; }
            public IList<string> JiraKeys { get; set; }
            public IList<int> JiraNumbers { get; set; }

            public PatchNotesEntry(string patchFileLine)
            {
                Line = patchFileLine;
                JiraKeys = new List<string>();
                JiraNumbers = new List<int>();
                int openParenIdx = patchFileLine.LastIndexOf('(');
                int closeParenIdx = patchFileLine.LastIndexOf(')');
                Comment = patchFileLine.Substring(0, openParenIdx).Trim();
                var jiraIssueContent = patchFileLine.Substring(openParenIdx + 1, closeParenIdx - openParenIdx - 1);
                if (jiraIssueContent.Contains(","))
                {
                    /* multiple issues */
                    var jiraIssues = jiraIssueContent.Split(',');
                    for (int i = 0; i < jiraIssues.Length; i++)
                    {
                        var jiraKey = jiraIssues[i].Trim();
                        JiraKeys.Add(jiraKey);
                        var jiraKeySections = jiraKey.Split('-');
                        var jiraIssueNumber = Convert.ToInt32(jiraKeySections[1].Trim());
                        JiraNumbers.Add(jiraIssueNumber);
                    }
                }
                else
                {
                    /* single issue */
                    var jiraKey = jiraIssueContent.Trim();
                    JiraKeys.Add(jiraKey);
                    var jiraKeySections = jiraKey.Split('-');
                    var jiraIssueNumber = Convert.ToInt32(jiraKeySections[1].Trim());
                    JiraNumbers.Add(jiraIssueNumber);
                }
            }
        }

    }
}
