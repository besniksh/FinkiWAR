using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    public class Enemy : Shape
    {
        /// <summary>
        /// Големината на Непријателот
        /// </summary>
        public static readonly int RADIUS = 30;
        
        /// <summary>
        /// Боја на непријателот од рандом број 0 ,1 или 2
        /// </summary>
        public int ColorRnd { get; set; }

        /// <summary>
        /// Бризината на непријателот
        /// </summary>
        public int speed { get; set; }
        public Enemy(int speed)
        {
            Random r = new Random();
            ColorRnd = r.Next(3);
            this.speed = speed;
        }

        /// <summary>
        /// Движење на непријателот надоле
        /// </summary>
        public void Move()
        {
            Position = new Point(Position.X, Position.Y + speed);
        }

        /// <summary>
        /// Цртање на Непријателот
        /// </summary>
        /// <param name="g"></param>
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

        /// <summary>
        /// Ако Непријателот стигне до доле без да биде пукнат
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool OutOfBounds(int height)
        {
            if (Position.Y - RADIUS > height-100) return true;
            return false;
        }
    }
}
