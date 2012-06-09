using System.Collections.Generic;
using NUnit.Framework;
using SubsonicApi.RestData;

namespace SubsonicApiTests.DataTests {
    [TestFixture]
    public static class AlbumListTests {
        [Test]
        public static void TestAlbumList() {
            var expectedResponse = new SubsonicResponse {
                Status = "ok",
                Version = "1.6.0",
                AlbumList = new List<Album> {
                    new Album {
                        Id = "11",
                        Parent = "1",
                        Title = "Arrival",
                        Artist = "ABBA",
                        IsDir = true,
                        CoverArt = "22",
                        UserRating = 4,
                        AverageRating = 4.5,
                    },
                    new Album {
                        Id = "12",
                        Parent = "1",
                        Title = "Super Trouper",
                        Artist = "ABBA",
                        IsDir = true,
                        CoverArt = "23",
                        AverageRating = 4.4,
                    },
                },
            };
            TestHelper.TestFileToRest("albumList.xml", expectedResponse);
        }
    }
}
