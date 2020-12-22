using System.Drawing;

namespace PracticalWork8.Models
{
    public class Rabbit : DynamicGameObject, IMoveable
    {
        public float Speed { get; set; } = 10;

        public Rabbit()
            : base("rabbit.png", new RectangleF(0, 0, 50, 50))
        {
            CountFrames = 4;
            CountSprites = 3;
            Gap = new Gap(0, 0);
        }

        public bool IsMoved { get; set; }

        public void Move(IMoveStrategy strategy)
        {
            if (strategy is AnimatedMove animated)
            {
                Animate(animated.Frame);
            }

            var point = strategy.Move(Point, Speed);

            if (!Map.Chack(point))
                Point = point;
        }
    }
}
