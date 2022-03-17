using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace WindowsFormsShip
{
    class Dock<T> : IEnumerator<T>, IEnumerable<T>
        where T : class, ITransport
    {
        private readonly List<T> _places;
        private readonly int _maxCount;
        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private readonly int _placeSizeWidth = 210;
        private readonly int _placeSizeHeight = 150;

        private int _currentIndex;
        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];

        public Dock(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _places = new List<T>();
            _currentIndex = -1;
        }

        public static bool operator +(Dock<T> p, T ship)
        {
            if (p._places.Count >= p._maxCount)
            {
                throw new DockOverflowException();
            }
            if (p._places.Contains(ship))
            {
                throw new ParkingAlreadyHaveException();
            }
            p._places.Add(ship);
            return true;
        }

        public static T operator -(Dock<T> p, int index)
        {
            if (index < -1 || index > p._places.Count)
            {
                throw new DockNotFoundException(index);
            }
            T car = p._places[index];
            p._places.RemoveAt(index);
            return car;
        }

        public void Draw(Graphics g)
        {
            DrawMarking(g);
            int widthParam = pictureWidth / _placeSizeWidth;
            int heightParam = pictureHeight / _placeSizeHeight;
            for (int i = 0; i < _places.Count; i++)
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

        public T GetNext(int index)
        {
            if (index < 0 || index >= _places.Count)
            {
                return null;
            }
            return _places[index];
        }
        public void Sort() => _places.Sort((IComparer<T>)new ShipComparer());
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            if ((_currentIndex + 1) >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }
        public void Reset()
        {
            _currentIndex = -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}

