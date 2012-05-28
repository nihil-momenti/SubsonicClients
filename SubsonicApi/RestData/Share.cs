using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Share {
        public Share() {
            Entries = new List<Entry>();
        }

        public string Id { get; set; }
        public Uri Url { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastVisited { get; set; }
        public DateTime Expires { get; set; }
        public int? VisitCount { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
