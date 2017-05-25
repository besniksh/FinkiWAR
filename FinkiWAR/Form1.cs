using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace FinkiWAR
{
    public partial class FinkiWAR : Form
    {
        private Scene scene;
        private int generateBall;
        private Random random;
        private Timer timer;
        private int level;
        public FinkiWAR()
        {
            InitializeComponent();
            scene = new Scene(Width,Height);
            generateBall = 0;
            level = 1;
            random = new Random();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            DoubleBuffered = true;
            scene.AddAirPlane();
        }

        
        void timer_Tick(object sender, EventArgs e)

        {

            if (generateBall % 10 == 0)
            {
                int x = random.Next(2 * Enemy.RADIUS, Width - (Enemy.RADIUS * 2));
                int y = -Enemy.RADIUS;
                scene.AddBall(new Point(x, y));
                lblScore.Text = string.Format("Score : {0}", scene.killedBalls.ToString());
            }
            if (scene.finish)
            {
                timer.Stop();
                string Message = string.Format("        GAME OVER!! \n\n Your killed {0} enemies!! \n You reached level : {1}", scene.killedBalls.ToString(), level);
                MessageBox.Show(Message);
            }
            ++generateBall;
            scene.MoveBullets();
            scene.Move(Width);
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Navy);
            scene.Draw(e.Graphics);
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Left)
             {
                 scene.MoveLeft();
             }

             else if (e.KeyCode == Keys.Space)
             {
                 scene.AddBullet(new Point(scene.getX(), scene.getY() - 5));

             }
             else if (e.KeyCode == Keys.Right)
             {
                 scene.MoveRight();
             }
             Invalidate(true);
        }



        private void statusStrip1_Paint_1(object sender, PaintEventArgs e)
        {
            level = scene.killedBalls / 10 + 1;
            scene.speed = level + 5;
            stsLevel.Text = string.Format("Level : {0} \t Enemies are comming with : {1} km\\h", level , level*100 );
        }
    }
}


