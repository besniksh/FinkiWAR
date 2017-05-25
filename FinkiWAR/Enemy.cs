using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    public class Enemy : Shape
    {
        public static readonly int RADIUS = 30;

        public int ColorRnd { get; set; }

        public int speed { get; set; }
        public int hits { get; set; }
        public Enemy(int speed)
        {
            Random r = new Random();
            ColorRnd = r.Next(3);
            this.speed = speed;
        }

        public void Move()
        {
            Position = new Point(Position.X, Position.Y + speed);
        }

        public void Draw(Graphics g)
        {
            Brush b = null;
            if (ColorRnd == 0)
            {
                b = new SolidBrush(Color.Black);
            }
            else if (ColorRnd == 1)
            {
                b = new SolidBrush(Color.Blue);
            }
            else
            {
                b = new SolidBrush(Color.Red);
            }
            g.FillEllipse(b, Position.X - RADIUS, Position.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();

        }

        public bool OutOfBounds(int height)
        {
            if (Position.Y - RADIUS > height-100) return true;
            return false;
        }
    }
}
