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
        }
         
        public string Status { get; set; }
        public string Version { get; set; }
        public SubsonicError Error { get; set; }
        public List<NowPlaying> NowPlaying { get; set; }
        public List<MusicFolder> MusicFolders { get; set; }
        public Indexes Indexes { get; set; }
        public Directory Directory { get; set; }

        private bool? _isOk;
        public bool IsOk {
            get {
                _isOk = _isOk ?? (_isOk = string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase));
                return _isOk.Value;
            }
        }
    }
}
