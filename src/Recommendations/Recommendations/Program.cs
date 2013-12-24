namespace Recommendations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            var result = 0m;
            switch (ch.KeyChar)
            {
                case '1': result = EuclideanDistance();
                    break;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static decimal EuclideanDistance()
        {
            var critics = GetCritics();

            var result = SimDistance(critics, "Lisa Rose", "Gene Seymour");

            return result;
        }

        private static decimal SimDistance(Dictionary<string, List<RatingFilm>> prefs, string person1, string person2)
        {
            // Получить список предметов, оцененных обоими
            var join = prefs[person1]
                        .Join(
                            prefs[person2],
                            item1 => item1,
                            item2 => item2,
                            (item1, item2) => new { nameFilm = item1.FilmName, rating1 = item1.Rating, rating2 = item2.Rating })
                        .ToList();

            // Если нет ни одной общей оценки, вернуть 0
            if (join.Count == 0)
            {
                return 0m;
            }

            // Получим сумму квадратов разностей
            var sum = join.Sum(item => Math.Pow((double)(item.rating1 - item.rating2), 2));

            //return (decimal)(1 / (1 + Math.Sqrt(sum)));
            return (decimal)(1 / (1 + sum));
        }
    }
}
