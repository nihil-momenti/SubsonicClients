using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Lyrics {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
