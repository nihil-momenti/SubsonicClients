using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using RestSharp;

namespace SubsonicApi {
    public class SearchParameters {
        public string Query { get; private set; }
        public int? ArtistCount { get; set; }
        public int? ArtistOffset { get; set; }
        public int? AlbumCount { get; set; }
        public int? AlbumOffset { get; set; }
        public int? SongCount { get; set; }
        public int? SongOffset { get; set; }

        public SearchParameters(string query) {
            Contract.Requires<ArgumentNullException>(query != null, "Query cannot be null");
            Query = query;
        }

        internal IEnumerable<Parameter> ToEnumerable() {
            var parameters = new ParameterList();
            parameters["query"] = Query;
            parameters["artistCount"] = ArtistCount;
            parameters["artistOffset"] = ArtistOffset;
            parameters["albumCount"] = AlbumCount;
            parameters["albumOffset"] = AlbumOffset;
            parameters["songCount"] = SongCount;
            parameters["songOffset"] = SongOffset;
            return parameters;
        }
    }
}
