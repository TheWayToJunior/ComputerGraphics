using System.Drawing;

namespace PracticalWork8.Models
{
    public abstract class DynamicGameObject : GameObject
    {
        public Gap Gap { get; set; }

        public int CountFrames { get; set; }

        public int CountSprites { get; set; }

        public float CurrentFrame { get; set; }

        public float CurrentSprite { get; set; }

        public DynamicGameObject(string path, RectangleF srcRect)
            : base(path, srcRect)
        {
            CountSprites = 0;
        }

        public void Animate(float frame)
        {
            CurrentFrame  = frame % (CountFrames + 1);
            CurrentSprite = ++CurrentSprite % (CountSprites + 1);

            float width = base.SrcRectangle.Width;
            float height = base.SrcRectangle.Height;

            base.SrcRectangle = new RectangleF(
                x: (Gap.BetweenSprites + width) * CurrentSprite, 
                y: (Gap.BetweenFrames + height) * CurrentFrame,
                width, height);
        }
    }
}
