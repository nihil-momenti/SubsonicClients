using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.RestDataTests {
    [TestFixture]
    public static class LyricsTests {
        [Test]
        public static void TestLyrics() {
            var expectedResponse = new SubsonicRestResponse {
                Status = "ok",
                Version = "1.2.0",
                Lyrics = new Lyrics {
                    Artist = "Muse",
                    Title = "Hysteria",
                    Value = @"
    It's bugging me
    Grating me
    And twisting me around
    Yeah I'm endlessly
    Caving in
    And turning inside out

    Cause I want it now
    I want it now
    Give me your heart and your soul
    And I'm breaking out
    I'm breaking out
    That's when she'll lose control

    It's holding me
    Morphing me
    And forcing me to strive
    To be endlessly
    Cold within
    And dreaming I'm alive

    Cause I want it now
    I want it now
    Give me your heart and your soul
    I'm not breaking down
    I'm breaking out
    That's when she'll lose control

    And I want you now
    I want you now
    I'll feel my heart implode
    And I'm breaking out
    Escaping now
    Feeling my faith erode
  ".Replace("\r", ""),
                },
            };
            TestHelper.TestFile("lyrics.xml", expectedResponse);
        }
    }
}
