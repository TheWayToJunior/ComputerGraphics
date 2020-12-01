using PracticalWork6.Extensions;
using PracticalWork6.Infrastructure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork6
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bitmap bitmap = new Bitmap(1000, 1000);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(70, 0, 0, 200)), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }

            var puff = new Puff(Color.White).Draw();

            Application.Run(new MainView(bitmap
                .Combine(puff, new Rectangle(65, 20, 260, 260))
                .Combine(puff, new Rectangle(350, 50, 200, 200))
                .Combine(puff, new Rectangle(590, 40, 250, 250))
                .Combine(new Background().Draw(), new Rectangle(0, 0, 900, 800))
                .Combine(new Road().Draw(), new Rectangle(0, 375, 900, 175))
                .Combine(new Airplane().Draw(), new Rectangle(275, 200, 325, 250))));
        }
    }
}
