using System;
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
                            Year = "1978",
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
            TestFile("searchResult2.xml", expectedResponse);
        }

        [Test]
        public static void TestPlaylists() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.8.0",
                Playlists = new List<Playlist> {
                    new Playlist {
                        Id = "15",
                        Name = "Some random songs",
                        Comment = "Just something I tossed together",
                        Owner = "admin",
                        Public = false,
                        SongCount = 6,
                        Duration = 1391,
                        Created = new DateTime(2012, 4, 17, 19, 53, 44),
                        AllowedUsers = new List<AllowedUser> {
                            new AllowedUser { Value = "sindre" },
                            new AllowedUser { Value = "john" },
                        },
                    },
                    new Playlist {
                        Id = "16",
                        Name = "More random songs",
                        Comment = "No comment",
                        Owner = "admin",
                        Public = true,
                        SongCount = 5,
                        Duration = 1018,
                        Created = new DateTime(2012, 4, 17, 19, 55, 49),
                    },
                },
            };
            TestFile("playlists.xml", expectedResponse);
        }

        [Test]
        public static void TestUser() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.7.0",
                User = new User {
                    Username = "sindre",
                    Email = "sindre@activeobjects.no",
                    ScrobblingEnabled = true,
                    AdminRole = false,
                    SettingsRole = true,
                    DownloadRole = true,
                    UploadRole = false,
                    PlaylistRole = true,
                    CoverArtRole = true,
                    CommentRole = true,
                    PodcastRole = true,
                    StreamRole = true,
                    JukeboxRole = true,
                    ShareRole = false,
                },
            };
            TestFile("user.xml", expectedResponse);
        }

        [Test]
        public static void TestChatMessages() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.2.0",
                ChatMessages = new List<ChatMessage> {
                    new ChatMessage {
                        Username = "sindre",
                        Time = "1269771845310",
                        Message = "Sindre was here",
                    },
                    new ChatMessage {
                        Username = "ben",
                        Time = "1269771842504",
                        Message = "Ben too",
                    },
                },
            };
            TestFile("chatMessages.xml", expectedResponse);
        }

        [Test]
        public static void TestAlbumList() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.6.0",
                AlbumList = new List<Album> {
                    new Album {
                        Id = "11",
                        Parent = "1",
                        Title = "Arrival",
                        Artist = "ABBA",
                        IsDir = true,
                        CoverArt = "22",
                        UserRating = 4,
                        AverageRating = 4.5,
                    },
                    new Album {
                        Id = "12",
                        Parent = "1",
                        Title = "Super Trouper",
                        Artist = "ABBA",
                        IsDir = true,
                        CoverArt = "23",
                        AverageRating = 4.4,
                    },
                },
            };
            TestFile("albumList.xml", expectedResponse);
        }

        [Test]
        public static void TestRandomSongs() {
            var expectedResponse = new SubsonicRestResponse {
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
                            Year = "1978",
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
                            Year = "1978",
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
            TestFile("randomSongs.xml", expectedResponse);
        }
    }
}
