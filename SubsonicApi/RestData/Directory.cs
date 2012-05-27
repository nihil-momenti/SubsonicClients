using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Directory {
        public Directory() {
            Children = new List<Child>();
        }

        public string Id { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
    }
}
