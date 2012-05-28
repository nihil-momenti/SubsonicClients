using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class JukeboxStatus {
        public int? CurrentIndex { get; set; }
        public bool? Playing { get; set; }
        public double? Gain { get; set; }
        public int? Position { get; set; }
    }
}
