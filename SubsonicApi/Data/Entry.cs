using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Entry : Child {
        public Entry()
            : base() {
        }
        public Entry(RestData.Entry entry)
            : base(entry) {
        }
    }
}
