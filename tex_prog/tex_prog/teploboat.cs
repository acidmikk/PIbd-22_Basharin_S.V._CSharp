using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tex_prog
{
    class teploboat
    {
        /// Класс отрисовки туплохода
        /// Левая координата отрисовки автомобиля
        private float _startPosX;

        /// Правая кооридната отрисовки автомобиля
        private float _startPosY;

        /// Ширина окна отрисовки
        private int _pictureWidth;

        /// Высота окна отрисовки
        private int _pictureHeight;

        /// Ширина отрисовки автомобиля
        private readonly int boatWidth = 150;

        /// Высота отрисовки автомобиля
        private readonly int boatHeight = 110;

        /// Максимальная скорость
        public int MaxSpeed { private set; get; }

        /// Вес автомобиля
        public float Weight { private set; get; }

        /// Основной цвет кузова
        public Color MainColor { private set; get; }

        /// Дополнительный цвет
        public Color DopColor { private set; get; }

        /// Признак наличия окон
        public bool Window { private set; get; }

        ///признак наличия линии
        public bool Line { private set; get; }

        ///признак наличия трубы
        public bool Trub { private set; get; }

        /// Инициализация свойств
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес теплохода</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="window">Признак наличия переднего спойлера</param>
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
                        bool window, bool line, bool trub)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Window = window;
            Line = line;
            Trub = trub;
        }

        /// Установка позиции автомобиля
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureHeight = height;
            _pictureWidth = width;
            if (_startPosX + boatHeight > width)
            {
                _startPosX = width - boatWidth;
            }  
            if (_startPosY + boatWidth > height)
            {
                _startPosY = height - boatHeight;
            }
        }
        /// Изменение направления пермещения
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - boatWidth)
                    {
                        _startPosX += step;
                    } else
                    {
                        _startPosX = _pictureWidth - boatWidth;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step >= 0)
                    {
                        _startPosX -= step;
                    } else
                    {
                        _startPosX = 0;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step >= 0)
                    {
                        _startPosY -= step;
                    } else
                    {
                        _startPosY = 0;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - boatHeight)
                    {
                        _startPosY += step;
                    } else
                    {
                        _startPosY = _pictureHeight - boatHeight;
                    }
                    break;
            }
        }

        /// Отрисовка лодки
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            Brush brush = new SolidBrush(MainColor);
            Brush brushDop = new SolidBrush(Color.Gray);
			g.DrawLine(pen, _startPosX, _startPosY + 60, _startPosX + 150, _startPosY + 60);
			g.DrawLine(pen, _startPosX+30, _startPosY + 110, _startPosX + 120, _startPosY + 110);
			g.DrawLine(pen, _startPosX, _startPosY + 60, _startPosX + 30, _startPosY + 110);
			g.DrawLine(pen, _startPosX+150, _startPosY + 60, _startPosX + 120, _startPosY + 110);

            if (Trub)
            {
                g.DrawRectangle(pen, _startPosX + 95, _startPosY, 20, 40);
                g.FillRectangle(brushDop, _startPosX + 96, _startPosY + 1, 19, 39);
                brushDop = new SolidBrush(DopColor);
            }
            g.DrawRectangle(pen, _startPosX + 30, _startPosY + 40, 90, 20);
			g.FillRectangle(brush, _startPosX + 31, _startPosY + 41, 89, 19);
            if (Line)
            {
                pen = new Pen(MainColor, 3);
                g.DrawLine(pen, _startPosX + 20, _startPosY + 90, _startPosX + 130, _startPosY + 90);
                pen = new Pen(Color.Black);
            }
			g.DrawLine(pen, _startPosX + 20, _startPosY + 75, _startPosX + 20, _startPosY + 90);
			g.DrawLine(pen, _startPosX + 15, _startPosY + 80, _startPosX + 25, _startPosY + 80);
			g.DrawLine(pen, _startPosX + 17, _startPosY + 90, _startPosX + 23, _startPosY + 90);
            if (Window)
            {
                g.DrawEllipse(pen, _startPosX + 40, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 70, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 100, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 100, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 70, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 40, _startPosY + 70, 10, 10);
            }
        }
    }
}
