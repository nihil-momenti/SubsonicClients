using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class PlaylistsTest {
        [Test]
        public static void TestRestPlaylists() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.8.0",
                Playlists = new List<SubsonicApi.RestData.Playlist> {
                    new SubsonicApi.RestData.Playlist {
                        Id = "15",
                        Name = "Some random songs",
                        Comment = "Just something I tossed together",
                        Owner = "admin",
                        Public = false,
                        SongCount = 6,
                        Duration = 1391,
                        Created = new DateTime(2012, 4, 17, 19, 53, 44),
                        AllowedUsers = new List<SubsonicApi.RestData.AllowedUser> {
                            new SubsonicApi.RestData.AllowedUser { Value = "sindre" },
                            new SubsonicApi.RestData.AllowedUser { Value = "john" },
                        },
                    },
                    new SubsonicApi.RestData.Playlist {
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
            TestHelper.TestFileToRest("playlists.xml", expectedResponse);
        }

        [Test]
        public static void TestPlaylists() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 8, Patch = 0 },
                _playlists = new List<SubsonicApi.Data.Playlist> {
                    new SubsonicApi.Data.Playlist {
                        Id = new SubsonicApi.Data.SubsonicId("15"),
                        Name = "Some random songs",
                        Comment = "Just something I tossed together",
                        Owner = "admin",
                        Public = false,
                        SongCount = 6,
                        Duration = 1391,
                        Created = new DateTime(2012, 4, 17, 19, 53, 44),
                        _allowedUsers = new List<string> {
                            "sindre",
                            "john",
                        },
                    },
                    new SubsonicApi.Data.Playlist {
                        Id = new SubsonicApi.Data.SubsonicId("16"),
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
            TestHelper.TestFileToData("playlists.xml", expectedResponse);
        }
    }
}
