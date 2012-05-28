using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class MusicDirectoryTests {
        [Test]
        public static void TestMusicDirectory() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.4.0",
                Directory = new Directory {
                    Id = "11",
                    Parent = "1",
                    Name = "Arrival",
                    Children = new List<Child> {
                        new Child {
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
                        new Child {
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
                },
            };
            TestHelper.TestFile("musicDirectory.xml", expectedResponse);
        }
    }
}
