using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class SearchResult2Tests {
        [Test]
        public static void TestRestSearchResult2() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.4.0",
                SearchResult2 = new SubsonicApi.RestData.SearchResult2 {
                    Artists = new List<SubsonicApi.RestData.Artist> {
                        new SubsonicApi.RestData.Artist { Id = "1", Name = "ABBA" },
                    },
                    Albums = new List<SubsonicApi.RestData.Album> {
                        new SubsonicApi.RestData.Album {
                            Id = "11",
                            Parent = "1",
                            Title = "Arrival",
                            Artist = "ABBA",
                            IsDir = true,
                            CoverArt = "22",
                        },
                        new SubsonicApi.RestData.Album {
                            Id = "12",
                            Parent = "1",
                            Title = "Super Trouper",
                            Artist = "ABBA",
                            IsDir = true,
                            CoverArt = "23",
                        },
                    },
                    Songs = new List<SubsonicApi.RestData.Song> {
                        new SubsonicApi.RestData.Song {
                            Id = "112",
                            Parent = "11",
                            Title = "Money, Money, Money",
                            IsDir = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = "25",
                            Size = 4910028,
                            ContentType = "audio/flac",
                            Suffix = "flac",
                            TranscodedContentType = "audio/mpeg",
                            TranscodedSuffix = "mp3",
                            Path = "ABBA/Arrival/Money, Money, Money.mp3",
                        },
                    },
                },
            };
            TestHelper.TestFileToRest("searchResult2.xml", expectedResponse);
        }

        [Test]
        public static void TestSearchResult2() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 4, Patch = 0 },
                SearchResult2 = new SubsonicApi.Data.SearchResult2 {
                    _artists = new List<SubsonicApi.Data.Artist> {
                        new SubsonicApi.Data.Artist { Id = new SubsonicApi.Data.SubsonicId("1"), Name = "ABBA" },
                    },
                    _albums = new List<SubsonicApi.Data.Album> {
                        new SubsonicApi.Data.Album {
                            Id = new SubsonicApi.Data.SubsonicId("11"),
                            Parent = new SubsonicApi.Data.SubsonicId("1"),
                            Title = "Arrival",
                            Artist = "ABBA",
                            IsDirectory = true,
                            CoverArt = new SubsonicApi.Data.SubsonicId("22"),
                        },
                        new SubsonicApi.Data.Album {
                            Id = new SubsonicApi.Data.SubsonicId("12"),
                            Parent = new SubsonicApi.Data.SubsonicId("1"),
                            Title = "Super Trouper",
                            Artist = "ABBA",
                            IsDirectory = true,
                            CoverArt = new SubsonicApi.Data.SubsonicId("23"),
                        },
                    },
                    _songs = new List<SubsonicApi.Data.Song> {
                        new SubsonicApi.Data.Song {
                            Id = new SubsonicApi.Data.SubsonicId("112"),
                            Parent = new SubsonicApi.Data.SubsonicId("11"),
                            Title = "Money, Money, Money",
                            IsDirectory = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = new SubsonicApi.Data.SubsonicId("25"),
                            Size = 4910028,
                            ContentType = "audio/flac",
                            Suffix = "flac",
                            TranscodedContentType = "audio/mpeg",
                            TranscodedSuffix = "mp3",
                            Path = "ABBA/Arrival/Money, Money, Money.mp3",
                        },
                    },
                },
            };
            TestHelper.TestFileToData("searchResult2.xml", expectedResponse);
        }
    }
}
