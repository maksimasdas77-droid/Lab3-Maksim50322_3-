using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDay
{
    internal enum MonthName
    {
        January, 
        February,
        March,
        April,
        May,
        June, 
        July, 
        August, 
        September, 
        October, 
        November, 
        December
}

internal class Program
    {
        static int[] DaysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");


            Console.Write("Please enter a day number between 1 and 365: ");
            string line = Console.ReadLine();
            int dayNum = int.Parse(line);
            int monthNum = 0;

            foreach (int daysInMonth in DaysInMonths)
            {
                if (dayNum <= daysInMonth)
                {
                    break;
                }
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }

            }

            MonthName temp = (MonthName)monthNum;
            string monthName = temp.ToString();
            Console.WriteLine("{0} {1}", dayNum, monthName);
            Console.WriteLine($"{dayNum} {monthName}");
            Console.ReadLine();

        }
    }
}
