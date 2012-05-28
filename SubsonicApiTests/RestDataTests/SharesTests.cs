using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class SharesTests {
        [Test]
        public static void TestShares() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.6.0",
                Shares = new List<Share> {
                    new Share {
                        Id = "1",
                        Url = new Uri("http://sindre.subsonic.org/share/sKoYn"),
                        Description = "Check this out",
                        UserName = "sindre",
                        Created = new DateTime(2011, 6, 4, 12, 34, 56),
                        LastVisited = new DateTime(2011, 6, 4, 13, 14, 15),
                        Expires = new DateTime(2013, 6, 4),
                        VisitCount = 0,
                        Entries = new List<Entry> {
                            new Entry {
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
                            new Entry {
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
                },
            };
            TestHelper.TestFile("shares.xml", expectedResponse);
        }
    }
}
