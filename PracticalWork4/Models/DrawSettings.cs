namespace PracticalWork4.Models
{
    /// <summary>
    /// Offset of the origin on both axes
    /// </summary>
    public class Offset
    {
        public Offset(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }

    /// <summary>
    /// Shifting elements along the axis for each iteration
    /// </summary>
    public class Direction
    {
        public Direction(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }
    }

    public class DrawSettings
    {
        public DrawSettings(float lineWidth, int countPints, int maxValue, Direction direction)
        {
            this.LineWidth = lineWidth;
            this.CountPoints = countPints;
            this.MaxValue = maxValue;
            this.Direction = direction;

            this.Offset = new Offset(default, default);
        }

        public int StartPoint { get; set; }

        public float StartValue { get; set; }

        public float LineWidth { get; set; }

        public int CountPoints { get; set; }

        public int MaxValue { get; set; }

        public Offset Offset { get; set; }

        public Direction Direction { get; set; }
    }
}
