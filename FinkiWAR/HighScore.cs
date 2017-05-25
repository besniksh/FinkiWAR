using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiWAR
{
    
    public class HighScore
    {
        /// <summary>
        /// Најмногу пукнати непријатели
        /// </summary>
        public int score;

        public override string ToString()
        {
            return string.Format("{0}",score);
        }
    }
}
