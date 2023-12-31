﻿using System;

namespace Lesson5
{
    internal class Program
    {
        public static void ShowResult(MyCalc sendler)
        {
            Console.WriteLine("Результат: " + sendler.Result);
        }

        public static void CheckForException(Action<double> action, double value) {
            try
            {
                checked
                {
                    double value1 = value;
                    action.Invoke(value1);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool SelectDoing(MyCalc sendler, string doing, out Action<double> action)
        {
            switch (doing)
            {
                case "+":
                    action = sendler.summ;
                    return true;
                case "-":
                    action = sendler.subtract;
                    return true; 
                case "*":
                    action = sendler.multiply;
                    return true;
                case "/":
                    action = sendler.divide;
                    return true;
                default:
                    action = null;
                    Console.WriteLine("Нет такого действия");
                    return false;
            }
        }
        static void Main(string[] args)
        {
            MyCalc sendler = new MyCalc();
            bool flag1 = true;
            bool flag2 = false;
            double number = 0;
            Action<double> doing = Console.WriteLine;
            Console.WriteLine("Введите число: ");
            string? input = Console.ReadLine();
            if (input.Equals(String.Empty))
            {
                flag1 = false;
            }
            else
            {
                if (double.TryParse(input, out checked(number)))
                {
                    flag2 = true;
                    sendler.Result = number;
                }

            }

            while (flag1)
            {
                while (flag2)
                {
                    Console.WriteLine("Выберите действие: ");
                    string? inputdoing = Console.ReadLine();
                    if (inputdoing.Equals(String.Empty))
                    {
                        flag2 = false;
                        flag1 = false;
                    }
                    else
                    {
                        flag2 = !SelectDoing(sendler, inputdoing, out doing);
                    }
                }

                Console.WriteLine("Введите число: ");
                input = Console.ReadLine();
                if (input.Equals(String.Empty))
                {
                    flag1 = false;
                }
                else
                {
                    if (double.TryParse(input, out checked (number)))
                    {
                        CheckForException(doing, number);
                        flag2 = true;
                    }

                }
                ShowResult(sendler);
            }            
        }
    }
}
