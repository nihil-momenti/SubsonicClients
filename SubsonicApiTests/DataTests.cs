using System.Collections.Generic;
using Nemo157.Common;
using NUnit.Framework;
using RestSharp.Deserializers;
using SubsonicApi.RestData;

namespace SubsonicApiTests {
    [TestFixture]
    public static class DataTests {
        internal static void TestFile(string dataFile, SubsonicRestResponse expectedResponse) {
            using (var response = SampleLoader.CreateResponse(dataFile)) {
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicRestResponse>(response.Result);
                Assert.That(subsonicResponse, Iss.EqualByPropertyTo(expectedResponse));
            }
        }

        [Test]
        public static void TestPing() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.1.1",
            };
            TestFile("ping.xml", expectedResponse);
        }

        [Test]
        public static void TestMusicFolders() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.1.1",
                MusicFolders = new List<MusicFolder> {
                    new MusicFolder { Id = "1", Name = "Music"},
                    new MusicFolder { Id = "2", Name = "Movies"},
                    new MusicFolder { Id = "3", Name = "Incoming"},
                },
            };
            TestFile("musicFolders.xml", expectedResponse);
        }

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
            TestFile("nowPlaying.xml", expectedResponse);
        }

        [Test]
        public static void TestIndexes() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.1.1",
                Indexes = new Indexes {
                    LastModified = "237462836472342",
                    Shortcuts = new List<Shortcut> {
                        new Shortcut { Id = "11", Name = "Audio books" },
                        new Shortcut { Id = "10", Name = "Podcasts" },
                    },
                    Indices = new List<Index> {
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
            TestFile("indexes.xml", expectedResponse);
        }

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
            TestFile("musicDirectory.xml", expectedResponse);
        }
    }
}
