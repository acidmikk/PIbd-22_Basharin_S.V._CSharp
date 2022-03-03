using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsShip
{
    internal class DockOverflowException : Exception
    {
        public DockOverflowException() : base("В доке нет места!")
        { }
    }
}
