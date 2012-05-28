using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class User {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool? ScrobblingEnabled { get; set; }
        public bool? AdminRole { get; set; }
        public bool? SettingsRole { get; set; }
        public bool? DownloadRole { get; set; }
        public bool? UploadRole { get; set; }
        public bool? PlaylistRole { get; set; }
        public bool? CoverArtRole { get; set; }
        public bool? CommentRole { get; set; }
        public bool? PodcastRole { get; set; }
        public bool? StreamRole { get; set; }
        public bool? JukeboxRole { get; set; }
        public bool? ShareRole { get; set; }
    }
}
