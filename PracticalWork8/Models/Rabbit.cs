using System.Drawing;

namespace PracticalWork8.Models
{
    public class Rabbit : DynamicGameObject
    {
        public float Speed { get; set; } = 10;

        public Rabbit()
            : base("rabbit.png", new RectangleF(5, 35, 50, 50))
        {
            CountFrames = 4;
            CountSprites = 3;
            Gap = new Gap(0, 0);
        }

        public bool IsMoved 
        {
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }

        public void Move(RandomMova strategy)
        {
            var s = strategy.Move(Point, Speed);

            if (s is AnimatedMove animated)
            {
                Animate(animated.Frame);
            }

            var point = s.Move(Point, Speed);

            if (!Map.Chack(point))
                Point = point;
        }
    }
}
