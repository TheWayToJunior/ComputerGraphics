using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PracticalWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            pictureBox1.Paint += DrawCoordinateSystem;

            btnPixel.Click += PixelClick;
            btnMillimeter.Click += MillimeterClick;
            btnInch.Click += InchClick;

            btnClear.Click += Clear;
        }

        private void Clear(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void PixelClick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            DrawСhart(pictureBox1.Width, pictureBox1.Height, GraphicsUnit.Pixel);
        }

        private void MillimeterClick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            DrawСhart(pictureBox1.Width / 3.794f, pictureBox1.Height / 3.794f, GraphicsUnit.Millimeter, 0.5f);
        }

        private void InchClick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            DrawСhart(pictureBox1.Width / 96.358f, pictureBox1.Height / 96.358f, GraphicsUnit.Inch, 0.05f);
        }

        private void DrawСhart(float width, float height, GraphicsUnit unit, float scale = 1)
        {
            var graphics = pictureBox1.CreateGraphics();
            graphics.PageUnit = unit;

            graphics.TranslateTransform(width / 2, height / 2);
            graphics.ScaleTransform(scale, scale);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var pen = new Pen(Color.Red, 1f);

            graphics.DrawCurve(pen, SolveExpression((x) => x * 3 + x - 4, start: -20f, end: 20f)
                .ToArray());
        }

        private IEnumerable<PointF> SolveExpression(Func<float, float> func, float start, float end)
        {
            var points = new List<PointF>();

            for (float i = start; i < end; i++)
            {

                points.Add(new PointF
                {
                    X = i,
                    Y = func.Invoke(i)
                });
            }

            return points;
        }

        private void DrawCoordinateSystem(object sender, PaintEventArgs args)
        {
            var graphics = args.Graphics;

            var control = sender as Control;

            var width = control.Size.Width;
            var height = control.Size.Height;

            graphics.DrawRectangle(
                Pens.Black,
                new Rectangle(new Point(0, 0),
                new Size(width - 1, height - 1)));

            graphics.DrawLine(
                Pens.Black,
                new Point(width / 2, 0),
                new Point(width / 2, height));

            graphics.DrawLine(
                Pens.Black,
                new Point(0, height / 2),
                new Point(width, height / 2));
        }
    }
}
