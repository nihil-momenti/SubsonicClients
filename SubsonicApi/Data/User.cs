using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class User {
        internal User() {
            UserName = "";
            Email = "";
            ScrobblingEnabled = false;
            AdminRole = false;
            SettingsRole = false;
            DownloadRole = false;
            UploadRole = false;
            PlaylistRole = false;
            CoverArtRole = false;
            CommentRole = false;
            PodcastRole = false;
            StreamRole = false;
            JukeboxRole = false;
            ShareRole = false;
        }

        internal User(RestData.User restData) {
            UserName = restData.UserName ?? "";
            Email = restData.Email ?? "";
            ScrobblingEnabled = restData.ScrobblingEnabled ?? false;
            AdminRole = restData.AdminRole ?? false;
            SettingsRole = restData.SettingsRole ?? false;
            DownloadRole = restData.DownloadRole ?? false;
            UploadRole = restData.UploadRole ?? false;
            PlaylistRole = restData.PlaylistRole ?? false;
            CoverArtRole = restData.CoverArtRole ?? false;
            CommentRole = restData.CommentRole ?? false;
            PodcastRole = restData.PodcastRole ?? false;
            StreamRole = restData.StreamRole ?? false;
            JukeboxRole = restData.JukeboxRole ?? false;
            ShareRole = restData.ShareRole ?? false;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public bool ScrobblingEnabled { get; set; }
        public bool AdminRole { get; set; }
        public bool SettingsRole { get; set; }
        public bool DownloadRole { get; set; }
        public bool UploadRole { get; set; }
        public bool PlaylistRole { get; set; }
        public bool CoverArtRole { get; set; }
        public bool CommentRole { get; set; }
        public bool PodcastRole { get; set; }
        public bool StreamRole { get; set; }
        public bool JukeboxRole { get; set; }
        public bool ShareRole { get; set; }
    }
}
