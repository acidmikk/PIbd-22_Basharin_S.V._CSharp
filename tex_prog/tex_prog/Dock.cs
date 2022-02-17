using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsShip
{
    class Parking<T> where T : class, ITransport
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private readonly T[] _places;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 210;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 150;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public Parking(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new T[width * height];
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }
        public static int operator +(Parking<T> p, T ship)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p._places[i] == null)
                {
                    p._places[i] = ship;
                    return i;
                }
            }
            return -1;
        }
        public static T operator -(Parking<T> p, int index)
        {
            if (index <= p._places.Length)
            {
                T result = p._places[index];
                p._places[index] = null;
                return result;
            }
            return null;
        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            int widthParam = pictureWidth / _placeSizeWidth;
            int heightParam = pictureHeight / _placeSizeHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i]?.SetPosition(i % widthParam * _placeSizeWidth + 15, heightParam + i / heightParam * _placeSizeHeight + 5, pictureWidth, pictureHeight);
                _places[i]?.DrawTransport(g);
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i *
                   _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
               (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _places.Length)
                {
                    return null;
                }
                else return _places[index];
            }
            set
            {
                if (_places.Length >= index)
                {
                    _places[index] = value;
                }
            }
        }
    }
}

