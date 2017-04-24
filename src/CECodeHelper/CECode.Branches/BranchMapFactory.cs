using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CECode.Branches
{
    public class BranchMapFactory
    {
        #region consts
        private const string BranchMapFile = @"BranchMaps.json";
        private const int WeeksPerSprint = 3;
        private const int SprintsPerRelease = 4;
        private const int ReleasesPerYear = 4;
        #endregion

        #region fields
        private List<BranchMap> _maps;
        #endregion

        #region properties
        public List<BranchMap> Maps
        {
            get
            {
                return _maps.ToList();
            }
        }
        #endregion

        #region ctor
        public BranchMapFactory()
        {
            InitializeBranchMaps();
        }

        private void InitializeBranchMaps()
        {
            if (!LoadMaps())
            {
                _maps = GetBranchMaps();
                SaveMaps();
            }
        }
        #endregion

        #region public methods
        public BranchMap GetCurrentMap()
        {
            return GetMap(DateTime.Now);
        }
        public BranchMap GetMap(DateTime targetDate)
        {
            var map = _maps.FirstOrDefault(m => m.StartDate <= targetDate && m.EndDate >= targetDate);
            if (null == map)
            {
                _maps = GetBranchMaps(DateTime.Now.AddYears(1));
                map = _maps.FirstOrDefault(m => m.StartDate >= targetDate && m.EndDate <= targetDate);
                SaveMaps();
            }
            return map;
        }
        #endregion

        #region private methods - file
        private bool LoadMaps()
        {
            var result = false;

            if (File.Exists(BranchMapFile))
            {
                var json = File.ReadAllText(BranchMapFile);
                _maps = JsonConvert.DeserializeObject<List<BranchMap>>(json);
                result = _maps[0].Branches.Count > 0;
            }

            return result;
        }
        private void SaveMaps()
        {
            var json = JsonConvert.SerializeObject(_maps);
            File.WriteAllText(BranchMapFile, json);
        }
        #endregion

        #region private methods
        private List<BranchMap> GetBranchMaps()
        {
            return GetBranchMaps(DateTime.Now);
        }

        private List<BranchMap> GetBranchMaps(DateTime targetDate)
        {
            List<BranchMap> maps = new List<BranchMap>();

            var advantageMap = new BranchMap()
            {
                Name = "Advantage",
            };

            advantageMap.Branches = GetBranchesByDate(targetDate, advantageMap);

            maps.Add(advantageMap);

            return maps;
        }

        private BranchDetails GetDevelopBranch()
        {
            var branch = new BranchDetails()
            {
                BranchName = BranchNames.develop,
                HasPatches = false
            };

            return branch;
        }

        private BranchDetails GetAlphaBranch()
        {
            var branch = new BranchDetails()
            {
                BranchName = BranchNames.alpha,
                HasPatches = true
            };

            return branch;
        }

        private BranchDetails GetBetaBranch()
        {
            var branch = new BranchDetails()
            {
                BranchName = BranchNames.beta,
                HasPatches = true
            };

            return branch;
        }

        private BranchDetails GetMasterBranch()
        {
            var branch = new BranchDetails()
            {
                BranchName = BranchNames.master,
                HasPatches = true
            };

            return branch;
        }

        private List<BranchDetails> GetBranchesByDate(DateTime mapDate, BranchMap map)
        {
            List<BranchDetails> branches = new List<BranchDetails>();

            Version currentDevelopVersion = GetVersionOnDate(mapDate, map);

            var major = currentDevelopVersion.Major;
            var minor = currentDevelopVersion.Minor;
            var build = currentDevelopVersion.Build;
            var revision = 0;

            var dev = GetDevelopBranch();
            dev.Version = currentDevelopVersion;
            branches.Add(dev);

            if (minor == 1)
            {
                minor = SprintsPerRelease;
                major -= 1;
            }
            else
            {
                minor -= 1;
            }

            // sprint 2 has alpha, sprints 3 and 4 have beta 
            if (build == 2)
            {
                var alpha = GetAlphaBranch();
                alpha.Version = new Version(major, minor, build, revision);
                branches.Add(alpha);
            }
            else if (build > 2)
            {
                var beta = GetBetaBranch();
                beta.Version = new Version(major, minor, build, revision);
                branches.Add(beta);
            }

            if (minor == 1)
            {
                minor = SprintsPerRelease;
                major -= 1;
            }
            else
            {
                minor -= 1;
            }

            // hack for change in versioning timespans.
            if (major == 16 && minor == 4) minor = 6;

            var master = GetMasterBranch();
            master.Version = new Version(major, minor, build, revision);
            branches.Add(master);

            return branches;
        }

        private Version GetVersionOnDate(DateTime targetDate, BranchMap map)
        {
            // 3/22/2017 sprint 17.2.H version 17.2.4

            DateTime startDate = new DateTime(2017, 3, 22);

            var sprintNumber = 4;
            var releaseNumber = 2;
            var yearNumber = 17;

            Version startVersion = new Version(yearNumber, releaseNumber, sprintNumber, 0);

            Version returnVersion = null;

            // increment every 3 weeks 
            DateTime sprintStartDate = startDate;

            while (sprintStartDate < targetDate)
            {
                Console.WriteLine("Sprint {0} for release {1}.{2} starts {3}", sprintNumber, yearNumber, releaseNumber, sprintStartDate.ToString());
                returnVersion = new Version(yearNumber, releaseNumber, sprintNumber, 0);

                sprintNumber += 1;
                if (sprintNumber > SprintsPerRelease)
                {
                    sprintNumber = 1;
                    releaseNumber += 1;
                }
                if (releaseNumber > ReleasesPerYear)
                {
                    sprintNumber = 1;
                    releaseNumber = 1;
                    yearNumber += 1;
                }

                sprintStartDate = sprintStartDate.AddDays(WeeksPerSprint * 7);
            }

            Console.WriteLine("Sprint {0} for release {1}.{2} starts {3}", sprintNumber, yearNumber, releaseNumber, sprintStartDate.ToString());

            map.StartDate = sprintStartDate.AddDays(-WeeksPerSprint * 7);
            map.EndDate = sprintStartDate;

            return returnVersion;
        }
        #endregion
    }
}
