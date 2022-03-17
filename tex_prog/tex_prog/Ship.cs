﻿using System;
using System.Drawing;

namespace WindowsFormsShip
{
    public class Ship : Vehicle, IEquatable<Ship>
    {
        /// Ширина отрисовки автомобиля
        protected readonly int shipWidth = 150;
        /// Высота отрисовки автомобиля
        protected readonly int shipHeight = 70;
        protected readonly char separator = ';';
        ///
        protected readonly int standartHeight = 110;

        /// Конструктор
        public Ship(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public Ship(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }


        /// Конструкторс изменением размеров машины
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
        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }
        public bool Equals(Ship other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Ship shipObj))
            {
                return false;
            }
            else
            {
                return Equals(shipObj);
            }
        }
    }
}
