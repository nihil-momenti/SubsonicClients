using System.Collections.Generic;
using Nemo157.Common;
using NUnit.Framework;
using RestSharp.Deserializers;
using SubsonicApi.RestData;

namespace SubsonicApiTests {
    [TestFixture]
    public static class DataTests {
        internal static void TestFile(string dataFile, SubsonicResponseData expectedResponse) {
            using (var response = SampleLoader.CreateResponse(dataFile)) {
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicResponseData>(response.Result);
                Assert.That(subsonicResponse, Iss.EqualByPropertyTo(expectedResponse));
            }
        }

        [Test]
        public static void TestPing() {
            var expectedResponse = new SubsonicResponseData {
                Status = "ok",
                Version = "1.1.1",
            };
            TestFile("ping.xml", expectedResponse);
        }

        [Test]
        public static void TestNowPlaying() {
            var expectedResponse = new SubsonicResponseData {
                Status = "ok",
                Version = "1.4.0",
                NowPlaying = new List<NowPlayingData> {
                        new NowPlayingData {
                            UserName = "sindre",
                            MinutesAgo = 12,
                            PlayerId = "2",
                            Id = "111",
                            Parent = "11",
                            Title = "Dancing Queen",
                            IsDir = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = "24",
                            Size = 8421341,
                            ContentType = "audio/mpeg",
                            Suffix = "mp3",
                            Path = "ABBA/Arrival/Dancing Queen.mp3",
                        },
                        new NowPlayingData {
                            UserName = "bente",
                            MinutesAgo = 1,
                            PlayerId = "4",
                            PlayerName = "Kitchen",
                            Id = "112",
                            Parent = "11",
                            Title = "Money, Money, Money",
                            IsDir = false,
                            Album = "Arrival",
                            Artist = "ABBA",
                            Track = "7",
                            Year = 1978,
                            Genre = "Pop",
                            CoverArt = "25",
                            Size = 4910028,
                            ContentType = "audio/flac",
                            Suffix = "flac",
                            TranscodedContentType = "audio/mpeg",
                            TranscodedSuffix = "mp3",
                            Path = "ABBA/Arrival/Money, Money, Money.mp3",
                        },
                    },
            };
            TestFile("nowPlaying.xml", expectedResponse);
        }

        [Test]
        public static void TestMusicFolders() {
            var expectedResponse = new SubsonicResponseData {
                Status = "ok",
                Version = "1.1.1",
                MusicFolders = new List<MusicFolderData> {
                    new MusicFolderData { Id = "1", Name = "Music"},
                    new MusicFolderData { Id = "2", Name = "Movies"},
                    new MusicFolderData { Id = "3", Name = "Incoming"},
                },
            };
            TestFile("musicFolders.xml", expectedResponse);
        }
    }
}
