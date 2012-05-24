using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RestSharp;

namespace SubsonicApiTests {
    internal static class SampleLoader {
        internal static Task<Stream> Load(string sample) {
            return Task.Run(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("SubsonicApiTests.ResponseSamples." + sample));
        }

        internal async static Task<IRestResponse> CreateResponse(string sample) {
            Mock<IRestResponse> response = new Mock<IRestResponse>();
            var file = Async.Using(await Load(sample), stream =>
                            Async.Using(new StreamReader(stream), reader =>
                                reader.ReadToEndAsync()));
            response.SetupGet(res => res.Content).Returns(() => file.Result);
            return response.Object;
        }
    }
}
