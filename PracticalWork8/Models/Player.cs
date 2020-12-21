using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Forms;

namespace PracticalWork8.Models
{
    public class Player
    {
        private ConcurrentDictionary<int, Keys> _keysDown 
            = new ConcurrentDictionary<int, Keys>();

        private readonly IMoveable _moveable;
        private IMoveStrategy direction;

        public Player(IMoveable moveable)
        {
            _moveable = moveable ?? throw new ArgumentNullException(nameof(moveable));
        }

        public void RemoveKey(Keys key)
        {
            _keysDown.TryRemove((int)key, out var _);
        }

        public Keys LastDownKey => _keysDown.LastOrDefault().Value;

        public bool IsMoved
        {
            get => _moveable.IsMoved;
        }

        public void Control(Keys key)
        {
            switch (key)
            {
                case Keys.W: 
                    direction = new Top(frame: 3); 
                    break;
                case Keys.S:
                    direction = new Bottom(frame: 0); 
                    break;
                case Keys.A: 
                    direction = new Left(frame: 1); 
                    break;
                case Keys.D: 
                    direction = new Right(frame: 2);
                    break;
                default: 
                    return;
            }

            _keysDown.TryAdd((int)key, key);
            _moveable.IsMoved = true;
        }

        public void Move()
        {
            if (!_keysDown.Any())
            {
                _moveable.IsMoved = false;
                return;
            }

            _moveable.Move(direction);
        }
    }
}
