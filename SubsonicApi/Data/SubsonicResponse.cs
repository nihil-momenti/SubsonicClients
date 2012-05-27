using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubsonicApi.RestData;

namespace SubsonicApi {
    public class SubsonicResponse {
        private const string OkStatus = "ok";

        public bool Ok { get; set; }
        public IReadOnlyList<NowPlaying> NowPlaying { get; set; }
        public IReadOnlyList<MusicFolder> MusicFolders { get; set; }
        public IndexList Indexes { get; set; }

        internal SubsonicResponse(SubsonicRestResponse data) {
            Ok = data.IsOk;
        }
    }
}
