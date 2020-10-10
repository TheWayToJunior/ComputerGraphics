using PracticalWork4.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PracticalWork4
{
    public partial class Form1 : Form
    {
        private int max;
        private int[] numbers;

        private Offset offset;

        private DrawingGraphics drawingGraphics;
        private GraphicsSignature graphicsSignature;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += PictureBox1_Paint;
            button1.Click += Button1_Click;
            button2.Click += (s, e) => 
            {
                drawingGraphics = null;
                pictureBox1.Refresh();
            };

            this.Resize += (s, e) => pictureBox1.Refresh();

            Random rnd = new Random((int)DateTime.Now.Ticks);

            numbers = Enumerable.Range(-12, 31).OrderBy(r => rnd.Next()).ToArray();
            max = numbers.Max(i => Math.Abs(i));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            var g = pictureBox1.CreateGraphics();
            g.TranslateTransform(offset.X, offset.Y);

            var p = new Pen(Color.Green, 3);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            graphicsSignature = new GraphicsSignature
            {
                Pen = p,
                Brush = Brushes.Blue,
                Font = new Font("Arial", 10),
            };

            drawingGraphics = new DrawingGraphics(g);
            drawingGraphics.Draw(numbers, new RectangleF(offset.X, -offset.Y,
                pictureBox1.Width, pictureBox1.Height), graphicsSignature);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var x = new CoordinateAxisX(minValue: 1, maxValue: 31, countPoints: 31);
            var y = new CoordinateAxisY(minValue: -max, maxValue: max, countPoints: 15);

            var cs = new Models.CoordinateSystem(x, y);

            cs.Signature = new Models.CoordinateSystemSignature
            {
                Brush = Brushes.Red,
                Font = new Font("Arial", 10),
            };

            var draw = new DrawingСoordinateSystem(g, cs);

            offset = draw.Draw();

            drawingGraphics?.Draw(numbers, new RectangleF(offset.X, -offset.Y,
                pictureBox1.Width, pictureBox1.Height), graphicsSignature, g);
        }
    }
}
