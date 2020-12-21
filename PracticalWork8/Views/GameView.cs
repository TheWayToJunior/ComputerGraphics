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

        List<Rabbit> rabbits;
        int count = 0;

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

                CountFrames = 3,
                CountSprites = 3
            };

            _player = new Player(_wolf);

            rabbits = new List<Rabbit>() 
            {
                new Rabbit()
                {
                    Point = new PointF(350, 300),
                    Size = new SizeF(65, 65)
                },
                new Rabbit()
                {
                    Point = new PointF(650, 410),
                    Size = new SizeF(65, 65)
                },
                new Rabbit()
                {
                    Point = new PointF(730, 150),
                    Size = new SizeF(65, 65)
                }
            };
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

        private void GamePaint(object sender, PaintEventArgs e)
        {
            _timer.Enabled = true;
            Text = count.ToString();

            float x = 0, y = 0;

            Rabbit temp = null;

            foreach (var item in rabbits)
            {
                x = _wolf.Point.X - item.Point.X;
                y = _wolf.Point.Y - item.Point.Y;

                if ((x < 20 && x > -20 && y < 20 && y > -20))
                    temp = item;
            }

            if(temp != null)
            {
                rabbits.Remove(temp);
                count++;
            }

            foreach (var item in rabbits)
            {
                item.Draw(e.Graphics);
            }

            _wolf.Draw(e.Graphics);
        }
    }
}
