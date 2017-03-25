using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CECode.Logging;
using CECode.TeamCity.Results;

namespace CECode.TeamCity.Service
{
    public class TeamCityService : ITeamCityService
    {
        #region fields
        private readonly string _user;
        private readonly string _password;
        private readonly bool _verboseLogging = true;
        #endregion

        #region ctor
        public TeamCityService(string user, string password)
        {
            _user = user;
            _password = password;
        }
        #endregion

        #region public methods
        public BuildDetails GetAdvantageBuild()
        {
            return GetBuildByType(Constants.AdvantageBuild);
        }

        public BuildDetails GetAdvantagePatchBuild()
        {
            return GetBuildByType(Constants.PatchBuild);
        }

        public BuildDetails GetAdvantageAutoMergeBuild()
        {
            return GetBuildByType(Constants.AutoMergeBuild);
        }

        public BuildDetails GetBuildByType(string buildType)
        {
            var url = BuildDetails.GetTypeUrl(buildType);
            return GetResponseData<BuildDetails>(url);
        }

        public IList<BuildDetails> GetBuildsByMergeNumber(int mergeNumber)
        {
            var url = BuildDetails.GetMergeUrl(mergeNumber);
            var response = GetResponseData<BuildsRequestResult>(url);
            return (null != response) ? response.build : new List<BuildDetails>();
        }

        public BuildDetails GetBuild(long buildId)
        {
            var url = BuildDetails.GetItemUrl(buildId);
            return GetResponseData<BuildDetails>(url);
        }

        public IList<RunningBuild> GetBuilds(string locator)
        {
            var url = BuildDetails.GetListUrl() + String.Format("?{0}", locator);
            var response = GetResponseData<RunningBuildsRequestResult>(url);
            return (null != response) ? response.build : new List<RunningBuild>();
        }

        public IList<RunningBuild> GetBuilds()
        {
            var url = BuildDetails.GetAllBuildsListUrl() ;
            var response = GetResponseData<RunningBuildsRequestResult>(url);
            return (null != response) ? response.build : new List<RunningBuild>();
        }

        public IList<RunningBuild> GetBuildTypeBuilds(string buildType)
        {
            var url = BuildDetails.GetTypeBuildsUrl(buildType);// +String.Format("?{0}", locator);
            var response = GetResponseData<RunningBuildsRequestResult>(url);
            return (null != response) ? response.build : new List<RunningBuild>();
        }

        public IList<RunningBuild> GetQueuedBuilds()
        {
            var url = BuildDetails.GetQueueURL();
            var response = GetResponseData<RunningBuildsRequestResult>(url);
            return (null != response) ? response.build : new List<RunningBuild>();
        }

        public IList<RunningBuild> GetRunningBuilds()
        {
            var url = BuildDetails.GetRunningUrl();
            var response = GetResponseData<RunningBuildsRequestResult>(url);
            return (null != response) ? response.build : new List<RunningBuild>();
        }
        #endregion

        #region protected virtual methods

        protected virtual T GetResponseData<T>(string url)
        {
            T result;

            Logger.Log.Debug(url);

            var uri = new Uri(url);

            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (_verboseLogging)
            {
                Logger.Log.Debug(String.Format("Response Status: {0}; Message: {1}; Reason Phrase: {2}", response.StatusCode, response.RequestMessage, response.ReasonPhrase));
            }

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var responseData = response.Content.ReadAsAsync<T>();
                    var dataObject = responseData.Result;
                    result = dataObject;
                }
                catch (Exception ex)
                {
                    var readStringTask = response.Content.ReadAsStringAsync();
                    string contentString = readStringTask.Result;
                    Logger.Log.Error(String.Format("Exception in TeamCity Response.\r\nContent:{0}", contentString), ex);
                    result = default(T);
                }
            }
            else
            {
                Logger.Log.Error(String.Format("Response Status: {0}; Message: {1}; Reason Phrase: {2}", response.StatusCode, response.RequestMessage, response.ReasonPhrase));
                result = default(T);
            }

            return result;
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
