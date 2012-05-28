using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class IndexList {
        public IndexList() {
            Shortcuts = new List<Shortcut>();
            Indexes = new List<Index>();
            Children = new List<Child>();
        }
        public string LastModified { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
        public List<Index> Indexes { get; set; }
        public List<Child> Children { get; set; }
    }
}
