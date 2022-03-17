using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsShip
{
    public class Teploboat : Ship, IEquatable<Teploboat>
    {
        /// Дополнительный цвет
        public Color DopColor { private set; get; }

        /// Признак наличия окон
        public bool Window { private set; get; }

        ///признак наличия линии
        public bool Line { private set; get; }

        ///признак наличия трубы
        public bool Trub { private set; get; }

        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        /// <param name="sportLine">Признак наличия гоночной полосы</param>
        public Teploboat(int maxSpeed, float weight, Color mainColor, Color dopColor,
        bool window, bool line, bool trub) : base(maxSpeed, weight, mainColor, 150, 110)
        {
            DopColor = dopColor;
            Window = window;
            Line = line;
            Trub = trub;
        }

        public Teploboat(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Window = Convert.ToBoolean(strs[4]);
                Line = Convert.ToBoolean(strs[5]);
                Trub = Convert.ToBoolean(strs[6]);
            }
        }

        /// Отрисовка лодки
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            Brush brushDop = new SolidBrush(Color.Gray);
            if (Trub)
            {
                g.DrawRectangle(pen, _startPosX + 95, _startPosY, 20, 40);
                g.FillRectangle(brushDop, _startPosX + 96, _startPosY + 1, 19, 39);
                brushDop = new SolidBrush(DopColor);
            }
            if (Line)
            {
                pen = new Pen(MainColor, 3);
                g.DrawLine(pen, _startPosX + 20, _startPosY + 90, _startPosX + 130, _startPosY + 90);
                pen = new Pen(Color.Black);
            }
            if (Window)
            {
                g.DrawEllipse(pen, _startPosX + 40, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 70, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 100, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 100, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 70, _startPosY + 70, 10, 10);
                g.FillEllipse(brushDop, _startPosX + 40, _startPosY + 70, 10, 10);
            }
            base.DrawTransport(g);
        }

        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{separator}{DopColor.Name}{separator}{Window}{separator}" +
                $"{Line}{separator}{Trub}";
        }
        public bool Equals(Teploboat other)
        {
            if (!Equals((Ship)other))
                return false;
            if (DopColor != other.DopColor)
                return false;
            if (Window != other.Window)
                return false;
            if (Line != other.Line)
                return false;
            if (Trub != other.Trub)
                return false;
            return true;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Teploboat shipObj))
                return false;
            else
                return Equals(shipObj);
        }
    }
}
