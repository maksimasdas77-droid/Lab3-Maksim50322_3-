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
        static int[] DaysInMonthsLeap = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");

            try
            {
                Console.Write("Please enter the year: ");
                string line = Console.ReadLine();
                int yearNum = int.Parse(line);

                bool isLeapYear = false;
                if ((yearNum % 4 == 0 && yearNum % 100 != 0) || yearNum % 400 == 0)
                {
                    isLeapYear = true;
                }


                Console.Write("Please enter a day number: ");
                line = Console.ReadLine();
                int dayNum = int.Parse(line);
                if (isLeapYear)
                { 
                    if (dayNum < 1 || dayNum > 366) 
                        throw new ArgumentOutOfRangeException("Day out of range"); 
                } else 
                { 
                    if (dayNum < 1 || dayNum > 365) 
                        throw new ArgumentOutOfRangeException("Day out of range");
                }

                int monthNum = 0;
                if (isLeapYear == true)
                {
                    foreach (int daysInMonth in DaysInMonthsLeap)
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
                }
                else
                {
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
                }

                MonthName temp = (MonthName)monthNum;
                string monthName = temp.ToString();
                if (isLeapYear)
                {
                    Console.WriteLine("Високосный год, так... на минуточку.");
                }
                Console.WriteLine("{0} {1}", dayNum, monthName);
                Console.WriteLine($"{dayNum} {monthName}");
                Console.ReadLine();
            }
            catch (Exception caught) { Console.WriteLine(caught); }


        }
    }
}
