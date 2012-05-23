using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SubsonicApi {
    public class SubsonicClient {
        private readonly RestClient _client;

        public bool Connected { get; set; }

        public SubsonicClient(string baseHost, string username, string password, string clientId) {
            _client = new RestClient(baseHost);
            _client.UserAgent = clientId;
            _client.AddDefaultParameter("u", username);
            _client.AddDefaultParameter("p", password);
            _client.AddDefaultParameter("c", clientId);
            _client.AddDefaultParameter("v", "1.7.0");
            _client.AddDefaultParameter("f", "xml");

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public async Task<bool> Ping() {
            return await DoSimpleRequest("rest/ping.view", response => response.IsOk.GetValueOrDefault(false));
        }

        public async Task<List<MusicFolder>> GetMusicFolders() {
            return await DoSimpleRequest("rest/getMusicFolders.view", response => response.MusicFolders);
        }

        public async Task<List<NowPlaying>> GetNowPlaying() {
            return await DoSimpleRequest("rest/getNowPlaying.view", response => response.NowPlaying);
        }

        public async Task<IndexList> GetIndexes(MusicFolder folder = null, DateTime? modifiedSince = null) {
            var parameters = new List<Parameter>();
            if (folder != null) {
                parameters.Add(new Parameter { Name = "musicFolderId", Value = folder.Id, Type = ParameterType.GetOrPost });
            }
            if (modifiedSince != null) {
                // TODO: find out what format this date is supposed to be in
                parameters.Add(new Parameter { Name = "ifModifiedSince", Value = modifiedSince.Value.ToString("yyyMMddTHHmmss"), Type = ParameterType.GetOrPost });
            }
            return await DoSimpleRequest("rest/getIndexes.view", parameters, response => response.Indexes);
        }

        private async Task<T> DoSimpleRequest<T>(string path, Func<SubsonicResponse, T> transform) {
            return await DoSimpleRequest(path, new Parameter[0], transform);
        }

        private async Task<T> DoSimpleRequest<T>(string path, IEnumerable<Parameter> parameters, Func<SubsonicResponse, T> transform) {
            var request = new RestRequest(path);
            foreach (var parameter in parameters) {
                request.AddParameter(parameter);
            }
            var response = await RunRequest(request);
            ThrowOnErrors(response);
            return transform(response.Data);
        }

        private void ThrowOnErrors(IRestResponse<SubsonicResponse> response) {
            if (response.ResponseStatus == ResponseStatus.Error) {
                throw new ConnectionException(response.ErrorMessage, response.ErrorException);
            }

            if (!response.Data.IsOk.HasValue) {
                throw new SubsonicApiException("Unknown failure");
            }

            if (!response.Data.IsOk.Value) {
                if (response.Data.Error != null) {
                    throw new SubsonicServerException(response.Data.Error);
                }
            }
        }

        private Task<IRestResponse<SubsonicResponse>> RunRequest(RestRequest request) {
            return Task.Run(() => _client.Execute<SubsonicResponse>(request));
        }
    }
}
