using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Nemo157.Common;
using RestSharp;
using SubsonicApi.Data;

namespace SubsonicApi {
    public class SubsonicClient {
        private readonly RestClient _client;

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
            return await DoSimpleRequest("rest/getNowPlaying.view", response => response.NowPlayingList);
        }

        public async Task<IndexList> GetIndexes() {
            return await GetIndexes(null, null);
        }

        public async Task<IndexList> GetIndexes(SubsonicId id) {
            return await GetIndexes(id, null);
        }

        public async Task<IndexList> GetIndexes(DateTime? modifiedSince) {
            return await GetIndexes(null, modifiedSince);
        }

        public async Task<IndexList> GetIndexes(SubsonicId id, DateTime? modifiedSince) {
            var parameters = new ParameterList();
            parameters["musicFolderId"] = id.Id;
            // TODO: find out what format this date is supposed to be in
            parameters["ifModifiedSince"] = modifiedSince.AndAnd().ToString("yyyyMMddTHHmmss");
            return await DoSimpleRequest("rest/getIndexes.view", parameters, response => response.Indexes);
        }

        public async Task<MusicFolder> GetMusicDirectory(SubsonicId id) {
            var parameters = new ParameterList();
            parameters["id"] = id.Id;
            return await DoSimpleRequest("rest/getMusicDirectory.view", parameters, response => response.Directory);
        }

        public async Task<SearchResult2> Search2(SearchParameters parameters) {
            return await DoSimpleRequest("rest/search2.view", parameters.ToEnumerable(), response => response.SearchResult2);
        }

        public async Task<IReadOnlyList<Playlist>> GetPlaylists() {
            return await DoSimpleRequest("rest/getPlaylists.view", response => response.Playlists);
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

        private Task<IRestResponse<RestData.SubsonicResponse>> RunRequest(RestRequest request) {
            return Task.Run(() => _client.Execute<RestData.SubsonicResponse>(request));
        }
    }
}
