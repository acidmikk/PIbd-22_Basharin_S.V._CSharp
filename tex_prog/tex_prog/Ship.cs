using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsShip
{
    public class Ship : Vihanicle
    {
        /// Ширина отрисовки автомобиля
        protected readonly int shipWidth = 150;
        /// Высота отрисовки автомобиля
        protected readonly int shipHeight = 70;

        ///
        protected readonly int standartHeight = 110;

        /// Конструктор
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Ship(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// Конструкторс изменением размеров машины
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="shipWidth">Ширина отрисовки автомобиля</param>
        /// <param name="shipHeight">Высота отрисовки автомобиля</param>
        protected Ship(int maxSpeed, float weight, Color mainColor, int shipWidth, int
        shipHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.shipWidth = shipWidth;
            this.shipHeight = shipHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - shipWidth)
                    {
                        _startPosX += step;
                    }
                    else
                    {
                        _startPosX = _pictureWidth - shipWidth;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step >= 0)
                    {
                        _startPosX -= step;
                    }
                    else
                    {
                        _startPosX = 0;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step >= -(standartHeight - shipHeight))
                    {
                        _startPosY -= step;
                    }
                    else
                    {
                        _startPosY = -(standartHeight - shipHeight);
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - shipHeight)
                    {
                        _startPosY += step;
                    }
                    else
                    {
                        _startPosY = _pictureHeight - shipHeight;
                    }
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(MainColor);
            g.DrawLine(pen, _startPosX, _startPosY + 60, _startPosX + 150, _startPosY + 60);
            g.DrawLine(pen, _startPosX + 30, _startPosY + 110, _startPosX + 120, _startPosY + 110);
            g.DrawLine(pen, _startPosX, _startPosY + 60, _startPosX + 30, _startPosY + 110);
            g.DrawLine(pen, _startPosX + 150, _startPosY + 60, _startPosX + 120, _startPosY + 110);

            g.DrawRectangle(pen, _startPosX + 30, _startPosY + 40, 90, 20);
            g.FillRectangle(brush, _startPosX + 31, _startPosY + 41, 89, 19);

            g.DrawLine(pen, _startPosX + 20, _startPosY + 75, _startPosX + 20, _startPosY + 90);
            g.DrawLine(pen, _startPosX + 15, _startPosY + 80, _startPosX + 25, _startPosY + 80);
            g.DrawLine(pen, _startPosX + 17, _startPosY + 90, _startPosX + 23, _startPosY + 90);
        }
    }
}
