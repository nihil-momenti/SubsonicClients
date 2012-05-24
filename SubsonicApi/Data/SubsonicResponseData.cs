using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi.Data {
    internal class SubsonicResponseData : IEquatable<SubsonicResponseData> {
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
         
        public override bool Equals(object obj) {
            return Equals(obj as SubsonicResponseData);
        }

        public bool Equals(SubsonicResponseData other) {
            if (other == null) {
                return false;
            }

            return Error.MaybeEquals(other.Error)
                && NowPlaying.ListEquals(other.NowPlaying)
                && MusicFolders.ListEquals(other.MusicFolders)
                && Indexes.MaybeEquals(other.Indexes);
        }

        public override int GetHashCode() {
            return Error.MaybeGetHashCode() ^ NowPlaying.GetListHashCode() ^ MusicFolders.GetListHashCode() ^ Indexes.MaybeGetHashCode();
        }

        private bool? _isOk;
        public bool IsOk {
            get {
                _isOk = _isOk ?? string.Equals(Status, OkStatus, StringComparison.OrdinalIgnoreCase);
                return _isOk.Value;
            }
        }
    }
}
