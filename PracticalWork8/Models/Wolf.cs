using System.Drawing;

namespace PracticalWork8.Models
{
    public class Wolf : DynamicGameObject, IMoveable
    {
        public float Speed { get; set; } = 5;

        public bool IsMoved { get; set; }

        public Wolf(float spriteWidth, float spriteHeight)
            : base("wolf.png", new RectangleF(0, 0, spriteWidth, spriteHeight))
        {
        }

        public void Move(IMoveStrategy strategy)
        {
            if (strategy is AnimatedMove animated)
            {
                Animate(animated.Frame);
            }

            var point = strategy.Move(Point, Speed);

            if(!Map.Chack(point))
                Point = point;
        }
    }
}
