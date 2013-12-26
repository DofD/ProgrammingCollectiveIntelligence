namespace Recommendations
{
    using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}