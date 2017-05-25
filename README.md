# FinkiWAR

Семинарска Работа по Визуелно Програмирање

## Опис на проектот: 
Овој проект е  имплементација на игра именувана како FinkiWARS, каде што играчот командува вселенско летало кое се соочува со други непријателски вселенски бродови. Правила на играта се да не се дозволи ниту еден неприателски брод да помине неуништен.

Како што расте бројот на уништени бродови така расте и брзината со која доаѓат другите бродови, за секој 10 уништени бродови брзината се зголемува за 100km/h.

## Интерфејс и Функционалности:
При стартување на апликацијата се појавува мал прозорец со старт копче и информација за претходни рекорди.


![Screenshot 1](http://i.imgur.com/ONhxANf.png)


По притискање на ентер се отвара друг прозорец и играта почнува. Движењето на леталото се контролира со стрлеките за Left и Right, а за пукање се користи Space.

![Screenshot 2](http://i.imgur.com/c8sLjuP.png)
 

Во случај на судар на брод со брод или на некој избеган неуништен брод, играта завршува. Играчот добива порака во нов прозорец за бројот на уништени непријатели и за нивото кое е постигнато.


![Screenshot 3](http://i.imgur.com/6iTe0QQ.png)

Програмско решение:

За имплементација на ова игра задачата ја поделивме на неколку помали подпроблеми:
- **Цртање** на потребните објекти
- **Движење** на објекти (паѓање, летање итн.)
- **Колизија** 
- **Креирање** Нивоа и рекорди


За цртење на објектите користена абстрактна клас Shape од кое се наследени класите Airplane, Bullet и Enemy, Базната класа Shape содржи информација за позицијата на објектот, додека наследуваните класи содржат методи за цртање.

За движење на објектите се користат Моve методи кај трите наследени класи во зависност од тоа како се движи типот од таа класа.
```java
namespace FinkiWAR
{
    public class Airplane : Shape
    {
        /// <summary>
        /// Големината на Авинот
        /// </summary>
        public int width { get; set; }
        public int height { get; set; }

        public Airplane(Point Position, int width, int height)
        {
            this.Position = Position;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Цртање на авионот
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, Position.X - (width/2), Position.Y - (height/2), width, height);
            b.Dispose();
        }

        /// <summary>
        /// Движење на лево за 15 пиксели
        /// </summary>
        public void MoveLeft() {
            Position = new Point(Position.X - 15, Position.Y);
        }

        /// <summary>
        /// движење на десно за 15 пиксели
        /// </summary>
        public void MoveRight()
        {
            Position = new Point(Position.X + 15, Position.Y);
        }

        
     }
}

```
Колизијата се детектира преку две Touches методи на абстрактна класа Shape, овие методи се користат од страна на класата Scene во методите  Моve и МоveBullets. Преку овие методи се проверува дали дали куршумите ги погодувт непријателите и дали има судар помеѓу авионот и другите летала.

```java
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

```










