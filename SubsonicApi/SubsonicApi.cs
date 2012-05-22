using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SubsonicApi {
    public class SubsonicApi {
        public Uri RestUri { get; set; }

        public SubsonicApi(Uri baseHost, string userName, string password, string clientId) {
            var parameters = new Dictionary<string, string>();
            parameters["u"] = userName;
            parameters["p"] = password;
            parameters["v"] = "1.7.0";
            parameters["c"] = clientId;
            parameters["f"] = "json";
            RestUri = new Uri(baseHost, "rest").SetParameters(parameters);
        }

        public bool TestConnection() {
            try {
                HttpWebRequest request = WebRequest.CreateHttp(new Uri(RestUri, "ping.view"));
                IAsyncResult asyncResult = request.BeginGetResponse((result) => new StreamReader(request.EndGetResponse(result).GetResponseStream()).ReadToEnd(), null);
                asyncResult.AsyncWaitHandle.WaitOne();
            } catch (IOException) {
                return false;
            }
            return true;
        }
    }
}
