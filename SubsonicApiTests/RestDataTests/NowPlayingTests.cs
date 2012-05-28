using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class NowPlayingTests {
        [Test]
        public static void TestNowPlaying() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.4.0",
                NowPlaying = new List<NowPlaying> {
                        new NowPlaying {
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
                        new NowPlaying {
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
            TestHelper.TestFile("nowPlaying.xml", expectedResponse);
        }

    }
}
