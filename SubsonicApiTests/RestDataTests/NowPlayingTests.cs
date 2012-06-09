using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class NowPlayingTests {
        [Test]
        public static void TestRestNowPlaying() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.4.0",
                NowPlaying = new List<SubsonicApi.RestData.NowPlaying> {
                        new SubsonicApi.RestData.NowPlaying {
                            UserName = "sindre",
                            MinutesAgo = 12,
                            PlayerId = "2",
                            Id = "111",
                            Parent = "11",
                            Title = "Dancing Queen",
                            IsDir = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = "24",
                            Size = 8421341,
                            ContentType = "audio/mpeg",
                            Suffix = "mp3",
                            Path = "ABBA/Arrival/Dancing Queen.mp3",
                        },
                        new SubsonicApi.RestData.NowPlaying {
                            UserName = "bente",
                            MinutesAgo = 1,
                            PlayerId = "4",
                            PlayerName = "Kitchen",
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
            };
            TestHelper.TestFileToRest("nowPlaying.xml", expectedResponse);
        }

        [Test]
        public static void TestNowPlaying() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 4, Patch = 0 },
                _nowPlayingList = new List<SubsonicApi.Data.NowPlaying> {
                        new SubsonicApi.Data.NowPlaying {
                            UserName = "sindre",
                            MinutesAgo = 12,
                            PlayerId = new SubsonicApi.Data.SubsonicId("2"),
                            Id = new SubsonicApi.Data.SubsonicId("111"),
                            Parent = new SubsonicApi.Data.SubsonicId("11"),
                            Title = "Dancing Queen",
                            IsDirectory = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = new SubsonicApi.Data.SubsonicId("24"),
                            Size = 8421341,
                            ContentType = "audio/mpeg",
                            Suffix = "mp3",
                            Path = "ABBA/Arrival/Dancing Queen.mp3",
                        },
                        new SubsonicApi.Data.NowPlaying {
                            UserName = "bente",
                            MinutesAgo = 1,
                            PlayerId = new SubsonicApi.Data.SubsonicId("4"),
                            PlayerName = "Kitchen",
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
            };
            TestHelper.TestFileToData("nowPlaying.xml", expectedResponse);
        }
    }
}
