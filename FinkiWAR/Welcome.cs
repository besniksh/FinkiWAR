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
    public partial class Welcome_FinkiWAR : Form
    {
        private bool started = false;
        public int highscore;
        public int score;
        public Welcome_FinkiWAR()
        {
            InitializeComponent();
            highscore = 0;
            score = 0;
            lblAuthors.Text = "Authors: \nBesnik Shabani and Semir Sinani";
            lblRecord.Text = string.Format("Highscore : {0}", highscore);
        }

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
