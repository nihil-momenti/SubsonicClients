using System.Collections.Generic;
using System.Linq;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class SearchResult2 {
        internal SearchResult2() {
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _songs = new List<Song>();
        }

        internal SearchResult2(RestData.SearchResult2 restData) {
            _artists = restData.Artists.Select(artist => new Artist(artist)).ToList();
            _albums = restData.Albums.Select(album => new Album(album)).ToList();
            _songs = restData.Songs.Select(song => new Song(song)).ToList();
        }

        internal List<Artist> _artists { get; set; }
        public IReadOnlyList<Artist> Artists { get { return _artists; } }
        internal List<Album> _albums { get; set; }
        public IReadOnlyList<Album> Albums { get { return _albums; } }
        internal List<Song> _songs { get; set; }
        public IReadOnlyList<Song> Songs { get { return _songs; } }
    }
}
