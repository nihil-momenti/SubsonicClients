using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class ChatMessagesTests {
        [Test]
        public static void TestChatMessages() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.2.0",
                ChatMessages = new List<ChatMessage> {
                    new ChatMessage {
                        UserName = "sindre",
                        Time = "1269771845310",
                        Message = "Sindre was here",
                    },
                    new ChatMessage {
                        UserName = "ben",
                        Time = "1269771842504",
                        Message = "Ben too",
                    },
                },
            };
            TestHelper.TestFile("chatMessages.xml", expectedResponse);
        }
    }
}
