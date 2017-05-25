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
    public partial class Welcome : Form
    {
        private bool started = false;
        public Welcome()
        {
            InitializeComponent();
            lblAuthors.Text = "Authors: \nBesnik Shabani and Semir Sinani";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinkiWAR game = new FinkiWAR();
            game.ShowDialog();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
