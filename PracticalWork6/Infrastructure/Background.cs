using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PracticalWork6.Infrastructure
{
    public class Background : IDrawable
    {
        public Bitmap Draw()
        {
            var size = new Size(250, 250);

            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            Point[] arrayWithoutPointOverlap =
            {
                new Point(0, 120),
                new Point(75, 75),
                new Point(150, 95),
                new Point(200, 85),
                new Point(225, 120)
            };

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (SolidBrush blueBrush = new SolidBrush(Color.FromArgb(3, 192, 60)))
                {
                    g.FillClosedCurve(blueBrush, arrayWithoutPointOverlap, FillMode.Winding);
                }
            }

            return bitmap;
        }
    }
}
