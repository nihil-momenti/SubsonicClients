using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class JukeboxStatusTests {
        [Test]
        public static void TestJukeboxStatus() {
            var expectedResponse = new SubsonicResponse {
                Status = "ok",
                Version = "1.7.0",
                JukeboxStatus = new JukeboxStatus {
                    CurrentIndex = 7,
                    Playing = true,
                    Gain = 0.9,
                    Position = 67,
                }
            };
            TestHelper.TestFileToRest("jukeboxStatus.xml", expectedResponse);
        }
    }
}
