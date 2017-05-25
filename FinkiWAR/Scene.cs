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
        public List<Enemy> Enemies { get; set; }
        public List<Bullet> Bullets { get; set; }
        public Airplane airplane;

        public int speed { get; set; }
        public int width;
        public int height;

        public bool finish = false;
        public int killedBalls;

        

        public Scene(int width, int height)
        {
            this.width = width;
            this.height = height;

            Enemies = new List<Enemy>();
            Bullets = new List<Bullet>();
            killedBalls = 0;
            speed = 10;
        }

        public void AddBall(Point Position)
        {
            Enemy b = new Enemy(speed);
            b.Position = Position;
            Enemies.Add(b);
        }

        public void AddBullet(Point Position)
        {
            PlayBulletSound();
            Bullet bullet = new Bullet();
            bullet.Position = Position;
            Bullets.Add(bullet);
        }

        public void PlayBulletSound()
        {
            SoundPlayer bulletSound = new SoundPlayer(@"C:\Users\besni\Desktop\bullet.wav");
            bulletSound.Play();
        }

        public void AddAirPlane()
        {
            airplane = new Airplane(new Point(220, 510), 50, 25);
        }

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

        public void MoveLeft()
        {
            if (airplane.Position.X - airplane.width/2 > 0)
            {
                airplane.MoveLeft();
            }
        }

        public void MoveRight()
        {
            if (airplane.Position.X + airplane.width / 2  < width-15)
            {
                airplane.MoveRight();
            }
        }

        


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


        


    
       

