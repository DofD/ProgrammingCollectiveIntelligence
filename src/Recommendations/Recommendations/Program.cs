namespace Recommendations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
            Console.WriteLine("[3] Ранжирование критиков 'Евклидово расстояние'");
            Console.WriteLine("[4] Ранжирование критиков 'Корреляции Пирсона'");
            Console.WriteLine("[другое] Выход");

            var ch = Console.ReadKey();

            Console.Clear();

            IDistance distance = null;
            switch (ch.KeyChar)
            {
                case '1':
                    distance = FactoryDistance.CreateDistance<EuclideanDistance>(Program.GetCritics());
                    break;
                case '2':
                    distance = FactoryDistance.CreateDistance<CorrelationPearson>(Program.GetCritics());
                    break;
                case '3':
                    Program.RankingCritics(typeof(EuclideanDistance), Console.In, Console.Out);
                    break;
                case '4':
                    Program.RankingCritics(typeof(CorrelationPearson), Console.In, Console.Out);
                    break;
            }

            if (distance != null)
            {
                var result = distance.SimDistance("Lisa Rose", "Gene Seymour");
                Console.WriteLine("Результат = {0}", result);
            }

            Console.ReadKey();
        }

        private static void RankingCritics(Type typeSimilarity, TextReader inTextReader, TextWriter outTextWriter)
        {
            const string myName = "My";

            outTextWriter.WriteLine("Введите количество критиков:");
            int count;

            do
            {
                var line = inTextReader.ReadLine();
                int.TryParse(line, out count);

                if (count <= 0)
                {
                    outTextWriter.WriteLine("Число должно быть больше 0");
                }
            }
            while (count == 0);

            var ratingFilms = new List<RatingFilm>();
            outTextWriter.WriteLine("Введите рейтинг фильмов (имя фильма / оценку [Y - закончить]");

            string rayingStr;
            do
            {
                rayingStr = inTextReader.ReadLine();

                if (rayingStr != null)
                {
                    var ratingParse = rayingStr.Split('/');

                    if (ratingParse.Length == 2)
                    {
                        decimal rating;
                        decimal.TryParse(ratingParse[1], out rating);

                        ratingFilms.Add(new RatingFilm(ratingParse[0], rating));
                    }
                }
            }
            while (rayingStr != "Y");

            var prefs = Program.GetCritics();
            prefs.Add(myName, ratingFilms);

            foreach (var rating in Program.TopMatches(prefs, myName, typeSimilarity, count))
            {
                outTextWriter.WriteLine("({0} {1})", rating.Value, rating.Key);
            }

        }

        /// <summary>
        /// Возвращает список наилучших соответствий для человека из словаря prefs.
        /// </summary>
        /// <param name="prefs">Список оценок</param>
        /// <param name="person">Имя критика для которого происходит сравнение</param>
        /// <param name="typeSimilarity">Тип функции подобия</param>
        /// <param name="n">Количество результатов в списке</param>
        /// <returns>Список результатов</returns>
        private static IEnumerable<KeyValuePair<string, decimal>> TopMatches(Dictionary<string, List<RatingFilm>> prefs, string person, Type typeSimilarity, int n = 5)
        {
            var similarity = FactoryDistance.CreateDistance(typeSimilarity, prefs);

            return prefs.Where(rec => rec.Key != person)
                .Select(pref => new KeyValuePair<string, decimal>(pref.Key, similarity.SimDistance(pref.Key, person)))
                .OrderByDescending(x => x.Value)
                .Take(n)
                .ToList();
        }
    }
}
