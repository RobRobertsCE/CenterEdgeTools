using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.BranchHelper
{
    public class BranchMap
    {
        private IList<RepoBranch> Branches { get; set; }

        public RepoBranch MasterBranch { get; set; }
        public RepoBranch AlphaBranch { get; set; }
        public RepoBranch BetaBranch { get; set; }
        public RepoBranch DevelopBranch { get; set; }

        public BranchMap()
        {
            var developVersion = BranchVersionHelper.GetVersionOnDate(DateTime.Now);
            var alphaVersion = new Version(developVersion.Major, developVersion.Minor, developVersion.Revision - 0);
            var betaVersion = new Version(developVersion.Major, developVersion.Minor, developVersion.Revision - 1);
            var masterVersion = new Version(developVersion.Major, developVersion.Minor, developVersion.Revision - 2);

            Initialize(masterVersion, alphaVersion, betaVersion, developVersion);
        }

        public BranchMap(Version masterVersion, Version alphaVersion, Version betaVersion, Version developVersion)
        {
            Initialize(masterVersion, alphaVersion, betaVersion, developVersion);
        }

        void Initialize(Version masterVersion, Version alphaVersion, Version betaVersion, Version developVersion)
        {
            Branches = new List<RepoBranch>();

            MasterBranch = new RepoBranch()
            {
                Version = masterVersion,
                Name = "master",
                Title = BranchTitle.master,
                RequiresPatches = true
            };

            AlphaBranch = new RepoBranch()
            {
                Version = alphaVersion,
                Name = String.Format("release-{0}.{1}", alphaVersion.Major, alphaVersion.Minor),
                Title = BranchTitle.alpha,
                Child = MasterBranch,
                RequiresPatches = true
            };
            MasterBranch.Parent = AlphaBranch;


            BetaBranch = new RepoBranch()
            {
                Version = betaVersion,
                Name = String.Format("{0}.{1}", alphaVersion.Major, alphaVersion.Minor),
                Title = BranchTitle.beta,
                Child = AlphaBranch,
                RequiresPatches = true
            };
            AlphaBranch.Parent = BetaBranch;

            DevelopBranch = new RepoBranch()
            {
                Version = developVersion,
                Name = "develop",
                Title = BranchTitle.develop,
                Child = AlphaBranch,
                RequiresPatches = false
            };
            BetaBranch.Parent = DevelopBranch;

            Branches.Add(MasterBranch);
            Branches.Add(AlphaBranch);
            Branches.Add(BetaBranch);
            Branches.Add(DevelopBranch);
        }

        public RepoBranch GetRepoBranch(Version version)
        {
            return Branches.FirstOrDefault(b => b.Version.Major == version.Major && b.Version.Minor == version.Minor);
        }
        public RepoBranch GetRepoBranch(BranchTitle branch)
        {
            return Branches.FirstOrDefault(b => b.Title == branch);
        }
        public RepoBranch GetRepoBranch(string branchName)
        {
            var branchBuffer = Branches.FirstOrDefault(b => b.Name == branchName);
            if (null == branchBuffer)
            {
                var branchNameSections = branchName.Split('-');
                if (branchNameSections[0].ToUpper() == "EPIC")
                {
                    branchBuffer = GetEpicRepoBranch(branchNameSections);
                }
                else if (branchNameSections[0].ToUpper() == "BETA")
                {
                    var branchVersion = new Version(17, 1);
                    branchBuffer = GetRepoBranch(branchVersion);
                }
                else if (branchNameSections[0].ToUpper() == "FEATURE")
                {
                    branchBuffer = Branches.FirstOrDefault(b => b.Name == branchNameSections[1]);
                }
                else
                {
                    var branchVersionSections = branchNameSections[1].Split('.');
                    var branchVersion = new Version(Convert.ToInt32(branchVersionSections[0]), Convert.ToInt32(branchVersionSections[1]));
                    branchBuffer = GetRepoBranch(branchVersion);
                }
            }
            return branchBuffer;
        }

        public RepoBranch GetEpicRepoBranch(string[] branchNameSections)
        {
            RepoBranch branchBuffer = null;
            if (branchNameSections[0].ToUpper() == "EPIC")
            {
                if (branchNameSections[1].ToUpper() == "ADVANTAGE") // created from the develop branch
                {
                    branchBuffer = GetRepoBranch(BranchTitle.develop);
                }
            }
            return branchBuffer;
        }
    }
}
