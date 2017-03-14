using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CECode.BranchHelper
{
    public static class BranchVersionHelper
    {
        // TODO: WinUserName and RepoName to settings
        #region consts      
        private const string VersionFileTemplate = @"C:\Users\{0}\Source\Repos\{1}\src\version.txt";
        private const string WinUserName = "rroberts";
        private const string RepoName = "ADVANTAGE";
        #endregion

        static BranchMap _map;
        public static BranchMap Map
        {
            get
            {
                return _map;
            }
        }

        public static RepoBranch DevelopBranch
        {
            get
            {
                return _map.DevelopBranch;
            }
        }
        public static RepoBranch AlphaBranch
        {
            get
            {
                return _map.AlphaBranch;
            }
        }
        public static RepoBranch BetaBranch
        {
            get
            {
                return _map.BetaBranch;
            }
        }
        public static RepoBranch MasterBranch
        {
            get
            {
                return _map.MasterBranch;
            }
        }

        public static Version CurrentVersion
        {
            get
            {
                var versionFileContent = File.ReadAllText(VersionFile);
                return new Version(versionFileContent);
            }
        }

        public static RepoBranch CurrentBranch
        {
            get
            {
                return _map.GetRepoBranch(CurrentVersion);
            }
        }

        public static string VersionFile
        {
            get
            {
                return String.Format(VersionFileTemplate, WinUserName, RepoName);
            }
        }

        static BranchVersionHelper()
        {
            var develop = new Version(17, 2); //GetVersionOnDate(DateTime.Now);
            var alpha = new Version(17, 0); //GetVersionOnDate(DateTime.Now);
            var beta = new Version(17, 1);
            var master = new Version(16, 6);
            _map = new BranchMap(master, alpha, beta, develop);
        }

        public static Version GetVersionOnDate(DateTime dateToCalculateVersionOn)
        {
            var startVer = new Version(Properties.Resources.StartVersion);
            var versionStartDate = DateTime.Parse(Properties.Resources.StartDate);
            var sprintCountPerMinorVersion = Int32.Parse(Properties.Resources.SprintCountPerVersion);
            var sprintLengthDays = Int32.Parse(Properties.Resources.SprintLengthDays);

            var daysSinceStart = (int)dateToCalculateVersionOn.Subtract(versionStartDate).TotalDays;
            var sprintsSinceStart = (int)(daysSinceStart / sprintLengthDays);


            var minorVesionsSinceStart = 0;
            if (sprintsSinceStart > 0)
            {
                minorVesionsSinceStart = (int)(sprintsSinceStart / sprintCountPerMinorVersion);
            }

            var majorVersionNumber = Int32.Parse(versionStartDate.Year.ToString().Substring(2, 2));
            var minorVersionNumber = startVer.Minor + minorVesionsSinceStart;
            // only 6 minor versions per year.. hardening spring throws it off.
            if (minorVersionNumber == 7) minorVersionNumber = 6;

            var version = new Version(majorVersionNumber, minorVersionNumber);

            Console.WriteLine("Version on {0}: {1}", dateToCalculateVersionOn.ToShortDateString(), version.ToString());
            return version;
        }
    }
}
