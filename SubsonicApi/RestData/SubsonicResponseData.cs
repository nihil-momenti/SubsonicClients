using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    internal class SubsonicResponseData {
        private const string OkStatus = "ok";

        public string Status { get; set; }
        public string Version { get; set; }

        public SubsonicErrorData Error { get; set; }
        public List<NowPlayingData> NowPlaying { get; set; }
        public List<MusicFolderData> MusicFolders { get; set; }
        public IndexList Indexes { get; set; }

        public SubsonicResponseData() {
            NowPlaying = new List<NowPlayingData>();
            MusicFolders = new List<MusicFolderData>();
        }
         
        private bool? _isOk;
        public bool IsOk {
            get {
                _isOk = _isOk ?? string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase);
                return _isOk.Value;
            }
        }

        public override string ToString() {
            return new JsonSerializer().Serialize(this);
        }
    }
}
