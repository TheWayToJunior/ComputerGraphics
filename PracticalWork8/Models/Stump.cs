using System.Drawing;

namespace PracticalWork8.Models
{
    class Stump : StaticGameObject
    {
        public Stump()
        {
            Image = new Bitmap("back.png");
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image,
                new RectangleF(Point, Size),
                new RectangleF(605, 400, 50, 50),
                GraphicsUnit.Pixel);
        }
    }

    class Fir : StaticGameObject
    {
        public Fir()
        {
            Image = new Bitmap("back.png");
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image,
                new RectangleF(Point, Size),
                new RectangleF(640, 260, 80, 120),
                GraphicsUnit.Pixel);
        }
    }
}
