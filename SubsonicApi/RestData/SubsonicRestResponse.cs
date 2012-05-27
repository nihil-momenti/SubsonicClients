using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class SubsonicRestResponse {
        private const string OkStatus = "ok";

        public SubsonicRestResponse() {
            NowPlaying = new List<NowPlaying>();
            MusicFolders = new List<MusicFolder>();
            Playlists = new List<Playlist>();
            ChatMessages = new List<ChatMessage>();
            AlbumList = new List<Album>();
            RandomSongs = new List<Song>();
        }
         
        public string Status { get; set; }
        public string Version { get; set; }
        public SubsonicError Error { get; set; }
        public List<NowPlaying> NowPlaying { get; set; }
        public List<MusicFolder> MusicFolders { get; set; }
        public Indexes Indexes { get; set; }
        public Directory Directory { get; set; }
        public SearchResult2 SearchResult2 { get; set; }
        public List<Playlist> Playlists { get; set; }
        public User User { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        public List<Album> AlbumList { get; set; }
        public List<Song> RandomSongs { get; set; }

        private bool? _isOk;
        public bool IsOk {
            get {
                _isOk = _isOk ?? (_isOk = string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase));
                return _isOk.Value;
            }
        }
    }
}
