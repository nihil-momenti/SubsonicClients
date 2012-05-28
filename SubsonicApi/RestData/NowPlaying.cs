using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class NowPlaying : Child {
        public string UserName { get; set; }
        public int? MinutesAgo { get; set; }
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
}
