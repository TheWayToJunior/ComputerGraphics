using PracticalWork4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PracticalWork4
{
    public partial class Form1 : Form
    {
        private Offset offset;

        int max;
        int[] numbers;

        Random rnd = new Random((int)DateTime.Now.Ticks);

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += PictureBox1_Paint;
            button1.Click += Button1_Click;

            this.Resize += (s, e) => pictureBox1.Refresh();

            numbers = Enumerable.Range(-5, 31).OrderBy(r => rnd.Next()).ToArray();
            max = numbers.Max();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            var listPoints = new List<PointF>();

            var g = pictureBox1.CreateGraphics();
            g.TranslateTransform(offset.X, offset.Y);

            var p = new Pen(Color.Green, 3);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            /// TODO: Encapsulate logic in a separate class DrawingGraphics
            float indentX = (float)(pictureBox1.Width - (24 + 10)) / (numbers.Count() * 10);
            float indentY = (pictureBox1.Height / 2 - 10) / (numbers.Count() * 10f);

            for (int i = 1; i < numbers.Count() + 1; i++)
            {
                float x = i * 10 * indentX;
                float y = (-numbers[i - 1] * 10) / ((float)max / numbers.Count()) * indentY;

                listPoints.Add(new PointF(x, y));

                g.DrawEllipse(Pens.Blue, x - 2.5f, y - 2.5f, 5f, 5f);
                g.DrawString(numbers[i - 1].ToString(), new Font("Arial", 10), Brushes.Blue, x + 5, y);
            }

            g.DrawLines(p, listPoints.ToArray());
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var x = new CoordinateAxisX(minValue: 0, maxValue: 31, countPoints: 31);
            var y = new CoordinateAxisY(minValue: -max, maxValue: max, countPoints: 15);

            var cs = new Models.CoordinateSystem(x, y);

            cs.Signature = new Models.CoordinateSystemSignature
            {
                Brush = Brushes.Red,
                Font = new Font("Arial", 10),
            };

            var draw = new DrawingСoordinateSystem(g, cs);

            offset = draw.Draw();
        }
    }
}
