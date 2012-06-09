using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class SubsonicResponse {
        private const string OkStatus = "ok";

        public SubsonicResponse() {
            Error = new SubsonicError();
            NowPlaying = new List<NowPlaying>();
            MusicFolders = new List<MusicFolder>();
            Indexes = new IndexList();
            Directory = new Directory();
            SearchResult2 = new SearchResult2();
            Playlists = new List<Playlist>();
            User = new User();
            ChatMessages = new List<ChatMessage>();
            AlbumList = new List<Album>();
            RandomSongs = new List<Song>();
            Shares = new List<Share>();
            Podcasts = new List<Channel>();
            JukeboxPlaylist = new List<Entry>();
        }
         
        public string Status { get; set; }
        public string Version { get; set; }
        public SubsonicError Error { get; set; }
        public List<NowPlaying> NowPlaying { get; set; }
        public List<MusicFolder> MusicFolders { get; set; }
        public IndexList Indexes { get; set; }
        public Directory Directory { get; set; }
        public SearchResult2 SearchResult2 { get; set; }
        public List<Playlist> Playlists { get; set; }
        public User User { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        public List<Album> AlbumList { get; set; }
        public List<Song> RandomSongs { get; set; }
        public List<Share> Shares { get; set; }
        public List<Channel> Podcasts { get; set; }
        public List<Entry> JukeboxPlaylist { get; set; }
        public JukeboxStatus JukeboxStatus { get; set; }
        public Lyrics Lyrics { get; set; }

        private bool? _isOk;
        public bool IsOk {
            get {
                _isOk = _isOk ?? (_isOk = string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase));
                return _isOk.Value;
            }
        }
    }
}
