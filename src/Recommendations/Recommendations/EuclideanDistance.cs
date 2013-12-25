namespace Recommendations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Класс считающий Евклидово растояние
    /// </summary>
    public class EuclideanDistance : IDistance
    {
        /// <summary>
        /// Набор отценок критиков
        /// </summary>
        private readonly Dictionary<string, List<RatingFilm>> prefs;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prefs">Набор отценок критиков</param>
        public EuclideanDistance(Dictionary<string, List<RatingFilm>> prefs)
        {
            this.prefs = prefs;
        }

        /// <summary>
        /// Метод получающий Евклидово расстояние между персонами
        /// </summary>
        /// <param name="person1">Персона 1</param>
        /// <param name="person2">Персона 2</param>
        /// <returns>Расстояние</returns>
        public decimal SimDistance(string person1, string person2)
        {
            // Получить список предметов, оцененных обоими
            var join = this.prefs[person1]
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
