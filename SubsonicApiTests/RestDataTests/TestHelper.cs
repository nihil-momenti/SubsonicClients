using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Moq;
using Nemo157.Common;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class TestHelper {
        internal static Task<Stream> LoadSample(string sample) {
            return Task.Run(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("SubsonicApiTests.RestDataTests.ResponseSamples." + sample));
        }

        internal async static Task<IRestResponse> CreateResponse(string sample) {
            Mock<IRestResponse> response = new Mock<IRestResponse>();
            var file = Async.AutoDispose(
                            Async.Using(await LoadSample(sample), stream =>
                                Async.Using(new StreamReader(stream), reader =>
                                    reader.ReadToEndAsync())));
            response.SetupGet(res => res.Content).Returns(() => file.Result);
            return response.Object;
        }

        internal static void TestFileToRest(string dataFile, SubsonicApi.RestData.SubsonicResponse expectedResponse) {
            using (var response = CreateResponse(dataFile)) {
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicApi.RestData.SubsonicResponse>(response.Result);
                Assert.That(subsonicResponse, Iss.EqualByPropertyTo(expectedResponse));
            }
        }

        internal static void TestFileToData(string dataFile, SubsonicApi.Data.SubsonicResponse expectedResponse) {
            using (var response = CreateResponse(dataFile)) {
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicApi.RestData.SubsonicResponse>(response.Result);
                Assert.That(new SubsonicApi.Data.SubsonicResponse(subsonicResponse), Iss.EqualByPropertyTo(expectedResponse));
            }
        }
    }
}