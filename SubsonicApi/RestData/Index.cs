using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Index {
        public Index() {
            Artists = new List<Artist>();
        }

        public string Name { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
