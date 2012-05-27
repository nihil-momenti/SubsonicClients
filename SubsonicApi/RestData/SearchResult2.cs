using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class SearchResult2 {
        public SearchResult2() {
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
