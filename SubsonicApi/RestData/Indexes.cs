using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Indexes {
        public Indexes() {
            Shortcuts = new List<Shortcut>();
            Indices = new List<Index>();
            Children = new List<Child>();
        }
        public string LastModified { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
        public List<Index> Indices { get; set; }
        public List<Child> Children { get; set; }
    }
}
