using System;
using System.Drawing;

namespace PracticalWork4.Models
{
    public class CoordinateSystem
    {
        public CoordinateSystem(CoordinateAxisX axisX, CoordinateAxisY axisY)
        {
            this.AxisX = axisX;
            this.AxisY = axisY;

            this.Signature = new CoordinateSystemSignature();
        }

        public CoordinateAxisX AxisX { get; private set; }

        public CoordinateAxisY AxisY { get; private set; }

        public CoordinateSystemSignature Signature { get; set; }

        public bool IsSigned { get; set; } = true;
    }
}
