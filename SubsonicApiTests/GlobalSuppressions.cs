using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]

[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", Scope = "namespace", Target = "SubsonicApiTests")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", Scope = "namespace", Target = "SubsonicApiTests.DataTests")]

[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Sindre", Scope = "member", Target = "SubsonicApiTests.DataTests.ChatMessagesTests.#TestChatMessages()")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "SubsonicApi.RestData.ChatMessage.set_Message(System.String)", Scope = "member", Target = "SubsonicApiTests.DataTests.ChatMessagesTests.#TestChatMessages()")]
