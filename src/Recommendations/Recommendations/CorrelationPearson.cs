namespace Recommendations
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс вычисляющий коэффициент корреляции Пирсона
    /// </summary>
    public class CorrelationPearson : IDistance
    {
        /// <summary>
        /// Набор оценок критиков
        /// </summary>
        private readonly Dictionary<string, List<RatingFilm>> prefs;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prefs">Набор оценок критиков</param>
        public CorrelationPearson(Dictionary<string, List<RatingFilm>> prefs)
        {
            this.prefs = prefs;
        }

        /// <summary>
        /// Метод получающий коэффициент корреляции Пирсона между персонами
        /// </summary>
        /// <param name="person1">Персона 1</param>
        /// <param name="person2">Персона 2</param>
        /// <returns>Расстояние</returns>
        public decimal SimDistance(string person1, string person2)
        {
            throw new System.NotImplementedException();
        }
    }
}