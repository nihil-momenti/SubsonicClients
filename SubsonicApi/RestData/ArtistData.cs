using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    internal class ArtistData {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
