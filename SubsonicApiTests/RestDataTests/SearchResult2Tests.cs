using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class SearchResult2Tests {
        [Test]
        public static void TestSearchResult2() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.4.0",
                SearchResult2 = new SearchResult2 {
                    Artists = new List<Artist> {
                        new Artist { Id = "1", Name = "ABBA" },
                    },
                    Albums = new List<Album> {
                        new Album {
                            Id = "11",
                            Parent = "1",
                            Title = "Arrival",
                            Artist = "ABBA",
                            IsDir = true,
                            CoverArt = "22",
                        },
                        new Album {
                            Id = "12",
                            Parent = "1",
                            Title = "Super Trouper",
                            Artist = "ABBA",
                            IsDir = true,
                            CoverArt = "23",
                        },
                    },
                    Songs = new List<Song> {
                        new Song {
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
            TestHelper.TestFile("searchResult2.xml", expectedResponse);
        }
    }
}
