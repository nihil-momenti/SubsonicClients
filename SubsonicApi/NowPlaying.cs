using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class NowPlaying {
        public string UserName { get; set; }
        public int MinutesAgo { get; set; }
        public string PlayerId { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Title { get; set; }
        public bool IsDir { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Track { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string CoverArt { get; set; }
        public int Size { get; set; }
        public string ContentType { get; set; }
        public string Suffix { get; set; }
        public string TranscodedContentType { get; set; }
        public string TranscodedSuffix { get; set; }
        public string Path { get; set; }
    }
}
