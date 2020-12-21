using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork7
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            this.timer1.Tick += timer1_Tick;
            this.button1.Click += button1_Click;
            this.pictureBox1.Paint += PictureBox1_Paint;

            DoubleBuffered = true;
        }

        Point point;

        private void button1_Click(object sender, EventArgs e)
        {
            point = new Point(-100, 100);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (point.Y == 10)
            {
                timer1.Enabled = false;
                return;
            }

            point.X += 6;
            point.Y -= 5;

            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (timer1.Enabled)
                e.Graphics.DrawImage(new Bitmap("sun.png"), new RectangleF(point.X, point.Y, 100, 100));
        }
    }
}
