using System.Drawing;
using System;

namespace PracticalWork8.Models
{
    public abstract class GameObject
    {
        public RectangleF SrcRectangle { get; set; }

        public RectangleF DescRectangle => new RectangleF(Point, SrcRectangle.Size);

        public SizeF Size { get; set; }

        public PointF Point { get; set; }

        public Bitmap Image { get; set; }

        public GameObject()
        {
        }

        public GameObject(string path, RectangleF srcRect) 
            : this(new Bitmap(path), srcRect)
        {

        }

        public GameObject(Bitmap image, RectangleF srcRect)
        {
            Image = image;
            SrcRectangle = srcRect;
        }

        public virtual void Draw(Graphics graphics)
        {
            if (Image is null)
                throw new InvalidOperationException($"{nameof(Image)} is null");

            graphics.DrawImage(Image, new RectangleF(Point.X, Point.Y, Size.Width, Size.Height),
                SrcRectangle, GraphicsUnit.Pixel);
        }
    }
}
