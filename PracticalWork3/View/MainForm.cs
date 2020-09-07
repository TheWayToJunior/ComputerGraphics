using PracticalWork3.Abstractions;
using PracticalWork3.Models;
using PracticalWork3.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int countItem = 0;

        private IEnumerable<BaseText> Create(SmallFactory factory, string text, Font font, int count, StringAlignment alignment)
        {
            var list = new List<BaseText>();

            for (int i = 0; i < count; i++, countItem++)
            {
                list.Add(factory.Create($"{text} {countItem}", font, alignment));
            }

            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPrintService print = new PrintService(pictureBox1);

            var startPoint = new Point(0, 0);

            var font1 = new Font("Times New Roman", 36f, FontStyle.Italic);
            var font2 = new Font("Magneto", 24f, FontStyle.Bold);
            var font3 = new Font("Cambria", 48f, FontStyle.Regular);

            var texts = new List<BaseText>();

            var horizontalFactory = new HorizontalTextFactory();
            var verticalFactory = new VerticalTextFactory();

            texts.AddRange(Create(horizontalFactory, "Hello world", font1, 6, StringAlignment.Near));
            texts.AddRange(Create(verticalFactory,   "Hello world", font2, 5, StringAlignment.Far));
            texts.AddRange(Create(horizontalFactory, "Hello world", font3, 1, StringAlignment.Center));

            print.DrawText(startPoint, texts);
        }
    }
}
