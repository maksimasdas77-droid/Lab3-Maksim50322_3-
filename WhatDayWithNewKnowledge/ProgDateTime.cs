using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDayWithNewKnowledge
{

    internal class ProgDateTime
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Введите 0 для выхода из программы");
                    int yearnum = Readclas.ReadValue<int>("Введите год: ", int.TryParse);
                    if (yearnum == 0)
                    {
                        Console.WriteLine("Выход");
                        run = false;
                        Console.ReadLine();
                        break;
                    }
                    int daynum = Readclas.ReadValue<int>("Введите день: ", int.TryParse);
                    bool isLeap = DateTime.IsLeapYear(yearnum);

                    if (daynum < 1 || daynum > (isLeap ? 366 : 365))
                    {
                        Console.WriteLine("Ошибка: такого дня в этом году нет. Попробуйте снова.\n");
                        continue;
                    }

                        //throw new ArgumentOutOfRangeException("Day out of range");
                    DateTime date = new DateTime(yearnum, 1, 1).AddDays(daynum - 1);

                    if (isLeap) Console.WriteLine("ВИСОКОСНЫЙ ГОД");

                    Console.WriteLine($"\nРезультаты:");
                    Console.WriteLine($"стардартный: {date:d MMMM yyyy}");
                    Console.WriteLine($"имя месяца: {date:MMMM}");
                    Console.WriteLine($"день месяца: {date.Day}");
                    Console.WriteLine($"номер месяца: {date.Month}");
                    Console.WriteLine($"день недели: {date.DayOfWeek}");
                    Console.WriteLine("еще пару вариантов вывода");
                    Console.WriteLine($"{date.Day} {date.ToString("MMMM")}");
                    Console.WriteLine(date.ToString("dd MMMM yyyy"));

                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
