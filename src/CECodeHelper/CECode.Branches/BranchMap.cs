using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Branches
{
    public class BranchMap
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string JiraProject { get; set; }
        public string GitHubProject { get; set; }
        public string TeamCityProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TargetDate { get; set; }
        public Version Version
        {
            get
            {
                return Branches.FirstOrDefault(b => b.Name == "develop").Version;
            }
        }

        public IList<CEBranchDefinition> Branches { get; set; }

        public BranchMap()
        {
            Branches = new List<CEBranchDefinition>();
        }
    }

    public class CEBranchDefinition
    {
        public string Name { get; set; }
        public int BranchIdx { get; set; }
        public Version Version { get; set; }
        public bool HasPatches { get; set; }

        public IList<string> TeamCityBuildTypes { get; set; }

        public CEBranchDefinition()
        {
            TeamCityBuildTypes = new List<string>();
        }
    }

    public class BranchMapFactory
    {
        public static IList<BranchMap> GetBranchMaps()
        {
            return GetBranchMaps(DateTime.Now);
        }

        public static IList<BranchMap> GetBranchMaps(DateTime targetDate)
        {
            IList<BranchMap> maps = new List<BranchMap>();

            var advantageMap = new BranchMap()
            {
                Name = "Advantage",
                Team = "AMS",
                JiraProject = "Advantage",
                GitHubProject = "Advantage",
                TeamCityProject = "Advantage",
                TargetDate = targetDate
            };

            advantageMap.Branches = GetBranchesByDate(targetDate, advantageMap);

            maps.Add(advantageMap);

            return maps;
        }


        private static CEBranchDefinition GetDevelopBranch()
        {
            var branch = new CEBranchDefinition()
            {
                Name = "develop",
                BranchIdx = 0,
                HasPatches = false,
                TeamCityBuildTypes = new List<string>() {
                    "Advantage_AutoMerge",
                    "Advantage_Build"
                }
            };

            return branch;
        }

        private static CEBranchDefinition GetAlphaBranch()
        {
            var branch = new CEBranchDefinition()
            {
                Name = "alpha",
                BranchIdx = 1,
                HasPatches = true,
                TeamCityBuildTypes = new List<string>() {
                    "Advantage_AutoMerge",
                    "Advantage_Build",
                    "Advantage_Patches"
                }
            };

            return branch;
        }

        private static CEBranchDefinition GetBetaBranch()
        {
            var branch = new CEBranchDefinition()
            {
                Name = "beta",
                BranchIdx = 2,
                HasPatches = true,
                TeamCityBuildTypes = new List<string>() {
                    "Advantage_AutoMerge",
                    "Advantage_Build",
                    "Advantage_Patches"
                }
            };

            return branch;
        }

        private static CEBranchDefinition GetMasterBranch()
        {
            var branch = new CEBranchDefinition()
            {
                Name = "master",
                BranchIdx = 3,
                HasPatches = true,
                TeamCityBuildTypes = new List<string>() {
                    "Advantage_AutoMerge",
                    "Advantage_Build",
                    "Advantage_Patches"
                }
            };

            return branch;
        }

        private static IList<CEBranchDefinition> GetBranchesByDate(DateTime mapDate, BranchMap map)
        {
            IList<CEBranchDefinition> branches = new List<CEBranchDefinition>();

            Version currentDevelopVersion = GetVersionOnDate(mapDate, map);

            var major = currentDevelopVersion.Major;
            var minor = currentDevelopVersion.Minor;
            var build = currentDevelopVersion.Build;

            var dev = GetDevelopBranch();
            dev.Version = currentDevelopVersion;
            branches.Add(dev);

            if (minor == 1)
            {
                minor = 4;
                major -= 1;
            }
            else
            {
                minor -= 1;
            }

            if (minor < 3)
            {
                var alpha = GetAlphaBranch();
                alpha.Version = new Version(major, minor, build);
                branches.Add(alpha);
            }
            else
            {
                var beta = GetBetaBranch();
                beta.Version = new Version(major, minor, build);
                branches.Add(beta);
            }          

            if (minor == 1)
            {
                minor = 4;
                major -= 1;
            }
            else
            {
                minor -= 1;
            }

            // hack for change in versioning timespans.
            if (major == 16 && minor == 4) minor = 6;

            var master = GetMasterBranch();
            master.Version = new Version(major, minor, build);
            branches.Add(master);

            return branches;
        }

        private static Version GetVersionOnDate(DateTime targetDate, BranchMap map)
        {
            // 3/22/2017 sprint 17.2.H version 17.2.5

            DateTime startDate = new DateTime(2017, 3, 22).AddDays(-84); // 12 weeks = 84 days 

            var sprintNumber = 1;
            var releaseNumber = 2;
            var yearNumber = 17;

            Version startVersion = new Version(yearNumber, releaseNumber, sprintNumber);

            Version returnVersion = null;

            // increment every 3 weeks 
            DateTime sprintStartDate = startDate;

            while (sprintStartDate < targetDate)
            {
                Console.WriteLine("Sprint {0} for release {1}.{2} starts {3}", sprintNumber, yearNumber, releaseNumber, sprintStartDate.ToString());
                returnVersion = new Version(yearNumber, releaseNumber, sprintNumber);
                
                sprintNumber += 1;
                if (sprintNumber > 5)
                {
                    sprintNumber = 1;
                    releaseNumber += 1;
                }
                if (releaseNumber > 4)
                {
                    sprintNumber = 1;
                    releaseNumber = 1;
                    yearNumber += 1;
                }

                sprintStartDate = sprintStartDate.AddDays(21);
            }

            Console.WriteLine("Sprint {0} for release {1}.{2} starts {3}", sprintNumber, yearNumber, releaseNumber, sprintStartDate.ToString());

            map.StartDate = sprintStartDate.AddDays(-21);
            map.EndDate = sprintStartDate;

            return returnVersion;
        }
    }
}
