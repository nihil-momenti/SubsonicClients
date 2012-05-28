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
                    UserName = "sindre",
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
                        UserName = "sindre",
                        Time = "1269771845310",
                        Message = "Sindre was here",
                    },
                    new ChatMessage {
                        UserName = "ben",
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
            TestFile("randomSongs.xml", expectedResponse);
        }

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
            TestFile("shares.xml", expectedResponse);
        }

        [Test]
        public static void TestPodcasts() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.6.0",
                Podcasts = new List<Channel> {
                    new Channel {
                        Id = "1",
                        Url = new Uri("http://downloads.bbc.co.uk/podcasts/fivelive/drkarl/rss.xml"),
                        Title = "Dr Karl and the Naked Scientist",
                        Description = "Dr Chris Smith aka The Naked Scientist with the latest news from the world of science and Dr Karl answers listeners' science questions.",
                        Status = "completed",
                        Episodes = new List<Episode> {
                            new Episode {
                                Id = "34",
                                StreamId = "523",
                                Title = "Scorpions have re-evolved eyes",
                                Description = "This week Dr Chris fills us in on the UK's largest free science festival, plus all this week's big scientific discoveries.",
                                PublishDate = new DateTime(2011, 2, 3, 14, 46, 43),
                                Status = "completed",
                                Parent = "11",
                                IsDir = false,
                                Year = 2011,
                                Genre = "Podcast",
                                CoverArt = "24",
                                Size = 78421341,
                                ContentType = "audio/mpeg",
                                Suffix = "mp3",
                                Duration = 3146,
                                BitRate = 128,
                                Path = "Podcast/drkarl/20110203.mp3",
                            },
                            new Episode {
                                Id = "35",
                                StreamId = "524",
                                Title = "Scar tissue and snake venom treatment",
                                Description = "This week Dr Karl tells the gruesome tale of a surgeon who operated on himself.",
                                PublishDate = new DateTime(2011, 9, 3, 16, 47, 52),
                                Status = "completed",
                                Parent = "11",
                                IsDir = false,
                                Year = 2011,
                                Genre = "Podcast",
                                CoverArt = "27",
                                Size = 45624671,
                                ContentType = "audio/mpeg",
                                Suffix = "mp3",
                                Duration = 3099,
                                BitRate = 128,
                                Path = "Podcast/drkarl/20110903.mp3"
                            },
                        },
                    },
                    new Channel {
                        Id = "2",
                        Url = new Uri("http://podkast.nrk.no/program/herreavdelingen.rss"),
                        Title = "NRK P1 - Herreavdelingen",
                        Description = "Et program der herrene Yan Friis og Finn Bjelke møtes og musikk nytes.",
                        Status = "completed",
                    },
                    new Channel {
                        Id = "3",
                        Url = new Uri("http://foo.bar.com/xyz.rss"),
                        Status = "error",
                        ErrorMessage = "Not found.",
                    },
                },
            };
            TestFile("podcasts.xml", expectedResponse);
        }

        [Test]
        public static void TestJukeboxPlaylist() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.4.0",
                JukeboxPlaylist = new List<Entry> {
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
                        Duration = 345,
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
                        Duration = 240,
                        Path = "ABBA/Arrival/Money, Money, Money.mp3",
                    },
                },
            };
            TestFile("jukeboxPlaylist.xml", expectedResponse);
        }

        [Test]
        public static void TestJukeboxStatus() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.7.0",
                JukeboxStatus = new JukeboxStatus {
                    CurrentIndex = 7,
                    Playing = true,
                    Gain = 0.9,
                    Position = 67,
                }
            };
            TestFile("jukeboxStatus.xml", expectedResponse);
        }

        [Test]
        public static void TestLyrics() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.2.0",
                Lyrics = new Lyrics {
                    Artist = "Muse",
                    Title = "Hysteria",
                    Value = @"
    It's bugging me
    Grating me
    And twisting me around
    Yeah I'm endlessly
    Caving in
    And turning inside out

    Cause I want it now
    I want it now
    Give me your heart and your soul
    And I'm breaking out
    I'm breaking out
    That's when she'll lose control

    It's holding me
    Morphing me
    And forcing me to strive
    To be endlessly
    Cold within
    And dreaming I'm alive

    Cause I want it now
    I want it now
    Give me your heart and your soul
    I'm not breaking down
    I'm breaking out
    That's when she'll lose control

    And I want you now
    I want you now
    I'll feel my heart implode
    And I'm breaking out
    Escaping now
    Feeling my faith erode
  ".Replace("\r", ""),
                },
            };
            TestFile("lyrics.xml", expectedResponse);
        }
    }
}