using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class IndexesTests {
        [Test]
        public static void TestIndexes() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.1.1",
                Indexes = new IndexList {
                    LastModified = "237462836472342",
                    Shortcuts = new List<Shortcut> {
                        new Shortcut { Id = "11", Name = "Audio books" },
                        new Shortcut { Id = "10", Name = "Podcasts" },
                    },
                    Indexes = new List<Index> {
                        new Index {
                            Name = "A",
                            Artists = new List<Artist> {
                                new Artist { Id = "1", Name = "ABBA" },
                                new Artist { Id = "2", Name = "Alanis Morisette" },
                                new Artist { Id = "3", Name = "Alphaville" },
                            }
                        },
                        new Index {
                            Name = "B",
                            Artists = new List<Artist> {
                                new Artist { Id = "4", Name = "Bob Dylan" },
                            }
                        },
                    },
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
            TestHelper.TestFile("indexes.xml", expectedResponse);
        }
    }
}
