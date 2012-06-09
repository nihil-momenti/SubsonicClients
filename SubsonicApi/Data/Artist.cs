using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Artist {
        internal Artist() {
            Id = new SubsonicId("");
            Name = "";
        }

        internal Artist(RestData.Artist restData) {
            Id = new SubsonicId(restData.Id ?? "");
            Name = restData.Name ?? "";
        }

        public SubsonicId Id { get; set; }
        public string Name { get; set; }
    }
}
