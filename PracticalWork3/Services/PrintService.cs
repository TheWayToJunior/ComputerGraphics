using PracticalWork3.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork3.Services
{
    public interface IPrintService
    {
        void DrawText(Graphics graphics, BaseText text, int x, int y);

        void DrawText(Graphics graphics, IEnumerable<BaseText> texts, Point startPoint);
    }

    public sealed class PrintService : IPrintService
    {
        private readonly Size size;

        public PrintService(Control control)
        {
            this.size = control.Size;
        }

        public void DrawText(Graphics graphics, BaseText text, int x, int y)
        {
            StringFormat format = StringFormat.GenericTypographic.Clone() as StringFormat;

            format.Alignment = text.Alignment;
            format.LineAlignment = text.LineAlignment;
            format.FormatFlags = text.FormatFlags | StringFormatFlags.NoClip;

            Rectangle rectangle = new Rectangle(x, y, size.Width, size.Height);

            graphics.DrawString(text.Value, new Font(text.FontFamily, text.FontSize, FontStyle.Bold),
                Brushes.Black, rectangle, format);
        }

        public void DrawText(Graphics graphics, IEnumerable<BaseText> texts, Point startPoint)
        {
            foreach (var text in texts)
            {
                if (text.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical))
                {
                    DrawText(graphics, text, startPoint.X, 0);

                    if(text.FormatFlags.HasFlag(StringFormatFlags.DirectionRightToLeft))
                        startPoint.X -= (int)text.FontSize;
                    else
                        startPoint.X += (int)text.FontSize;
                }
                else
                {
                    startPoint.X = 0;

                    DrawText(graphics, text, startPoint.X, startPoint.Y);
                }

                startPoint.Y += (int)text.FontSize;
            }
        }
    }
}
