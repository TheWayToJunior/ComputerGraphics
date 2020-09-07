using System;
using System.Drawing;

namespace PracticalWork3.Models
{
    [Serializable]
    public class TextModel : BaseText
    {
        public TextModel(string value, Font font)
            : this(value, font, StringFormatFlags.NoWrap)
        {
        }

        public TextModel(string value, Font font, StringAlignment alignment, StringAlignment lineAlignment)
            : base(value, font, StringFormatFlags.NoWrap, alignment, lineAlignment)
        {
        }

        public TextModel(string value, Font font, StringFormatFlags flags)
            : base(value, font, flags, StringAlignment.Near, StringAlignment.Near)
        {
        }

        public TextModel(string value, Font font, StringFormatFlags formatFlags,StringAlignment alignment, StringAlignment lineAlignment)
            : base(value, font, formatFlags, alignment, lineAlignment)
        {
        }
    }
}
