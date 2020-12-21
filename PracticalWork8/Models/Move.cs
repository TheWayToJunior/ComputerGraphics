using System;
using System.Drawing;

namespace PracticalWork8.Models
{

    public abstract class AnimatedMove : IMoveStrategy
    {
        public int Frame { get; set; }

        public AnimatedMove()
        {
        }

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

    /// <summary>
    /// 
    /// </summary>
    public class RandomMova
    {
        Random random;
        
        public RandomMova()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        IMoveStrategy s = new Right(2);

        public IMoveStrategy Move(PointF point, float speed)
        {
            if (Map.Chack(s.Move(point, speed))) 
            {
                switch (random.Next(DateTime.Now.Second) % 4)
                {
                    case 0:
                        s =  new Top(3);
                        break;
                    case 1:
                        s = new Bottom(0);
                        break;
                    case 2:
                        s = new Left(1);
                        break;
                    case 3:
                        s = new Right(2);
                        break;
                }
            }

            return s;
        }
    }
}
