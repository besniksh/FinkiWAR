using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    abstract public class Shape
    {
        public Point Position { get; set; }

        public bool Touches(Shape b)
        {
            return (Position.X - b.Position.X) * (Position.X - b.Position.X) + (Position.Y - b.Position.Y) * (Position.Y - b.Position.Y) <= Enemy.RADIUS * Enemy.RADIUS;
        }

        public bool TouchesPlane(Shape b)
        {
            return (Position.X - b.Position.X) * (Position.X - b.Position.X) + (Position.Y - b.Position.Y) * (Position.Y - b.Position.Y) <= Enemy.RADIUS * Enemy.RADIUS * 2;
        }
    }
}
