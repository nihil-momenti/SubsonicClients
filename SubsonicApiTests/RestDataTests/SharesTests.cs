using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class SharesTests {
        [Test]
        public static void TestRestShares() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.6.0",
                Shares = new List<SubsonicApi.RestData.Share> {
                    new SubsonicApi.RestData.Share {
                        Id = "1",
                        Url = new Uri("http://sindre.subsonic.org/share/sKoYn"),
                        Description = "Check this out",
                        UserName = "sindre",
                        Created = new DateTime(2011, 6, 4, 12, 34, 56),
                        LastVisited = new DateTime(2011, 6, 4, 13, 14, 15),
                        Expires = new DateTime(2013, 6, 4),
                        VisitCount = 0,
                        Entries = new List<SubsonicApi.RestData.Entry> {
                            new SubsonicApi.RestData.Entry {
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
                            new SubsonicApi.RestData.Entry {
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
            TestHelper.TestFileToRest("shares.xml", expectedResponse);
        }

        [Test]
        public static void TestShares() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 6, Patch = 0 },
                _shares = new List<SubsonicApi.Data.Share> {
                    new SubsonicApi.Data.Share {
                        Id = new SubsonicApi.Data.SubsonicId("1"),
                        Url = new Uri("http://sindre.subsonic.org/share/sKoYn"),
                        Description = "Check this out",
                        UserName = "sindre",
                        Created = new DateTime(2011, 6, 4, 12, 34, 56),
                        LastVisited = new DateTime(2011, 6, 4, 13, 14, 15),
                        Expires = new DateTime(2013, 6, 4),
                        VisitCount = 0,
                        _entries = new List<SubsonicApi.Data.Entry> {
                            new SubsonicApi.Data.Entry {
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
                                Duration = 146,
                                Bitrate = 128,
                                Path = "ABBA/Arrival/Dancing Queen.mp3",
                            },
                            new SubsonicApi.Data.Entry {
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
                                Duration = 208,
                                Bitrate = 128,
                                Path = "ABBA/Arrival/Money, Money, Money.mp3",
                            },
                        },
                    },
                },
            };
            TestHelper.TestFileToData("shares.xml", expectedResponse);
        }
    }
}
