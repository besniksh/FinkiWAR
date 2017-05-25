using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    public class Airplane : Shape
    {
        /// <summary>
        /// Големината на Авинот
        /// </summary>
        public int width { get; set; }
        public int height { get; set; }

        public Airplane(Point Position, int width, int height)
        {
            this.Position = Position;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Цртање на авионот
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, Position.X - (width/2), Position.Y - (height/2), width, height);
            b.Dispose();
        }

        /// <summary>
        /// Движење на лево за 15 пиксели
        /// </summary>
        public void MoveLeft() {
            Position = new Point(Position.X - 15, Position.Y);
        }

        /// <summary>
        /// движење на десно за 15 пиксели
        /// </summary>
        public void MoveRight()
        {
            Position = new Point(Position.X + 15, Position.Y);
        }

        
     }
}
