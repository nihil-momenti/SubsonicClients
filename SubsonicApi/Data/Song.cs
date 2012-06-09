using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Song : Child {
        internal Song()
            : base() {
        }

        internal Song(RestData.Song restData)
            : base(restData) {
        }
    }
}
