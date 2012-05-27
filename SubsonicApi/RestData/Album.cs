using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class Album {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool IsDir { get; set; }
        public string CoverArt { get; set; }
        public int UserRating { get; set; }
        public double AverageRating { get; set; }
    }
}
