using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class UserTests {
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
            TestHelper.TestFile("user.xml", expectedResponse);
        }
    }
}
