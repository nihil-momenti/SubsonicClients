using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class NowPlaying : Child {
        internal NowPlaying()
            : base() {
            UserName = "";
            MinutesAgo = -1;
            PlayerId = new SubsonicId("");
            PlayerName = "";
        }

        internal NowPlaying(RestData.NowPlaying restData)
            : base(restData) {
            UserName = restData.UserName ?? "";
            MinutesAgo = restData.MinutesAgo ?? -1;
            PlayerId = new SubsonicId(restData.PlayerId ?? "");
            PlayerName = restData.PlayerName ?? "";
        }

        public string UserName { get; internal set; }
        public int MinutesAgo { get; internal set; }
        public SubsonicId PlayerId { get; internal set; }
        public string PlayerName { get; internal set; }
    }
}
