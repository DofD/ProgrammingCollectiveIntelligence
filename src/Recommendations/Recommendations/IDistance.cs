namespace Recommendations
{
    /// <summary>
    /// Интерфейс вычислитель расстояния
    /// </summary>
    public interface IDistance
    {
        /// <summary>
        /// Метод получающий расстояние между персонами
        /// </summary>
        /// <param name="person1">Персона 1</param>
        /// <param name="person2">Персона 2</param>
        /// <returns>Расстояние</returns>
        decimal SimDistance(string person1, string person2);
    }
}