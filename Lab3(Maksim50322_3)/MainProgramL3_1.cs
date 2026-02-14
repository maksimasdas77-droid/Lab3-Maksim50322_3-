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
                Console.Write("Введите год: ");
                int yearNum = int.Parse(Console.ReadLine());
                bool isLeapYear = IsLeapYear(yearNum);

                Console.Write("Введите день: ");
                int dayNum = int.Parse(Console.ReadLine());

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
