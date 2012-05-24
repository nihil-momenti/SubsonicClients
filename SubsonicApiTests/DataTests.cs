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
                    Status = "ok",
                    Version = "1.1.1",
                };
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicResponseData>(response.Result);
                Assert.That(subsonicResponse, Is.EqualTo(expectedResponse).Using(new PropertyComparer()));
            }
        }

        [Test]
        public static void TestNowPlaying() {
            using (var response = SampleLoader.CreateResponse("nowPlaying.xml")) {
                var expectedResponse = new SubsonicResponseData {
                    Status = "Ok",
                    Version = "1.1.1",
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
                var subsonicResponse = new XmlDeserializer().Deserialize<SubsonicResponseData>(response.Result);
                Assert.That(subsonicResponse, Is.EqualTo(expectedResponse).Using(new PropertyComparer()));
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
                Assert.That(subsonicResponse, Is.EqualTo(expectedResponse).Using(new PropertyComparer()));
            }
        }
    }
}
