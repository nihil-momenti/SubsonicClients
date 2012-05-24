using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi.Data {
    internal class IndexCollection : List<ArtistData> {
        public string Name { get; set; }
    }
}
