using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    public class Airplane : Shape
    {
        public int width { get; set; }
        public int height { get; set; }

        public Airplane(Point Position, int width, int height)
        {
            this.Position = Position;
            this.width = width;
            this.height = height;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, Position.X - (width/2), Position.Y - (height/2), width, height);
            b.Dispose();
        }

        public void MoveLeft() {
            Position = new Point(Position.X - 15, Position.Y);
        }


        public void MoveRight()
        {
            Position = new Point(Position.X + 15, Position.Y);
        }

        
     }
}
