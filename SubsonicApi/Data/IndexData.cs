using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    internal class IndexCollection : List<ArtistData> {
        public string Name { get; set; }
    }
}
