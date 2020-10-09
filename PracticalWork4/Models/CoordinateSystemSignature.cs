using System.Drawing;

namespace PracticalWork4.Models
{
    public class CoordinateSystemSignature
    {
        public CoordinateSystemSignature()
        {
            this.Font = new Font("Arial", 10);
            this.Pen = Pens.Black;
            this.Brush = Brushes.Black;

            this.StringFormat = StringFormat.GenericTypographic.Clone() as StringFormat;
            this.StringFormat.Alignment = StringAlignment.Center;
            this.StringFormat.LineAlignment = StringAlignment.Center;
        }

        public Font Font { get; set; }

        public Brush Brush { get; set; }

        public Pen Pen { get; set; }

        public StringFormat StringFormat { get; set; }
    }
}
