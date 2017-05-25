using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinkiWAR
{
    /// <summary>
    /// Форма која се појавува најпрво
    /// </summary>
    public partial class Welcome_FinkiWAR : Form
    {

        /// <summary>
        /// Најмногу пукнати непријатели
        /// </summary>
        public int highscore;

        /// <summary>
        /// Пукнати непријатели од последна игра
        /// </summary>
        public int score;
        public Welcome_FinkiWAR()
        {
            InitializeComponent();
            highscore = 0;
            score = 0;
            lblAuthors.Text = " ";
            lblRecord.Text = string.Format("Highscore : {0}", highscore);
        }
        /// <summary>
        /// Клик на копчето Старт.
        /// Почеток на играта
        /// Се чека одговор од играта за Најмногу пукнати непријатели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FinkiWAR game = new FinkiWAR();
            if (game.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                score = game.highscore.score;
            }

            if (score > highscore)
            {
                highscore = score;
                
            }
            lblRecord.Text = string.Format("Highscore : {0}", highscore);
        }

        
    }
}
