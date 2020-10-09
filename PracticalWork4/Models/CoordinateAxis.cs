using System;

namespace PracticalWork4.Models
{
    public enum CoordinateAxisName 
    {
        [Description(Value = "x")]
        X,

        [Description(Value = "y")]
        Y 
    }

    public abstract class CoordinateAxis
    {
        public CoordinateAxis(int minValue, int maxValue, int countPoints)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.CountPoints = countPoints;
        }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int CountPoints { get; set; }

        public CoordinateAxisName Name { get; protected set; }

        public abstract Tuple<float, float> SettingScale(float dx, float dy, float indent, int i);
    }

    public class CoordinateAxisX : CoordinateAxis
    {
        public CoordinateAxisX(int minValue, int maxValue, int countPoints)
            : base(minValue, maxValue, countPoints)
        {
            base.Name = CoordinateAxisName.X;
        }

        public override Tuple<float, float> SettingScale(float dx, float dy, float indent, int i)
        {
            return new Tuple<float, float>(dx * indent * i, dy);
        }
    }

    public class CoordinateAxisY : CoordinateAxis
    {
        public CoordinateAxisY(int minValue, int maxValue, int countPoints)
            : base(minValue, maxValue, countPoints)
        {
            base.Name = CoordinateAxisName.Y;
        }

        public override Tuple<float, float> SettingScale(float dx, float dy, float indent, int i)
        {
            return new Tuple<float, float>(dx, dy * indent * i);
        }
    }
}
