using System.Collections.Generic;
using Newtonsoft.Json;

namespace CECode.TeamCity.Results
{
    public class BuildsRequestResult
    {
        public int count { get; set; }
        public string href { get; set; }
        public string nextHref { get; set; }
        public List<BuildDetails> build { get; set; }       
    }

    public class BuildDetails : EndpointBase
    {
        public int id { get; set; }
        public string buildTypeId { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public string branchName { get; set; }
        public bool defaultBranch { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
        public string statusText { get; set; }
        public BuildType buildType { get; set; }
        public string queuedDate { get; set; }
        public string startDate { get; set; }
        public string finishDate { get; set; }
        public Triggered triggered { get; set; }
        public LastChanges lastChanges { get; set; }
        public Changes changes { get; set; }
        public Revisions revisions { get; set; }
        public Agent agent { get; set; }
        public TestOccurrences testOccurrences { get; set; }
        public Artifacts artifacts { get; set; }
        public RelatedIssues relatedIssues { get; set; }
        public Properties properties { get; set; }
        public Statistics statistics { get; set; }

        public class BuildType
        {
            public string id { get; set; }
            public string name { get; set; }
            public string projectName { get; set; }
            public string projectId { get; set; }
            public string href { get; set; }
            public string webUrl { get; set; }
        }

        public class Triggered
        {
            public string type { get; set; }
            public string details { get; set; }
            public string date { get; set; }
        }

        public class Change
        {
            public int id { get; set; }
            public string version { get; set; }
            public string username { get; set; }
            public string date { get; set; }
            public string href { get; set; }
            public string webUrl { get; set; }
        }

        public class LastChanges
        {
            public int count { get; set; }
            public List<Change> change { get; set; }
        }

        public class Changes
        {
            public string href { get; set; }
        }

        public class Revision
        {
            public string version { get; set; }
            [JsonProperty(PropertyName = "vcs-root-instance")]
            public VcsRootInstance vcs_root_instance { get; set; }
        }

        public class Revisions
        {
            public int count { get; set; }
            public List<Revision> revision { get; set; }
        }

        public class Agent
        {
            public int id { get; set; }
            public string name { get; set; }
            public int typeId { get; set; }
            public string href { get; set; }
        }

        public class TestOccurrences
        {
            public int count { get; set; }
            public string href { get; set; }
            public int passed { get; set; }
            public bool @default { get; set; }
        }

        public class Artifacts
        {
            public string href { get; set; }
        }

        public class RelatedIssues
        {
            public string href { get; set; }
        }

        public class Property
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Properties
        {
            public int count { get; set; }
            public List<Property> property { get; set; }
        }

        public class Statistics
        {
            public string href { get; set; }
        }

        public class VcsRootInstance
        {
            public string id { get; set; }
            [JsonProperty(PropertyName = "vcs-root-buildId")]
            public string vcs_root_id { get; set; }
            public string name { get; set; }
            public string href { get; set; }
        }

        public static string GetItemUrl(long id)
        {
            var urlSuffix = string.Format(Constants.BuildUrlSuffix, id);
            return BuildUrl(urlSuffix);
        }
        public static string GetListUrl()
        {
            return BuildUrl(Constants.BuildsUrlSuffix);
        }
        public static string GetAllBuildsListUrl()
        {
            return BuildUrl(Constants.AllBuildsUrlSuffix);
        }
        public static string GetTypeUrl(string buildType)
        {
            var urlSuffix = string.Format(Constants.BuildTypeUrlSuffix, buildType);
            return BuildUrl(urlSuffix);
        }
        public static string GetTypeBuildsUrl(string buildType)
        {
            var urlSuffix = string.Format(Constants.BuildTypeBuildsUrlSuffix, buildType);
            return BuildUrl(urlSuffix);
        }
        public static string GetRunningUrl()
        {
            return BuildUrl(Constants.RunningBuildsUrlSuffix);
        }
        public static string GetMergeUrl(int mergeNumber)
        {
            var urlSuffix = string.Format(Constants.MergeBuildUrlSuffix, mergeNumber);
            return BuildUrl(urlSuffix);
        }
        public static string GetQueueURL()
        {
            return BuildUrl(Constants.BuildQueueUrlSuffix);
        }
        public static string GetRelatedIssuesUrl(long id)
        {
            var urlSuffix = string.Format(Constants.BuildRelatedIssuesUrl, id);
            return BuildUrl(urlSuffix);
        }
        public static string GetArtifactsUrl(long id)
        {
            var urlSuffix = string.Format(Constants.BuildArtifactsUrl, id);
            return BuildUrl(urlSuffix);
        }
    }
}