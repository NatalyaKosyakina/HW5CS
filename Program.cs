using System;

namespace Lesson5
{
    internal class Program
    {
        public static void ex1()
        {
            /*Спроектируем интерфейс калькулятора, поддерживающего простые арифметические действия,
             * хранящего результат и также способного выводить информацию о результате  при помощи события

            static void Calculator_GotResult(object sendler, EventArgs eventArgs)
            {
                Console.WriteLine($"{((Calculator)sendler).Result}");
            }
            static void Calculator_GotResultTwo(object sendler, EventArgs eventArgs)
            {
                Console.WriteLine($"result = {((Calculator)sendler).Result}");
            }
            static void Main(string[] args)
            {
                ICalc calc = new Calculator();

                calc.GotResult += Calculator_GotResult;
                calc.GotResult += Calculator_GotResultTwo;
                calc.Sum(12);
                calc.Substruct(7);
                calc.Multiply(13);

            }*/
        }
        public static void ex2() { 
        }

        public static void ex3()
        {
            /*Описание: Создайте метод, который принимает список чисел и функцию (делегат Func),
             * выполняющую какую-либо операцию над числами и возвращающую результат.*/
            
        }
        static int calculateSumm(List<int> numbers, Predicate<int> iseven, Func<int, int, int> operation, Action<int> actsome)
        {
            int summ = 0;
            foreach (var item in numbers)
            {
                if (iseven(item))
                {
                    summ = operation(item, summ);
                    actsome(summ);
                }               
            }
            return summ;
        } 
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 3, 4, 5, 6, 9, 8, 7};

            int res = calculateSumm(numbers, x => x % 2 == 0, (x, y) => x + y, Console.WriteLine);
            Console.WriteLine(res);
        }
    }
}
