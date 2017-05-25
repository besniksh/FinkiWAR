using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace FinkiWAR
{
    public class Bullet : Shape
    {
        public static readonly int RADIUS = 5;

        
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Yellow);
            g.FillEllipse(b, Position.X - RADIUS, Position.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

        public void Move()
        {
            Position = new Point(Position.X, Position.Y - 10);
        }

    }
}
