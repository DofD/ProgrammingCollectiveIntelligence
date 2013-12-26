namespace Recommendations
{
    using System;

    /// <summary>
    /// Класс рейтинг фильма.
    /// </summary>
    public class RatingFilm : IComparable, IComparable<RatingFilm>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RatingFilm"/>.
        /// </summary>
        /// <param name="filmName"> Наименование. </param>
        /// <param name="rating"> Рейтинг. </param>
        public RatingFilm(string filmName, decimal rating)
        {
            this.FilmName = filmName;
            this.Rating = rating;
        }

        /// <summary>
        /// Наименование фильма.
        /// </summary>
        public string FilmName { get; set; }

        /// <summary>
        /// Рейтинг фильма.
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Оператор +.
        /// </summary>
        /// <param name="a"> Рейтинг фильма а </param>
        /// <param name="b"> Рейтинг фильма b. </param>
        /// <returns>Сумма рейтингов</returns>
        /// <exception cref="ArgumentException">Если имена не совпадают генерируется исключение</exception>
        public static RatingFilm operator +(RatingFilm a, RatingFilm b)
        {
            if (!a.Equals(b))
            {
                throw new ArgumentException("Нельзя суммировать разные фильмы");
            }

            return new RatingFilm(a.FilmName, a.Rating + b.Rating);
        }

        /// <summary>
        /// Оператор -.
        /// </summary>
        /// <param name="a"> Рейтинг фильма а </param>
        /// <param name="b"> Рейтинг фильма b. </param>
        /// <returns>Разность рейтингов</returns>
        /// <exception cref="ArgumentException">Если имена не совпадают генерируется исключение</exception>
        public static RatingFilm operator -(RatingFilm a, RatingFilm b)
        {
            if (!a.Equals(b))
            {
                throw new ArgumentException("Нельзя вычитать разные фильмы");
            }

            return new RatingFilm(a.FilmName, a.Rating - b.Rating);
        }

        /// <summary>
        /// Сравниватель рейтингов фильмов.
        /// </summary>
        /// <param name="other"> Рейтинг фильма для сравнения </param>
        /// <returns> Результат сравнения </returns>
        public int CompareTo(RatingFilm other)
        {
            return other == null ? -1 : this.Rating.CompareTo(other.Rating);
        }

        /// <summary>
        /// Сравниватель рейтинг фильма с объектом.
        /// </summary>
        /// <param name="obj"> Объект для сравнения </param>
        /// <returns> Результат сравнения </returns>
        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as RatingFilm);
        }

        /// <summary>
        /// Проверяет равенство между Рейтингом фильма и объектом.
        /// </summary>
        /// <param name="obj"> Объект для проверки </param>
        /// <returns>Результат проверки</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as RatingFilm);
        }

        /// <summary>
        /// Получает хеш код.
        /// </summary>
        /// <returns>Хеш код</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return this.FilmName != null ? this.FilmName.GetHashCode() : 0;
            }
        }

        /// <summary>
        /// Получает строковое представление
        /// </summary>
        /// <returns> Строковое представление </returns>
        public override string ToString()
        {
            return this.FilmName;
        }

        /// <summary>
        /// Проверяет равенство между Рейтингами фильмов.
        /// </summary>
        /// <param name="other"> Рейтинг фильма </param>
        /// <returns>Результат проверки</returns>
        protected bool Equals(RatingFilm other)
        {
            return other != null && this.FilmName == other.FilmName;
        }
    }
}