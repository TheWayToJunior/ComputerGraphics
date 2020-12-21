using System.Drawing;

namespace PracticalWork8.Models
{
    public interface IMoveStrategy
    {
        PointF Move(PointF point, float speed);
    }
}
