using System.Drawing;

namespace PracticalWork8.Models
{

    public abstract class AnimatedMove : IMoveStrategy
    {
        public int Frame { get; set; }

        public AnimatedMove(int frame)
        {
            Frame = frame;
        }

        public abstract PointF Move(PointF point, float speed);
    }

    public class Left : AnimatedMove
    {
        public Left(int frame)
            : base(frame)
        {
        }

        public override PointF Move(PointF point, float speed) =>
            new PointF(point.X - speed, point.Y);
    }

    public class Right : AnimatedMove
    {
        public Right(int frame)
            : base(frame)
        {
        }

        public override PointF Move(PointF point, float speed) =>
            new PointF(point.X + speed, point.Y);
    }

    public class Top : AnimatedMove
    {
        public Top(int frame)
            : base(frame)
        {
        }

        public override PointF Move(PointF point, float speed) =>
            new PointF(point.X, point.Y - speed);
    }

    public class Bottom : AnimatedMove
    {
        public Bottom(int frame)
            : base(frame)
        {
        }

        public override PointF Move(PointF point, float speed) =>
            new PointF(point.X, point.Y + speed);
    }
}
