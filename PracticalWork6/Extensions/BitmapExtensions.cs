using System.Drawing;

namespace PracticalWork6.Extensions
{
    static class BitmapExtensions
    {
        public static Bitmap Combine(this Bitmap main, Bitmap adding, Rectangle rectangle)
        {
            using (Graphics g = Graphics.FromImage(main))
            {
                g.DrawImage(adding, rectangle);

                return main;
            }
        }
    }
}
