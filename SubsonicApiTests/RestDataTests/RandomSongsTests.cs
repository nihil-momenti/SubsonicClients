using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class RandomSongsTests {
        [Test]
        public static void TestRandomSongs() {
            var expectedResponse = new SubsonicResponse {
                Status = "ok",
                Version = "1.4.0",
                RandomSongs = new List<Song> {
                        new Song {
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
                            Duration = 146,
                            BitRate = 128,
                            Path = "ABBA/Arrival/Dancing Queen.mp3",
                        },
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
                            Duration = 208,
                            BitRate = 128,
                            Path = "ABBA/Arrival/Money, Money, Money.mp3",
                        },
                },
            };
            TestHelper.TestFileToRest("randomSongs.xml", expectedResponse);
        }
    }
}
