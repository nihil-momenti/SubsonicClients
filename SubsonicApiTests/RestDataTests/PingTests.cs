using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class PingTests {
        [Test]
        public static void TestPing() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.1.1",
            };
            TestHelper.TestFile("ping.xml", expectedResponse);
        }
    }
}
