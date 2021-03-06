﻿using System;
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
    /// <summary>
    /// Форма каде се појава играта
    /// </summary>
    public partial class FinkiWAR : Form
    {
        /// <summary>
        /// Сцена каде се движаат непријателите и Авионот
        /// </summary>
        private Scene scene;

        /// <summary>
        /// Додавање на непријатели
        /// </summary>
        private int generateBall;

        /// <summary>
        /// Рандом место за појава на непријателот
        /// </summary>
        private Random random;

        /// <summary>
        /// Тајмер за брзината на генерирање на непријатели
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Левели после пукнати неколку непријатели
        /// </summary>
        /// 
        private int level;

        /// <summary>
        /// Најмногу пукнати непријатели
        /// Играта започнува на Левел 1
        /// Интервалот за генерирање непријатели е 100милисекунди
        /// Додавање на авионот во сцена
        /// </summary>
        public HighScore highscore;
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
            highscore = new HighScore();
        }

        /// <summary>
        /// Се што треба да се прави по секоја 100 милисекунда.
        /// Сума на пукнати непријатели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            if (generateBall % 10 == 0)
            {
                int x = random.Next(2 * Enemy.RADIUS, Width - (Enemy.RADIUS * 2));
                int y = -Enemy.RADIUS;
                scene.AddBall(new Point(x, y));
                lblScore.Text = string.Format("Score : {0}", scene.killedBalls.ToString());
                highscore.score = scene.killedBalls;
            }
            if (scene.finish)
            {
                timer.Stop();
                highscore.score = scene.killedBalls;
                DialogResult = System.Windows.Forms.DialogResult.OK;
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


        /// <summary>
        /// По претискување на копчето десно или лево  авионот се движе на таа насока
        /// По претискување на копчето SPACE се пука од авинот на кај непријателите
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Во статус-бар се појавува Левелот и брзината на која доаѓаат непријателите
        /// По секој 10 пукнати непријателите Левелот се зголемува за 1 , а брзината за 100km/h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusStrip1_Paint_1(object sender, PaintEventArgs e)
        {
            level = scene.killedBalls / 10 + 1;
            if (level < 10)
            {
                scene.speed = level + 5;
            }
            else
            {
                scene.speed = level + 1;
            }
            stsLevel.Text = string.Format("Level : {0} \t Enemies are comming with : {1} km\\h", level , level*100 );
        }
    }
}


