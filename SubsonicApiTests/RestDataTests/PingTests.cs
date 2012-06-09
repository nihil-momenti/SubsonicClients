using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class PingTests {
        [Test]
        public static void TestRestPing() {
            var expectedResponse = new SubsonicApi.RestData.SubsonicResponse {
                Status = "ok",
                Version = "1.1.1",
            };
            TestHelper.TestFileToRest("ping.xml", expectedResponse);
        }

        [Test]
        public static void TestPing() {
            var expectedResponse = new SubsonicApi.Data.SubsonicResponse {
                Ok = true,
                Version = new SubsonicApi.Data.SubsonicVersion { Major = 1, Minor = 1, Patch = 1 },
            };
            TestHelper.TestFileToData("ping.xml", expectedResponse);
        }
    }
}
