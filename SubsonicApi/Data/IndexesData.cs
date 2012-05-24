using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi.Data {
    internal class IndexList {
        public string LastModified { get; set; }
        public List<ShortcutData> Shortcuts { get; set; }
        public List<IndexCollection> Indexes { get; set; }
        public List<ChildData> Children { get; set; }
    }
}
