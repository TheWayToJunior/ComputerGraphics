using PracticalWork8.Models;

namespace PracticalWork8
{
    public interface IMoveable
    {
        bool IsMoved { get; set; }

        void Move(IMoveStrategy strategy);
    }
}
