namespace Recommendations
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<string, List<RatingFilm>> GetCritics()
        {
            return new Dictionary<string, List<RatingFilm>>
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
                },
                {
                    "Michael Phillips",
                    new List<RatingFilm>
                        {
                            new RatingFilm("Lady in the Water", 2.5m),
                            new RatingFilm("Snakes on a Plane", 3.0m),
                            new RatingFilm("Superman Returns", 3.5m),
                            new RatingFilm("The Night Listener", 4.0m)
                        }
                },
                {
                    "Claudia Puig",
                    new List<RatingFilm>
                        {
                            new RatingFilm("Snakes on a Plane", 3.5m),
                            new RatingFilm("Just My Luck", 3.0m),
                            new RatingFilm("The Night Listener", 4.5m),
                            new RatingFilm("Superman Returns", 4.0m),
                            new RatingFilm("You, Me and Dupree", 2.5m)
                        }
                },
                {
                    "Mick LaSalle",
                    new List<RatingFilm>
                        {
                            new RatingFilm("Lady in the Water", 3.0m),
                            new RatingFilm("Snakes on a Plane", 4.0m),
                            new RatingFilm("Just My Luck", 2.0m),
                            new RatingFilm("Superman Returns", 3.0m),
                            new RatingFilm("The Night Listener", 3.0m),
                            new RatingFilm("You, Me and Dupree", 2.0m)
                        }
                },
                {
                    "Jack Matthews",
                    new List<RatingFilm>
                        {
                            new RatingFilm("Lady in the Water", 3.0m),
                            new RatingFilm("Snakes on a Plane", 4.0m),
                            new RatingFilm("The Night Listener", 3.0m),
                            new RatingFilm("Superman Returns", 5.0m),
                            new RatingFilm("You, Me and Dupree", 3.5m)
                        }
                },
                {
                    "Toby",
                    new List<RatingFilm>
                        {
                            new RatingFilm("Snakes on a Plane", 4.5m),
                            new RatingFilm("You, Me and Dupree", 1.0m),
                            new RatingFilm("Superman Returns", 4.0m)
                    }
                }
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("[1] Евклидово расстояние");
            Console.WriteLine("[2] Корреляции Пирсона");
            Console.WriteLine("[другое] Выход");

            var ch = Console.ReadKey();

            Console.Clear();

            IDistance distance = null;
            switch (ch.KeyChar)
            {
                case '1':
                    distance = FactoryDistance.CreateDistance<EuclideanDistance>(Program.GetCritics());
                    break;
            }

            if (distance != null)
            {
                var result = distance.SimDistance("Lisa Rose", "Gene Seymour");
                Console.WriteLine("Результат = {0}", result);
            }

            Console.ReadKey();
        }
    }
}
