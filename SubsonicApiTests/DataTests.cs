using System.Collections.Generic;
using NUnit.Framework;
using RestSharp.Deserializers;
using SubsonicApi.Data;

namespace SubsonicApiTests {
    [TestFixture]
    public static class DataTests {
        [Test]
        public static void TestPing() {
            using (var response = SampleLoader.CreateResponse("ping.xml")) {
                var expectedResponse = new SubsonicResponseData {
                    Status = "Ok",
                    Version = "1.1.1",
                };
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicResponseData>(response.Result);
                Assert.That(subsonicResponse, Is.EqualTo(expectedResponse));
            }
        }

        [Test]
        public static void TestMusicFolders() {
            using (var response = SampleLoader.CreateResponse("musicFolders.xml")) {
                var expectedResponse = new SubsonicResponseData {
                    Status = "Ok",
                    Version = "1.1.1",
                    MusicFolders = new List<MusicFolderData> {
                        new MusicFolderData { Id = "1", Name = "Music"},
                        new MusicFolderData { Id = "2", Name = "Movies"},
                        new MusicFolderData { Id = "3", Name = "Incoming"},
                    },
                };
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicResponseData>(response.Result);
                Assert.That(subsonicResponse, Is.EqualTo(expectedResponse));
            }
        }
    }
}
