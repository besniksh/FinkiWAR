using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;


namespace FinkiWAR
{
    public class Scene
    {
        /// <summary>
        /// Листа непријатели
        /// </summary>
        public List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Листа коршуми
        /// </summary>
        public List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Авинот
        /// </summary>
        public Airplane airplane;

        /// <summary>
        /// Брзина која доаѓаат непријателите
        /// </summary>
        public int speed { get; set; }

        /// <summary>
        /// Големината на формата
        /// </summary>
        public int width;
        public int height;

        /// <summary>
        /// Дали заври играта
        /// </summary>
        public bool finish = false;

        /// <summary>
        /// Погодени непријатели
        /// </summary>
        public int killedBalls;

        
        /// <summary>
        /// Констуирање на сцена
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Scene(int width, int height)
        {
            this.width = width;
            this.height = height;

            Enemies = new List<Enemy>();
            Bullets = new List<Bullet>();
            killedBalls = 0;
            speed = 10;
        }

        /// <summary>
        /// Додавање на непријател
        /// </summary>
        /// <param name="Position"></param>
        public void AddBall(Point Position)
        {
            Enemy b = new Enemy(speed);
            b.Position = Position;
            Enemies.Add(b);
        }

        /// <summary>
        /// Додавање на коршум
        /// </summary>
        /// <param name="Position"></param>
        public void AddBullet(Point Position)
        {
            PlayBulletSound();
            Bullet bullet = new Bullet();
            bullet.Position = Position;
            Bullets.Add(bullet);
        }

        /// <summary>
        /// Пукање (музика)
        /// </summary>
        public void PlayBulletSound()
        {
            SoundPlayer bulletSound = new SoundPlayer(@"laser1.wav");
            bulletSound.Play();
        }

        /// <summary>
        /// Додавања на Авионот
        /// </summary>
        public void AddAirPlane()
        {
            airplane = new Airplane(new Point(220, 510), 50, 25);
        }

        /// <summary>
        /// Движење на коршумите
        /// </summary>
        public void MoveBullets()
        {
            foreach (Bullet b in Bullets)
            {
                b.Move();
            }

            for (int i = Bullets.Count - 1; i >= 0; --i)
            {
                for (int j = Enemies.Count - 1; j >= 0; --j)
                {
                    if (Bullets[i].Touches(Enemies[j]))
                    {
                        Enemies.RemoveAt(j);
                        killedBalls++;
                    }
                }
            }
        }

        /// <summary>
        /// Движење на непријателите
        /// </summary>
        /// <param name="width"></param>
        public void Move(int width)
        {
            for (int i = Enemies.Count - 1; i >= 0; --i)
            {
                Enemies[i].Move();
                if (Enemies[i].OutOfBounds(height))
                {
                    finish = true;
                }
                if (Enemies[i].TouchesPlane(airplane))
                {
                    finish = true;
                }
            }
        }

        /// <summary>
        /// Цртање на сцената
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            airplane.Draw(g);
            foreach (Enemy b in Enemies)
            {
                b.Draw(g);
            }

            foreach (Bullet b in Bullets)
            {
                b.Draw(g);
            }
        }

        /// <summary>
        /// Авинот се движе на лево
        /// </summary>
        public void MoveLeft()
        {
            if (airplane.Position.X - airplane.width/2 > 0)
            {
                airplane.MoveLeft();
            }
        }

        /// <summary>
        /// Авионот се движе на десно
        /// </summary>
        public void MoveRight()
        {
            if (airplane.Position.X + airplane.width / 2  < width-15)
            {
                airplane.MoveRight();
            }
        }

        

        /// <summary>
        /// Моментална позиција на Авионот
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return airplane.Position.X;
        }

        public int getY()
        {
            return airplane.Position.Y;
        }


    }
}


        


    
       

