using PracticalWork6.Extensions;
using System.Drawing;

namespace PracticalWork6.Infrastructure
{
    public class Road : IDrawable
    {
        public Bitmap Draw()
        {
            var size = new Size(250, 250);

            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Gray, 0, 0, size.Width, size.Height);
            }

            for (int i = 0; i < 5; i++)
            {
                bitmap.Combine(GetMark(), new Rectangle(i * 60 + 10, 125, 30, 15));
            }

            return bitmap;
                
        }

        private Bitmap GetMark()
        {
            Bitmap bitmap = new Bitmap(50, 20);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Orange, 0, 0, 50, 20);
            }

            return bitmap;
        }
    }
}
