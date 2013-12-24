namespace UnitTestRecommendations
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Recommendations;

    using TypeMock.ArrangeActAssert;

    [TestClass]
    public class TestEuclideanDistance
    {
        private Dictionary<string, List<RatingFilm>> dataTest;

        [TestInitialize]
        public void TestInitialize()
        {
            this.dataTest = new Dictionary<string, List<RatingFilm>>
                {
                    {
                        "Lisa Rose",
                        new List<RatingFilm>
                            {
                                new RatingFilm("Lady in the Water", 2.5m),
                                new RatingFilm("Snakes on a Plane", 3.5m),
                                new RatingFilm("Just My Luck", 3.0m),
                                new RatingFilm("Superman Returns", 3.5m),
                                new RatingFilm("You, Me and Dupree", 2.5m),
                                new RatingFilm("The Night Listener", 3.0m)
                            }
                    },
                    {
                        "Gene Seymour",
                        new List<RatingFilm>
                            {
                                new RatingFilm("Lady in the Water", 3.0m),
                                new RatingFilm("Snakes on a Plane", 3.5m),
                                new RatingFilm("Just My Luck", 1.5m),
                                new RatingFilm("Superman Returns", 5.0m),
                                new RatingFilm("The Night Listener", 3.0m),
                                new RatingFilm("You, Me and Dupree", 3.5m)
                            }
                    }
                };
        }

        [TestMethod]
        public void TestSimDistance()
        {
            Isolate.WhenCalled(() => GetCritics()).WillReturn(this.dataTest);
        }
    }
}
