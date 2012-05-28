using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Playlist {
        public Playlist() {
            AllowedUsers = new List<AllowedUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Owner { get; set; }
        public bool? Public { get; set; }
        public int? SongCount { get; set; }
        public int? Duration { get; set; }
        public DateTime Created { get; set; }
        public List<AllowedUser> AllowedUsers { get; set; }
    }
}
