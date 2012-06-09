using System;
using System.Collections.Generic;
using System.Linq;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class SubsonicResponse {
        private const string OkStatus = "ok";

        internal SubsonicResponse() {
            Ok = false;
            Version = new SubsonicVersion();
            _nowPlayingList = new List<NowPlaying>();
            _shares = new List<Share>();
            _playlists = new List<Playlist>();
            SearchResult2 = new SearchResult2();
            User = new User();
        }

        internal SubsonicResponse(RestData.SubsonicResponse restData) {
            Ok = restData.IsOk;
            Version = SubsonicVersion.Parse(restData.Version);
            _nowPlayingList = restData.NowPlaying.Select(nowPlaying => new NowPlaying(nowPlaying)).ToList();
            _shares = restData.Shares.Select(share => new Share(share)).ToList();
            _playlists = restData.Playlists.Select(playlist => new Playlist(playlist)).ToList();
            SearchResult2 = new SearchResult2(restData.SearchResult2);
            User = new User(restData.User);
        }

        public bool Ok { get; internal set; }
        public SubsonicVersion Version { get; internal set; }
        internal List<NowPlaying> _nowPlayingList { get; set; }
        public IReadOnlyList<NowPlaying> NowPlayingList { get { return _nowPlayingList; } }
        internal List<MusicFolder> _musicFolders { get; set; }
        public IReadOnlyList<MusicFolder> MusicFolders { get { return _musicFolders; } }
        internal List<Playlist> _playlists { get; set; }
        public IReadOnlyList<Playlist> Playlists { get { return _playlists; } }
        public IndexList Indexes { get; internal set; }
        public MusicFolder Directory { get; internal set; }
        public SearchResult2 SearchResult2 { get; internal set; }
        public User User { get; internal set; }
        internal List<Share> _shares { get; set; }
        public IReadOnlyList<Share> Shares { get { return _shares; } }
    }
}
