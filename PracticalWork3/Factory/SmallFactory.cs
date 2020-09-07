using PracticalWork3.Models;
using System.Drawing;

namespace PracticalWork3.Abstractions
{
    public abstract class SmallFactory
    {
        public abstract BaseText Create(string value, Font font, StringAlignment alignment);
    }

    public sealed class HorizontalTextFactory : SmallFactory
    {
        public override BaseText Create(string value, Font font, StringAlignment alignment)
        {
            return new TextModel(value, font, alignment, StringAlignment.Near);
        }
    }

    public sealed class VerticalTextFactory : SmallFactory
    {
        public override BaseText Create(string value, Font font, StringAlignment alignment)
        {
            return new TextModel(value, font,
                StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft,
                alignment, StringAlignment.Near);
        }
    }
}
