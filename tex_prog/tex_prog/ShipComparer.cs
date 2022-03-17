using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsShip
{
    internal class ShipComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is Teploboat && y is Ship)
            {
                return -1;
            }
            if (x is Ship && y is Teploboat)
            {
                return 1;
            }


            if (x is Teploboat && y is Teploboat)
            {
                return ComparerTeploboat((Teploboat)x, (Teploboat)y);
            }
            if (x is Ship && y is Ship)
            {
                return ComparerShip((Ship)x, (Ship)y);
            }
            return 0;
        }
        private int ComparerShip(Ship x, Ship y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerTeploboat(Teploboat x, Teploboat y)
        {
            var res = ComparerShip(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.Window != y.Window)
            {
                return x.Window.CompareTo(y.Window);
            }
            if (x.Line != y.Line)
            {
                return x.Line.CompareTo(y.Line);
            }
            if (x.Trub != y.Trub)
            {
                return x.Trub.CompareTo(y.Trub);
            }
            return 0;
        }
    }
}