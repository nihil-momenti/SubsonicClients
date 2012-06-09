using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Share {
        internal Share() {
            Id = new SubsonicId("");
            Url = null;
            Description = "";
            UserName = "";
            Created = new DateTime();
            LastVisited = new DateTime();
            Expires = new DateTime();
            VisitCount = 0;
            _entries = new List<Entry>();
        }

        internal Share(RestData.Share restData) {
            Id = new SubsonicId(restData.Id ?? "");
            Url = restData.Url;
            Description = restData.Description ?? "";
            UserName = restData.UserName ?? "";
            Created = restData.Created;
            LastVisited = restData.LastVisited;
            Expires = restData.Expires;
            VisitCount = restData.VisitCount ?? 0;
            _entries = restData.Entries.Select(entry => new Entry(entry)).ToList();
        }

        public SubsonicId Id { get; set; }
        public Uri Url { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastVisited { get; set; }
        public DateTime Expires { get; set; }
        public int VisitCount { get; set; }
        internal List<Entry> _entries { get; set; }
        public IReadOnlyList<Entry> Entries { get { return _entries; } }
    }
}
