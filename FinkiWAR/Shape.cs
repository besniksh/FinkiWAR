using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiWAR
{
    abstract public class Shape
    {
        /// <summary>
        /// Позиција на формата
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Дали коршумот го допира непријателот
        /// </summary>
        /// <param name="b">Фигура што во овој случај е Непротајелот (топка)</param>
        /// <returns></returns>
        public bool Touches(Shape b)
        {
            return (Position.X - b.Position.X) * (Position.X - b.Position.X) + (Position.Y - b.Position.Y) * (Position.Y - b.Position.Y) <= Enemy.RADIUS * Enemy.RADIUS;
        }

        /// <summary>
        /// Дали Непријателот го допира Авинот
        /// </summary>
        /// <param name="b">Авионот</param>
        /// <returns></returns>
        public bool TouchesPlane(Shape b)
        {
            return (Position.X - b.Position.X) * (Position.X - b.Position.X) + (Position.Y - b.Position.Y) * (Position.Y - b.Position.Y) <= Enemy.RADIUS * Enemy.RADIUS * 2;
        }
    }
}
