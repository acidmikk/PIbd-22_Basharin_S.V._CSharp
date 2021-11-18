using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsShip
{
    public interface ITransport
    {
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        void SetPosition(int x, int y, int width, int height);

        /// <param name="direction">Направление</param>
        void MoveTransport(Direction direction);

        /// <param name="g"></param>
        void DrawTransport(Graphics g);
    }
}
