using System;

namespace Lesson5
{
    internal class Program
    {
        public static void ShowResult(MyCalc sendler)
        {
            Console.WriteLine("Результат: " + sendler.Result);
        }

        public static void SelectDoing(MyCalc sendler, double num1, string doing)
        {
            switch (doing)
            {
                case "+":
                    sendler.summ(num1);
                    break;
                case "-":
                    sendler.subtract(num1);
                    break; 
                case "*":
                    sendler.multiply(num1);
                    break;
                case "/":
                    sendler.divide(num1);
                    break;
                default: Console.WriteLine("Нет такого действия");
                    break;
            }
        }
        static void Main(string[] args)
        {
            MyCalc sendler = new MyCalc();
            bool flag1 = true;
            bool flag2 = false;
            double number = 0;
            while (flag1)
            {
                while (flag2)
                {
                    Console.WriteLine("Выберите действие: ");
                    string? doing = Console.ReadLine();
                    if (doing.Equals(String.Empty))
                    {
                        flag2 = false;
                        flag1 = false;
                    }
                    else
                    {
                        SelectDoing(sendler, number, doing);
                        ShowResult(sendler);
                        flag2 = false;
                    }
                }

                Console.WriteLine("Введите число: ");
                string? input = Console.ReadLine();
                if (input.Equals(String.Empty))
                {
                    flag1 = false;
                }
                else
                {
                    if (double.TryParse(input, out number))
                    {
                        flag2 = true;
                    }

                }
            }            
        }
    }
}
