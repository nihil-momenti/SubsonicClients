using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    internal class SubsonicResponse {
        private const string OkStatus = "ok";
        private const string ErrorStatus = "failed";

        public string Status { get; set; }
        public string Version { get; set; }

        // only one of the following will be non-null depending on request.
        public SubsonicError Error { get; set; }
        public List<NowPlaying> NowPlaying { get; set; }
        public List<MusicFolder> MusicFolders { get; set; }
        public IndexList Indexes { get; set; }

        public bool? IsOk {
            get {
                if (string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase)) {
                    return true;
                }
                if (string.Equals(Status, ErrorStatus, StringComparison.OrdinalIgnoreCase)) {
                    return false;
                }
                return null;
            }
        }
    }
}
