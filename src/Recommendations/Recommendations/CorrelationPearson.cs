namespace Recommendations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ����� ����������� ����������� ���������� �������
    /// </summary>
    public class CorrelationPearson : IDistance
    {
        /// <summary>
        /// ����� ������ ��������
        /// </summary>
        private readonly Dictionary<string, List<RatingFilm>> prefs;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="prefs">����� ������ ��������</param>
        public CorrelationPearson(Dictionary<string, List<RatingFilm>> prefs)
        {
            this.prefs = prefs;
        }

        /// <summary>
        /// ����� ���������� ����������� ���������� ������� ����� ���������
        /// </summary>
        /// <param name="person1">������� 1</param>
        /// <param name="person2">������� 2</param>
        /// <returns>����������</returns>
        public decimal SimDistance(string person1, string person2)
        {
            // �������� ������ ���������, ��������� ������
            var join = this.prefs[person1]
                        .Join(
                            prefs[person2],
                            item1 => item1,
                            item2 => item2,
                            (item1, item2) => new { nameFilm = item1.FilmName, rating1 = item1.Rating, rating2 = item2.Rating })
                        .ToList();

            // ���� ��� �� ����� ����� ������, ������� 0
            var n = join.Count;
            if (n == 0)
            {
                return 0m;
            }

            // ��������� ����� ���� ������������
            var sum1 = join.Select(x => x.rating1).Sum();
            var sum2 = join.Select(x => x.rating2).Sum();

            // ��������� ����� ���������
            var sum1Sq = join.Select(x => Math.Pow((double)x.rating1, 2)).Sum();
            var sum2Sq = join.Select(x => Math.Pow((double)x.rating2, 2)).Sum();

            // ��������� ����� ������������
            var pSum = join.Select(x => x.rating1 * x.rating2).Sum();

            // ��������� ����������� �������
            var num = pSum - (sum1 * sum2 / n);
            var den = Math.Sqrt((sum1Sq - Math.Pow((double)sum1, 2) / n) * (sum2Sq - Math.Pow((double)sum2, 2) / n));

            return (decimal)(den == 0 ? 0 : (double)num / den);
        }
    }
}