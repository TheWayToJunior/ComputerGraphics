using System.Drawing;
using System.Drawing.Drawing2D;

namespace PracticalWork6.Infrastructure
{
    public class Puff : IDrawable
    {
        private readonly Color _color;

        public Puff(Color color)
        {
            _color = color;
        }

        public Bitmap Draw()
        {
            var size = new Size(250, 250);

            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRegion(new SolidBrush(_color), DrawPuff(g, size));
            }

            return bitmap;
        }

        private Region DrawPuff(Graphics g, Size size)
        {
            Region unitedRegion = new Region();
            unitedRegion.MakeEmpty();

            int offset = size.Width / 10;
            int count = 4;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.FillMode = FillMode.Winding;

                path.AddEllipse(new Rectangle(0, offset / 2, size.Width / count, size.Height / count));

                int last = 0;
                for (int i = 1; i < count - 1; i++)
                {
                    int x = (size.Width / count - offset) * i;

                    path.AddEllipse(new Rectangle(x, 0, size.Width / count + 15, size.Height / count + 15));
                    last = x + size.Width / count - offset;
                }

                path.AddEllipse(new Rectangle(last, offset / 2, size.Width / count, size.Height / count));

                unitedRegion.Union(path);
            }

            return unitedRegion;
        }
    }
}
