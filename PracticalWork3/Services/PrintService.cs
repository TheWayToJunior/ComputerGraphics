using PracticalWork3.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork3.Services
{
    public interface IPrintService
    {
        void DrawText(int x, int y, BaseText text);

        void DrawText(Point startPoint, IEnumerable<BaseText> texts);
    }

    public sealed class PrintService : IPrintService
    {
        private readonly Graphics graphics;

        public PrintService(Control control)
        {
            graphics = control.CreateGraphics();

            graphics.Clip = new Region(
                new Rectangle(control.ClientRectangle.X, control.ClientRectangle.Y,
                    control.ClientRectangle.Width, control.ClientRectangle.Height));
        }

        public void DrawText(int x, int y, BaseText text)
        {
            StringFormat format = StringFormat.GenericTypographic.Clone() as StringFormat;
            
            format.Alignment = text.Alignment;
            format.LineAlignment = text.LineAlignment;
            format.FormatFlags = text.FormatFlags | StringFormatFlags.NoClip;

            Rectangle rectangle = new Rectangle(x, y, (int)graphics.ClipBounds.Width, (int)graphics.ClipBounds.Height);

            graphics.DrawString(text.Value, new Font(text.FontFamily, text.FontSize, FontStyle.Bold), 
                Brushes.Black, rectangle, format);
        }

        public void DrawText(Point startPoint, IEnumerable<BaseText> texts)
        {
            foreach (var text in texts)
            {
                if (text.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical))
                {
                    DrawText(startPoint.X, 0, text);

                    if(text.FormatFlags.HasFlag(StringFormatFlags.DirectionRightToLeft))
                        startPoint.X -= (int)text.FontSize;
                    else
                        startPoint.X += (int)text.FontSize;
                }
                else
                {
                    startPoint.X = 0;

                    DrawText(startPoint.X, startPoint.Y, text);
                }

                startPoint.Y += (int)text.FontSize;
            }
        }
    }
}
