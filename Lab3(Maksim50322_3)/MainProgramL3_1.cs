using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using WhatDay;

namespace Lab3_Maksim50322_3_
{
    public class MainProgramL3_1
    {
        public delegate bool UniTryParse<T>(string input, out T value);
        public static T ReadValue<T>(string message, UniTryParse<T> parser)
        {
            Console.Write(message);
            T value;

            while (!parser(Console.ReadLine(), out value))
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        public static int ReadInt(string message)
        {
            Console.Write(message);
            int value;
            while(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        public static bool IsLeapYear(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0);
        }
        public static void ValidateDay(int day, bool isLeap) 
        {
            int max = isLeap ? 366 : 365; 
            if (day < 1 || day > max) throw new ArgumentOutOfRangeException("Day out of range");
        }

        public static (int monthNum, int dayInMonth) GetMonthAndDay(int dayNum, bool isLeap)
        {
            int[] months = isLeap ? WhatDay.Program.DaysInMonthsLeap : WhatDay.Program.DaysInMonths;
            int month = 0;
            foreach (int days in months)
            {
                if (dayNum <= days) return (month, dayNum);
                dayNum -= days;
                month++;
            }
            return (month, dayNum);// теоретически сюда не дойдём
        }


        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            try
            {
                //int yearNum = ReadInt("Введите год: ");
                int yearNum = ReadValue<int>("Введите год: ", int.TryParse);
                bool isLeapYear = IsLeapYear(yearNum);

                //int dayNum = ReadInt("Введите день:");
                int dayNum = ReadValue<int>("Введите день: ", int.TryParse);

                ValidateDay(dayNum, isLeapYear);
                var result = GetMonthAndDay(dayNum, isLeapYear);
                MonthName monthName = (MonthName)result.monthNum;
                if (isLeapYear) Console.WriteLine("Високосный год, так... на минуточку.");
                Console.WriteLine($"{result.dayInMonth} {monthName}");
                Console.ReadLine();
            }catch (Exception caught)
            {
                Console.WriteLine(caught.Message);
            }

        }
    }
}
