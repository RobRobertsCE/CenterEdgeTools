using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CECode.TeamCity.Service
{
    public class TeamCityService : ITeamCityService
    {
        #region fields
        private readonly string _user;
        private readonly string _password;
        #endregion

        #region ctor
        public TeamCityService(string user, string password)
        {
            _user = user;
            _password = password;
        }
        #endregion

        #region public methods
        public Build GetAdvantageBuild()
        {
            return GetBuildByType("Advantage_Build");
        }

        public Build GetAdvantagePatches()
        {
            return GetBuildByType("Advantage_Patches");
        }

        public Build GetBuildByType(string buildType)
        {
            var url = Build.GetListUrl();
            if (!String.IsNullOrEmpty(buildType))
            {
                url += "/" + String.Format("buildType:{0}", buildType);
            }
            Console.WriteLine(url);
            var uri = new Uri(url);
            return GetResponseData<Build>(uri);
        }

        public Build GetBuildById(long id)
        {
            var url = Build.GetListUrl() + "/" + String.Format("id:{0}", id);          
            Console.WriteLine(url);
            var uri = new Uri(url);
            return GetResponseData<Build>(uri);
        }

        public Build GetBuildByNumber(string number)
        {
            //var url = Build.GetListUrl() +  "/" + String.Format("?locator=number:{0}", number);
            var url = Build.GetListUrl() + "/" + String.Format("?locator=branch:default:any,name=({0}/merge)", number);
            Console.WriteLine(url);
            var uri = new Uri(url);
            var build = GetResponseData<Build>(uri);

            return build;
        }

        public IList<RunningBuild.Build> GetBuilds(string locator)
        {
            IList<RunningBuild.Build> results = new List<RunningBuild.Build>();

            HttpClient client = new HttpClient();
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds?locator=running:true,branch:default:any";
            var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/builds?{0}", locator);
            Console.WriteLine(url);
            client.BaseAddress = new Uri(url);


            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = GetCredentials();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<RunningBuild>();
                // TODO: Check result status
                if (null != responseData.Result)
                {
                    if (responseData.Result.count > 0)
                    {

                        results = responseData.Result.build;

                        foreach (var runningBuild in results)
                        {
                            Console.WriteLine("{0} {1} {2} {3}", runningBuild.id, runningBuild.number, runningBuild.state, runningBuild.percentageComplete);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        public IList<RunningBuild.Build> GetRunningBuilds()
        {
            IList<RunningBuild.Build> results = new List<RunningBuild.Build>();

            HttpClient client = new HttpClient();
            var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds?locator=running:true,branch:default:any";
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = GetCredentials();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            HttpResponseMessage response = client.GetAsync("").Result; 
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsAsync<RunningBuild>();
                
                if (null != responseData.Result)
                {
                    if (responseData.Result.count > 0)
                    {

                        results = responseData.Result.build;

                        foreach (var runningBuild in results)
                        {
                            Console.WriteLine("{0} {1} {2} {3}", runningBuild.id, runningBuild.number, runningBuild.state, runningBuild.percentageComplete);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        public BuildDetails GetBuildDetails(Build build)
        {
            return GetBuildDetails(build.id);
        }

        public BuildDetails GetBuildDetails(long id)
        {
            var url = Build.GetListUrl() + "/" + String.Format("id:{0}", id);
            Console.WriteLine(url);
            var uri = new Uri(url);
            return GetResponseData<BuildDetails>(uri);
        }
        #endregion

        #region protected virtual methods
        protected virtual T GetResponseData<T>(Uri uri)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsAsync<T>();
                var dataObject = responseData.Result;
                return dataObject;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return default(T);
            }
        }

        protected virtual HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            byte[] credentials = GetCredentials();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
            return client;
        }

        protected virtual byte[] GetCredentials()
        {
            return UTF8Encoding.UTF8.GetBytes(String.Format("{0}:{1}", _user, _password));
        }
        #endregion
    }
}
