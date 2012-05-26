using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    internal class IndexList {
        public string LastModified { get; set; }
        public List<ShortcutData> Shortcuts { get; set; }
        public List<IndexCollection> Indexes { get; set; }
        public List<ChildData> Children { get; set; }
    }
}
