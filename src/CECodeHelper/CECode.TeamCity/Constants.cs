namespace CECode.TeamCity
{
    public static class Constants
    {
        public const string AdvantageBuild = "Advantage_Build";
        public const string PatchBuild = "Advantage_Patches";
        public const string AutoMergeBuild = "Advantage_AutoMerge";

        public const string AdvantageRootUrl = @"https://teamcity.pfestore.com";
        public const string BuildsUrlSuffix = @"/httpAuth/app/rest/builds";
        public const string BuildUrlSuffix = @"/httpAuth/app/rest/builds/buildId:{0}";
        public const string MergeBuildUrlSuffix = @"/httpAuth/app/rest/builds?locator=project:(id:Advantage),state:any,branch:{0}/merge";
        public const string BuildTypeUrlSuffix = @"/httpAuth/app/rest/builds/buildType:{0}";
        public const string BuildTypeBuildsUrlSuffix = @"/httpAuth/app/rest/builds?locator=project:(id:Advantage),buildType:{0},branch:default:any";
        public const string BuildStatusIconUrlSuffix = @"/httpAuth/app/rest/builds/{0}/statusIcon ";
        public const string BuildQueueUrlSuffix = @"/httpAuth/app/rest/buildQueue";
        public const string RunningBuildsUrlSuffix = @"/httpAuth/app/rest/builds?locator=project:(id:Advantage),running:true,branch:default:any";
        public const string AllBuildsUrlSuffix = @"/httpAuth/app/rest/builds?locator=project:(id:Advantage),branch:default:any,state:any";
        public const string BuildRelatedIssuesUrl = @"/httpAuth/app/rest/builds/id:{0}/relatedIssues";

        public const string BuildArtifactsUrl = @"/httpAuth/app/rest/builds/id:{0}/artifacts/children/";
    }
}
