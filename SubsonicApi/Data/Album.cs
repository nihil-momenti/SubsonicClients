using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Album {
        internal Album() {
            Id = new SubsonicId("");
            Parent = new SubsonicId("");
            Title = "";
            Artist = "";
            IsDirectory = false;
            CoverArt = new SubsonicId("");
            UserRating = null;
            AverageRating = 0.0;
        }

        internal Album(RestData.Album restData) {
            Id = new SubsonicId(restData.Id ?? "");
            Parent = new SubsonicId(restData.Parent ?? "");
            Title = restData.Title ?? "";
            Artist = restData.Artist ?? "";
            IsDirectory = restData.IsDir ?? false;
            CoverArt = new SubsonicId(restData.CoverArt ?? "");
            UserRating = restData.UserRating;
            AverageRating = restData.AverageRating ?? 0.0;
        }

        public SubsonicId Id { get; set; }
        public SubsonicId Parent { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool IsDirectory { get; set; }
        public SubsonicId CoverArt { get; set; }
        public int? UserRating { get; set; }
        public double AverageRating { get; set; }
    }
}
