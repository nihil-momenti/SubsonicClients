using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using SubsonicApi.RestData;

namespace SubsonicApi {
    public class SubsonicClient {
        private readonly RestClient _client;

        public bool Connected { get; set; }

        public SubsonicClient(string baseHost, string userName, string password, string clientId) {
            _client = new RestClient(baseHost);
            _client.UserAgent = clientId;
            _client.AddDefaultParameter("u", userName);
            _client.AddDefaultParameter("p", password);
            _client.AddDefaultParameter("c", clientId);
            _client.AddDefaultParameter("v", "1.7.0");
            _client.AddDefaultParameter("f", "xml");

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public async Task<bool> Ping() {
            return await DoSimpleRequest("rest/ping.view", response => response.Ok);
        }

        public async Task<IReadOnlyList<MusicFolder>> GetMusicFolders() {
            return await DoSimpleRequest("rest/getMusicFolders.view", response => response.MusicFolders);
        }

        public async Task<IReadOnlyList<NowPlaying>> GetNowPlaying() {
            return await DoSimpleRequest("rest/getNowPlaying.view", response => response.NowPlaying);
        }

        public async Task<IndexList> GetIndexes() {
            return await GetIndexes(null, null);
        }

        public async Task<IndexList> GetIndexes(MusicFolder folder) {
            return await GetIndexes(folder, null);
        }

        public async Task<IndexList> GetIndexes(DateTime? modifiedSince) {
            return await GetIndexes(null, modifiedSince);
        }

        public async Task<IndexList> GetIndexes(MusicFolder folder, DateTime? modifiedSince) {
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
            response.ThrowOnErrors();
            return transform(new SubsonicResponse(response.Data));
        }

        private Task<IRestResponse<SubsonicRestResponse>> RunRequest(RestRequest request) {
            return Task.Run(() => _client.Execute<SubsonicRestResponse>(request));
        }
    }
}
