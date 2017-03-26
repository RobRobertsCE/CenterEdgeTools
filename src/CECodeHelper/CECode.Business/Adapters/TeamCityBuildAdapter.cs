using System;
using System.Collections.Generic;
using System.Globalization;
using CECode.TeamCity;
using CECode.TeamCity.Results;

namespace CECode.Business.Adapters
{
    internal class TeamCityBuildAdapter
    {
        #region public methods
        public static IList<ICEBuildDetails> Translate(IEnumerable<BuildDetails> builds)
        {
            IList<ICEBuildDetails> ICEBuilds = new List<ICEBuildDetails>();
            foreach (var entity in builds)
            {
                ICEBuilds.Add(Translate(entity));
            }
            return ICEBuilds;
        }

        public static ICEBuildDetails Translate(BuildDetails build)
        {
            if (null == build)
            {
                return new CEBuildDetails();
            }

            ICEBuildDetails ceBuild = new CEBuildDetails()
            {
                id = build.id,
                state = build.state,
                status = build.status,
                branchName = build.branchName,
                number = build.number,
                buildTypeId = build.buildTypeId,
                href = build.href,
                webUrl = build.webUrl
            };

            return ceBuild;
        }

        public static IList<ICEBuild> Translate(IEnumerable<RunningBuild> builds)
        {
            IList<ICEBuild> ICEBuilds = new List<ICEBuild>();
            if (null != builds)
            {
                foreach (var entity in builds)
                {
                    ICEBuilds.Add(Translate(entity));
                }
            }
            return ICEBuilds;
        }

        public static ICEBuild Translate(RunningBuild build)
        {
            ICEBuild ceBuild = new CEBuild()
            {
                id = build.id,
                state = build.state,
                status = build.status,
                branchName = build.branchName,
                number = build.number,
                buildTypeId = build.buildTypeId,
                href = build.href,
                webUrl = build.webUrl,
                percentageComplete = build.percentageComplete
            };

            return ceBuild;
        }

        public static IList<ICEBuildArtifact> Translate(IEnumerable<File> buildFiles)
        {
            IList<ICEBuildArtifact> ceBuildArtifacts = new List<ICEBuildArtifact>();
            foreach (var artifact in buildFiles)
            {
                ceBuildArtifacts.Add(Translate(artifact));
            }
            return ceBuildArtifacts;
        }

        public static ICEBuildArtifact Translate(File buildFile)
        {
            ICEBuildArtifact ceArtifact = new CEBuildArtifact()
            {
                name = buildFile.name,
                size = buildFile.size,
                modificationTime = DateTime.ParseExact(buildFile.modificationTime, "yyyyMMddTHHmmssK", CultureInfo.InvariantCulture),
                metadataHref = buildFile.href,
                contentHref = buildFile.content.href
            };

            return ceArtifact;
        }

        public static IList<ICEBuildIssue> Translate(IEnumerable<Issue> buildIssues)
        {
            IList<ICEBuildIssue> ceBuildIssues = new List<ICEBuildIssue>();
            foreach (var buildIssue in buildIssues)
            {
                ceBuildIssues.Add(Translate(buildIssue));
            }
            return ceBuildIssues;
        }

        public static ICEBuildIssue Translate(Issue buildIssue)
        {
            ICEBuildIssue ceBuildIssue = new CEBuildIssue()
            {
                id = buildIssue.id,
                url = buildIssue.url
            };

            return ceBuildIssue;
        }
        #endregion
    }
}
