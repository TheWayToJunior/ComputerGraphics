using PracticalWork4.Models;
using System;
using System.Drawing;

namespace PracticalWork4
{
    public class DrawingСoordinateSystem
    {
        private readonly Graphics graphics;
        private readonly CoordinateSystem system;

        public DrawingСoordinateSystem(Graphics graphics, CoordinateSystem system)
        {
            this.graphics = graphics ??
                throw new ArgumentNullException(nameof(graphics), "The Graphics cannot be empty");

            this.system = system     ?? 
                throw new ArgumentNullException(nameof(system), "The CoordinateSystem cannot be empty");
        }

        public Offset Draw()
        {
            Offset offset = new Offset(24, (int)graphics.ClipBounds.Height / 2);

            graphics.TranslateTransform(0, offset.Y);

            DrawLines(system.Signature.Pen, 
                Convert.ToInt32(offset.X),
                Convert.ToInt32(-offset.Y),
                Convert.ToInt32(graphics.ClipBounds.Width),
                Convert.ToInt32(graphics.ClipBounds.Height));

            if (system.IsSigned)
            {
                DrawSignatureX(system.AxisX, system.Signature);
                DrawSignatureY(system.AxisY, system.Signature);
            }

            graphics.TranslateTransform(offset.X, 0);

            return offset;
        }

        private void DrawSignatureX(CoordinateAxisX axisX, CoordinateSystemSignature signature)
        {
            int countPoints = axisX.CountPoints;

            float dx = signature.Font.Size,
                  dy = signature.Font.Size;

            var settings = new DrawSettings(graphics.ClipBounds.Width - (24 + signature.Font.Size),
                countPoints, axisX.MaxValue, new Direction(dx, dy))
            {
                StartPoint = 1,
                StartValue = 1,
                Offset = new Offset(24, 0)
            };

            DrawSignature(settings, axisX, signature);
            DrawMarkX(settings, axisX, signature);
        }

        private void DrawSignatureY(CoordinateAxisY axisY, CoordinateSystemSignature signature)
        {
            int countPints = axisY.CountPoints / 2;

            float dx = signature.Font.Size, 
                  dy = signature.Font.Size;

            float lineWight = graphics.ClipBounds.Height / 2;

            var positivePart = new DrawSettings(lineWight - signature.Font.Size,
                countPints, axisY.MaxValue, new Direction(dx, -dy));

            var negativePart = new DrawSettings(lineWight - signature.Font.Size,
                countPints, axisY.MinValue, new Direction(dx, dy));

            DrawSignature(positivePart, axisY, signature);
            DrawSignature(negativePart, axisY, signature);
        }

        private void DrawSignature(DrawSettings settings, CoordinateAxis axis, CoordinateSystemSignature signature)
        {
            float value = settings.StartValue;
            float indent = settings.LineWidth / (settings.CountPoints * signature.Font.Size);

            for (int i = settings.StartPoint; i <= settings.CountPoints; i++,
                value += (float)settings.MaxValue / (float)settings.CountPoints)
            {
                (float x, float y) = axis.SettingScale(settings.Direction.X, settings.Direction.Y, indent, i);

                graphics.DrawString(Convert.ToInt32(value).ToString(), signature.Font,
                    signature.Brush, x + settings.Offset.X, y + settings.Offset.Y, signature.StringFormat);
            }
        }

        private void DrawMarkX(DrawSettings settings, CoordinateAxisX axis, CoordinateSystemSignature signature)
        {
            float indent = settings.LineWidth / (settings.CountPoints * signature.Font.Size);

            for (int i = 0; i <= settings.CountPoints; i++)
            {
                (float x, float y) = axis.SettingScale(settings.Direction.X, settings.Direction.Y, indent, i);

                graphics.DrawLine(signature.Pen, x + settings.Offset.X, -2 + settings.Offset.Y, 
                    x + settings.Offset.X, 2 + settings.Offset.Y);
            }
        }

        private void DrawLines(Pen pen, int shiftX, int shiftY, int width, int height)
        {
            graphics.DrawLine(pen, new Point(shiftX, shiftY),
                new Point(shiftX, height - 1));

            graphics.DrawLine(pen, new Point(shiftX, 0),
                new Point(width - 1, 0));
        }
    }
}
