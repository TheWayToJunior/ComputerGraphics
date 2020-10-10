using PracticalWork4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PracticalWork4
{
    public class DrawingGraphics
    {
        private Graphics graphics;

        public DrawingGraphics(Graphics graphics)
        {
            this.graphics = graphics ??
                throw new ArgumentNullException(nameof(graphics), "The Graphics cannot be empty");
        }

        public void Draw(int[] numbers, RectangleF rectangle, GraphicsSignature signature, Graphics graphics)
        {
            var tempGraphics = this.graphics;
            this.graphics = graphics;

            Draw(numbers, rectangle, signature);

            this.graphics = tempGraphics;
        }

        public void Draw(int[] numbers, RectangleF rectangle, GraphicsSignature signature)
        {
            float indentX = (rectangle.Width - (rectangle.X + signature.Font.Size)) / (numbers.Count() * signature.Font.Size);
            float indentY = (rectangle.Height / 2 - signature.Font.Size) / (numbers.Count() * signature.Font.Size);

            var listPoints = new List<PointF>();

            float pointSize = signature.Font.Size / 2;

            for (int i = 1; i < numbers.Count() + 1; i++)
            {
                float x = i * signature.Font.Size * indentX;
                float y = -numbers[i - 1] * signature.Font.Size /
                    ((float)numbers.Max(itr => Math.Abs(itr)) / numbers.Count()) * indentY;

                listPoints.Add(new PointF(x, y));

                graphics.DrawEllipse(signature.EllipsePen, x - pointSize / 2, y - pointSize / 2,
                    pointSize, pointSize);

                graphics.DrawString(numbers[i - 1].ToString(), signature.Font,
                    signature.Brush, x + pointSize, y);
            }

            graphics.DrawLines(signature.Pen, listPoints.ToArray());
        }
    }
}
