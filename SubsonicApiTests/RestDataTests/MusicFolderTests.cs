using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class MusicFolderTests {
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
            TestHelper.TestFile("musicFolders.xml", expectedResponse);
        }
    }
}
