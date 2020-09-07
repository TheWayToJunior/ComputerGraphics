using System.Drawing;

namespace PracticalWork3.Models
{
    public abstract class BaseText
    {
        public BaseText(string value, Font font, StringFormatFlags formatFlags,
            StringAlignment alignment, StringAlignment lineAlignment)
        {
            Value = value;
            FontFamily = font.FontFamily.Name;
            FontSize = font.Size;
            FormatFlags = formatFlags;
            Alignment = alignment;
            LineAlignment = lineAlignment;
        }

        public string Value { get; set; }

        public string FontFamily { get; set; }

        public float FontSize { get; set; }

        public StringFormatFlags FormatFlags { get; set; }

        public StringAlignment Alignment { get; set; }

        public StringAlignment LineAlignment { get; set; }
    }
}
