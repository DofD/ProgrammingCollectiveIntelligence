namespace Recommendations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Фабрика создания вычислителей расстояний
    /// </summary>
    internal static class FactoryDistance
    {
        /// <summary>
        /// Создает указанный вычислитель
        /// </summary>
        /// <typeparam name="T">Тип вычислителя</typeparam>
        /// <param name="critics">Список критиков</param>
        /// <returns>Новый вычислитель</returns>
        public static IDistance CreateDistance<T>(Dictionary<string, List<RatingFilm>> critics) where T : IDistance
        {
            return (IDistance)Activator.CreateInstance(typeof(T), critics);
        }
    }
}