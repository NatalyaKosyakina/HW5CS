using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal interface ICalc
    {
        event EventHandler GotResult;
        void summ(double x);
        void subtract(double x);
        void multiply(double x);
        void divide(double x);
        void RaiseEvent();
    }
}
