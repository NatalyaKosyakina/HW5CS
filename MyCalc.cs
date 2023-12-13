using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class MyCalc : ICalc
    {
        public event EventHandler GotResult;
        public double Result = 0;
        private Stack<double> Results = new ();

        public void divide(double x)
        {
            Results.Push(Result);
            try
            {
                Result /= x;
                RaiseEvent();
            }
            catch (DivideByZeroException e) { 
            throw  new CalculatorDivideByZeroException(e);
            }
            
        }

        public void multiply(double x)
        {
            Results.Push(Result);
            Result *= x;
            RaiseEvent();
        }

        public void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void subtract(double x)
        {
            Results.Push(Result);
            Result -= x;
            RaiseEvent();
        }

        public void summ(double x)
        {
            Results.Push(Result);
            Result += x;
            RaiseEvent();
        }

        public void CancelLastAction()
        {
            Result = Results.Pop();
            RaiseEvent();
        }

        public int getResultsCount()
        {
            return Results.Count;
        }
    }
}
