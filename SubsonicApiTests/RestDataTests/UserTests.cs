using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class UserTests {
        [Test]
        public static void TestRestUser() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.7.0",
                User = new SubsonicApi.RestData.User {
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
            TestHelper.TestFileToRest("user.xml", expectedResponse);
        }

        [Test]
        public static void TestUser() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 7, Patch = 0 },
                User = new SubsonicApi.Data.User {
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
            TestHelper.TestFileToData("user.xml", expectedResponse);
        }
    }
}
