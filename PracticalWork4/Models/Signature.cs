using System.Drawing;

namespace PracticalWork4.Models
{
    public abstract class Signature
    {
        public Font Font { get; set; }

        public Brush Brush { get; set; }

        public Pen Pen { get; set; }

        public StringFormat StringFormat { get; set; }
    }

    public class GraphicsSignature : Signature
    {
        public GraphicsSignature()
        {
            base.Font = new Font("Arial", 10);
            base.Pen = Pens.Black;
            base.Brush = Brushes.Black;

            base.StringFormat = StringFormat.GenericTypographic.Clone() as StringFormat;

            this.EllipsePen = Pens.Blue;
        }

        public Pen EllipsePen { get; set; }
    }

    public class CoordinateSystemSignature : Signature
    {
        public CoordinateSystemSignature()
        {
            base.Font = new Font("Arial", 10);
            base.Pen = Pens.Black;
            base.Brush = Brushes.Black;

            base.StringFormat = StringFormat.GenericTypographic.Clone() as StringFormat;
            base.StringFormat.Alignment = StringAlignment.Center;
            base.StringFormat.LineAlignment = StringAlignment.Center;
        }
    }
}
