using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Playlist {
        internal Playlist() {
            Id = new SubsonicId("");
            Name = "";
            Comment = "";
            Owner = "";
            Public = false;
            SongCount = 0;
            Duration = 0;
            Created = new DateTime();
            _allowedUsers = new List<string>();
        }

        internal Playlist(RestData.Playlist playlist) {
            Id = new SubsonicId(playlist.Id ?? "");
            Name = playlist.Name ?? "";
            Comment = playlist.Comment ?? "";
            Owner = playlist.Owner ?? "";
            Public = playlist.Public ?? false;
            SongCount = playlist.SongCount ?? 0;
            Duration = playlist.Duration ?? 0;
            Created = playlist.Created;
            _allowedUsers = playlist.AllowedUsers.Select(allowedUser => allowedUser.Value).ToList();
        }

        public SubsonicId Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Owner { get; set; }
        public bool Public { get; set; }
        public int SongCount { get; set; }
        public int Duration { get; set; }
        public DateTime Created { get; set; }
        internal List<string> _allowedUsers { get; set; }
        public IReadOnlyList<string> AllowedUsers { get { return _allowedUsers; } }
    }
}
