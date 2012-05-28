using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Channel {
        public Channel() {
            Episodes = new List<Episode>();
        }

        public string Id { get; set; }
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
