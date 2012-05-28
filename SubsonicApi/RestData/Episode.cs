using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Episode : Child {
        public string StreamId { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string Status { get; set; }
    }
}
