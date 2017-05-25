using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace FinkiWAR
{
    public class Bullet : Shape
    {
        
        /// <summary>
        /// Големината на коршумот
        /// </summary>
        public static readonly int RADIUS = 5;

        /// <summary>
        /// Цртање на коршум
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Yellow);
            g.FillEllipse(b, Position.X - RADIUS, Position.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

       /// <summary>
       ///  Движење на куршуми кон непријатели
       /// </summary>
        public void Move()
        {
            Position = new Point(Position.X, Position.Y - 20);
        }

    }
}
