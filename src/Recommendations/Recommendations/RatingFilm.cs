namespace Recommendations
{
    using System;

    internal class RatingFilm : IComparable, IComparable<RatingFilm>
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.FilmName != null ? this.FilmName.GetHashCode() : 0);
            }
        }

        public RatingFilm(string filmName, decimal rating)
        {
            this.FilmName = filmName;
            this.Rating = rating;
        }

        public string FilmName { get; set; }

        public decimal Rating { get; set; }

        public static RatingFilm operator -(RatingFilm a, RatingFilm b)
        {
            if (a != b)
            {
                throw new ArgumentException("Нельзя вычитать разные фильмы");
            }

            return new RatingFilm(a.FilmName, a.Rating - b.Rating);
        }
        public static RatingFilm operator +(RatingFilm a, RatingFilm b)
        {
            if (!a.Equals(b))
            {
                throw new ArgumentException("Нельзя суммировать разные фильмы");
            }

            return new RatingFilm(a.FilmName, a.Rating + b.Rating);
        }

        protected bool Equals(RatingFilm other)
        {
            return other != null && this.FilmName == other.FilmName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RatingFilm);
        }

        public override string ToString()
        {
            return this.FilmName;
        }

        public int CompareTo(RatingFilm other)
        {
            return other == null 
                ? -1 
                : this.Rating.CompareTo(other.Rating);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as RatingFilm);
        }
    }
}
