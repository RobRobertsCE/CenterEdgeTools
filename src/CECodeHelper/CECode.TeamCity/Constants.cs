namespace CECode.TeamCity
{
    public static class Constants
    {
        public static string AdvantageRootUrl = @"https://teamcity.pfestore.com";
        public static string ProjectsUrlSuffix = @"/httpAuth/app/rest/projects";
        public static string ProjectUrlSuffix = @"/httpAuth/app/rest/projects/{0}";
        public static string ServerUrlSuffix = @"/httpAuth/app/rest/server";
        public static string BuildsUrlSuffix = @"/httpAuth/app/rest/builds";
        public static string BuildUrlSuffix = @"/httpAuth/app/rest/builds/id:{0}";
        public static string BuildLogUrlSuffix = @"/viewLog.html?buildId={0}&buildTypeId={1}";
        public static string BuildStatusIconUrlSuffix = @"/httpAuth/app/rest/builds/{0}/statusIcon ";
        public static string AdvantageProjectId = "Advantage";
        public static string AdvantageBuildTypeId = "Advantage_Build";
    }
}
