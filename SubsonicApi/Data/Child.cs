using System;
using System.Diagnostics.Contracts;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class Child {
        internal Child() {
            Id = new SubsonicId("");
            Parent = new SubsonicId("");
            Title = "";
            IsDirectory = false;
            Album = "";
            Artist = "";
            Track = "";
            Year = -1;
            Genre = "";
            CoverArt = new SubsonicId("");
            Size = -1;
            ContentType = "";
            Suffix = "";
            TranscodedContentType = "";
            TranscodedSuffix = "";
            Duration = -1;
            Bitrate = -1;
            Path = "";
        }

        internal Child(RestData.Child restData) {
            Id = new SubsonicId(restData.Id ?? "");
            Parent = new SubsonicId(restData.Parent ?? "");
            Title = restData.Title ?? "";
            IsDirectory = restData.IsDir ?? false;
            Album = restData.Album ?? "";
            Artist = restData.Artist ?? "";
            Track = restData.Track ?? "";
            Year = restData.Year ?? -1;
            Genre = restData.Genre ?? "";
            CoverArt = new SubsonicId(restData.CoverArt ?? "");
            Size = restData.Size ?? -1;
            ContentType = restData.ContentType ?? "";
            Suffix = restData.Suffix ?? "";
            TranscodedContentType = restData.TranscodedContentType ?? "";
            TranscodedSuffix = restData.TranscodedSuffix ?? "";
            Duration = restData.Duration ?? -1;
            Bitrate = restData.BitRate ?? -1;
            Path = restData.Path ?? "";
        }

        public SubsonicId Id { get; internal set; }
        public SubsonicId Parent { get; internal set; }
        public string Title { get; internal set; }
        public bool IsDirectory { get; internal set; }
        public string Album { get; internal set; }
        public string Artist { get; internal set; }
        public string Track { get; internal set; }
        public int Year { get; internal set; }
        public string Genre { get; internal set; }
        public SubsonicId CoverArt { get; internal set; }
        public int Size { get; internal set; }
        public string ContentType { get; internal set; }
        public string Suffix { get; internal set; }
        public string TranscodedContentType { get; internal set; }
        public string TranscodedSuffix { get; internal set; }
        public int Duration { get; internal set; }
        public int Bitrate { get; internal set; }
        public string Path { get; internal set; }
    }
}
