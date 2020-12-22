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


    public class RandomMova : AnimatedMove
    {
        private Random _random;
        private IMoveStrategy _strategy;

        public RandomMova()
        {
            _random = new Random(DateTime.Now.Second);
            _strategy = GetStrategy(_random.Next(4));
        }

        private IMoveStrategy GetStrategy(int rand)
        {
            AnimatedMove randStrategy = null;

            switch (_random.Next(4))
            {
                case 0:
                    randStrategy = new Top(3);
                    break;
                case 1:
                    randStrategy = new Bottom(0);
                    break;
                case 2:
                    randStrategy = new Left(1);
                    break;
                case 3:
                    randStrategy = new Right(2);
                    break;
            }

            base.Frame = randStrategy.Frame;
            return randStrategy;
        }

        public override PointF Move(PointF point, float speed)
        {
            if (Map.Chack(_strategy.Move(point, speed))) 
            {
                _strategy = GetStrategy(_random.Next(DateTime.Now.Second) % 4);
            }

            return _strategy.Move(point, speed);
        }
    }
}
