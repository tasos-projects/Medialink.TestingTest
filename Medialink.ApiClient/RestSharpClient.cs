using Medialink.RepositoryInterfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.ApiClient
{
    public class RestSharpClient : IApiClientRepository
    {
        private IRestClient _restClient;

        public RestSharpClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            _restClient.AddDefaultHeader("SecretKey", "SecretPassword");
        }

        public string Get(string apiRoute)
        {
            IRestRequest request = new RestRequest(apiRoute, Method.GET);
            IRestResponse<RootObject> response = _restClient.Execute<RootObject>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new Exception("401 Error - Unauthorized Access");

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            else
                throw new Exception($"{(int)response.StatusCode} Error - {response.StatusCode}, Message: {response.Content}");
        }
    }





    class Args
    {
        public string clientId { get; set; }
    }

    class Headers
    {
        public string Accept { get; set; }

        public string AcceptEncoding { get; set; }

        public string AcceptLanguage { get; set; }

        public string Authorization { get; set; }

        public string Connection { get; set; }

        public string Dnt { get; set; }

        public string Host { get; set; }

        public string Origin { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }
    }

    class RootObject
    {
        public Args args { get; set; }

        public Headers headers { get; set; }

        public string origin { get; set; }

        public string url { get; set; }

        public string data { get; set; }

        public Dictionary<string, string> files { get; set; }
    }
}
