using System;
using System.Collections.Generic;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class PlaylistsTest {
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
            TestHelper.TestFile("playlists.xml", expectedResponse);
        }
    }
}
