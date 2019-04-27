namespace TrueSnake
{
    /// <summary>
    /// Represents the point which is formed from X and Y coordinate
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }

        public Point(int xPoint, int yPoint)
        {
            X = xPoint;
            Y = yPoint;
        }
    }
}
