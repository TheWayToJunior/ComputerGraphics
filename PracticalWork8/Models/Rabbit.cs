using System.Drawing;

namespace PracticalWork8.Models
{
    public class Rabbit : DynamicGameObject
    {
        public Rabbit()
            : base("rabbit.png", new RectangleF(5, 60, 50, 50))
        {
        }
    }
}
