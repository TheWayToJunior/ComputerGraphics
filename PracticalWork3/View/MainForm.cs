using PracticalWork3.Abstractions;
using PracticalWork3.Factory;
using PracticalWork3.Models;
using PracticalWork3.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PracticalWork3
{
    public partial class MainForm : Form
    {
        private readonly SerializationService serializationService;
        private readonly IPrintService printService;
        private readonly Point startPoint;

        private List<BaseText> texts;

        public MainForm()
        {
            InitializeComponent();

            this.startPoint = new Point(0, 0);
            this.texts = new List<BaseText>();

            this.printService = new PrintService(pictureBox1);

            this.serializationService = new SerializationService($"{AppDomain.CurrentDomain.BaseDirectory}data.xml");

            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}data.xml"))
                this.texts.AddRange(this.serializationService.Deserialize<BaseText[]>());
        }

        private void CreateAndPrintText()
        {
            pictureBox1.Refresh();

            var font1 = new Font("Times New Roman", 36f, FontStyle.Italic);
            var font2 = new Font("Magneto", 24f, FontStyle.Bold);
            var font3 = new Font("Cambria", 48f, FontStyle.Regular);

            var horizontalFactory = new HorizontalTextFactory();
            var verticalFactory   = new VerticalTextFactory();

            var textCreator = new TextCreator();

            texts.AddRange(textCreator.Create(horizontalFactory, "Hello world", font1, StringAlignment.Near, 6));
            texts.AddRange(textCreator.Create(verticalFactory,   "Hello world", font2, StringAlignment.Far, 5));
            texts.AddRange(textCreator.Create(horizontalFactory, "Hello world", font3, StringAlignment.Center, 1));

            this.printService.DrawText(pictureBox1.CreateGraphics(), texts, startPoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (texts.Any())
                printService.DrawText(pictureBox1.CreateGraphics(), texts, startPoint);
            else
                CreateAndPrintText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serializationService.Serialize(texts.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
