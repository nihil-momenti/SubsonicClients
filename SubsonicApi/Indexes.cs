using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class IndexList {
        public string LastModified;
        public List<Shortcut> Shortcuts { get; set; }
        public List<Index> Indexes { get; set; }
        public List<Child> Children { get; set; }
    }
}
