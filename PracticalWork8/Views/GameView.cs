using PracticalWork8.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork8
{
    public partial class GameView : Form
    {
        private Timer _timer = new Timer();

        private Wolf _wolf;
        private Player _player;

        private List<GameObject> _gameObjects;
        private int _count = 0;

        public GameView()
        {
            InitializeComponent();

            DoubleBuffered = true;

            pbMain.Paint += GamePaint;

            _timer.Interval = 85;

            _timer.Tick += TimerTick;
            this.KeyUp += GameView_KeyUp;
            this.KeyDown += GameView_KeyDown;

            _wolf = new Wolf(spriteWidth: 50, spriteHeight: 81)
            {
                Size = new SizeF(width: 50, height: 81),
                Gap = new Gap(sprites: 0, frames: 6),
                Point = new PointF(350, 70),

                CountFrames = 4,
                CountSprites = 4
            };

            _gameObjects = new List<GameObject>()
            {
                new Rabbit()
                {
                    Point = new PointF(350, 300),
                    Size = new SizeF(50, 50)
                }
            };

            _player = new Player(_wolf);
        }

        private void GameView_KeyUp(object sender, KeyEventArgs e)
        {
            _player.RemoveKey(e.KeyCode);
            _player.Control(_player.LastDownKey);
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            _player.Control(e.KeyCode);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _player.Move();
            pbMain.Invalidate();
        }

        Random random = new Random(DateTime.Now.Second);
        RandomMova randomMova = new RandomMova();

        private void GamePaint(object sender, PaintEventArgs e)
        {
            _timer.Enabled = true;
            Text = _count.ToString();

            #region Perform refactoring
            /// To do it in a separate class

            GameObject temp = null;

            foreach (var item in _gameObjects)
            {
                if (_wolf.DescRectangle.IntersectsWith(item.DescRectangle))
                    temp = item;
            }

            if (temp != null)
            {
                _gameObjects.Remove(temp);
                _count++;

                _gameObjects.Add(new Rabbit()
                {
                    Point = new PointF(random.Next(250, 380), random.Next(300, 450)),
                    Size = new SizeF(50, 50)
                });
            }

            foreach (var item in _gameObjects)
            {
                (item as IMoveable)?.Move(randomMova);
                item.Draw(e.Graphics);

                //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point((int)item.DescRectangle.X, (int)item.DescRectangle.Y),
                    //new Size((int)item.DescRectangle.Width, (int)item.DescRectangle.Height)));
            }

            #endregion

            _wolf.Draw(e.Graphics);
        }
    }
}
