using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class PodcastsTests {
        [Test]
        public static void TestPodcasts() {
            var expectedResponse = new SubsonicResponse {
                Status = "ok",
                Version = "1.6.0",
                Podcasts = new List<Channel> {
                    new Channel {
                        Id = "1",
                        Url = new Uri("http://downloads.bbc.co.uk/podcasts/fivelive/drkarl/rss.xml"),
                        Title = "Dr Karl and the Naked Scientist",
                        Description = "Dr Chris Smith aka The Naked Scientist with the latest news from the world of science and Dr Karl answers listeners' science questions.",
                        Status = "completed",
                        Episodes = new List<Episode> {
                            new Episode {
                                Id = "34",
                                StreamId = "523",
                                Title = "Scorpions have re-evolved eyes",
                                Description = "This week Dr Chris fills us in on the UK's largest free science festival, plus all this week's big scientific discoveries.",
                                PublishDate = new DateTime(2011, 2, 3, 14, 46, 43),
                                Status = "completed",
                                Parent = "11",
                                IsDir = false,
                                Year = 2011,
                                Genre = "Podcast",
                                CoverArt = "24",
                                Size = 78421341,
                                ContentType = "audio/mpeg",
                                Suffix = "mp3",
                                Duration = 3146,
                                BitRate = 128,
                                Path = "Podcast/drkarl/20110203.mp3",
                            },
                            new Episode {
                                Id = "35",
                                StreamId = "524",
                                Title = "Scar tissue and snake venom treatment",
                                Description = "This week Dr Karl tells the gruesome tale of a surgeon who operated on himself.",
                                PublishDate = new DateTime(2011, 9, 3, 16, 47, 52),
                                Status = "completed",
                                Parent = "11",
                                IsDir = false,
                                Year = 2011,
                                Genre = "Podcast",
                                CoverArt = "27",
                                Size = 45624671,
                                ContentType = "audio/mpeg",
                                Suffix = "mp3",
                                Duration = 3099,
                                BitRate = 128,
                                Path = "Podcast/drkarl/20110903.mp3"
                            },
                        },
                    },
                    new Channel {
                        Id = "2",
                        Url = new Uri("http://podkast.nrk.no/program/herreavdelingen.rss"),
                        Title = "NRK P1 - Herreavdelingen",
                        Description = "Et program der herrene Yan Friis og Finn Bjelke møtes og musikk nytes.",
                        Status = "completed",
                    },
                    new Channel {
                        Id = "3",
                        Url = new Uri("http://foo.bar.com/xyz.rss"),
                        Status = "error",
                        ErrorMessage = "Not found.",
                    },
                },
            };
            TestHelper.TestFileToRest("podcasts.xml", expectedResponse);
        }
    }
}
