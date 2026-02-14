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
        public delegate bool UniTryParse<T>(string input, out T value); //дженерик для readvalue<T>
        public static T ReadValue<T>(string message, UniTryParse<T> parser) //самый универсальный метод ввода и безопасный на данный момент который я знаю
        {
            Console.Write(message);
            T value;

            while (!parser(Console.ReadLine(), out value))
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        public static int ReadInt(string message) //безопасный метод для int значений
        {
            Console.Write(message);
            int value;
            while(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        public static bool IsLeapYear(int year) //проверка года на високосность
        {
            return ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0);
        }
        public static void ValidateDay(int day, bool isLeap) //выбор массива дней для года
        {
            int max = isLeap ? 366 : 365; 
            if (day < 1 || day > max) throw new ArgumentOutOfRangeException("Day out of range"); //проверка корректности входных данных и генерация исключения, если данные неверные.
        }

        public static (int monthNum, int dayInMonth) GetMonthAndDay(int dayNum, bool isLeap) //основной расчет, на выходе кортедж данных (месяц и день) на вход (день и високостность года)
        {
            int[] months = isLeap ? WhatDay.Program.DaysInMonthsLeap : WhatDay.Program.DaysInMonths; //данные берутся из другого проекта
            int month = 0;
            foreach (int days in months)
            {
                if (dayNum <= days) return (month, dayNum); //основной вывод метода
                dayNum -= days;
                month++;
            }
            return (month, dayNum);// теоретически сюда не дойдём
        }


        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //эти три строчки для корректного ввода кирилицы
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            try
            {
                //int yearNum = ReadInt("Введите год: ");
                int yearNum = ReadValue<int>("Введите год: ", int.TryParse); //парсим год универсальным методом
                bool isLeapYear = IsLeapYear(yearNum);

                //int dayNum = ReadInt("Введите день:");
                int dayNum = ReadValue<int>("Введите день: ", int.TryParse); //парсим день универсальным методом

                ValidateDay(dayNum, isLeapYear); //проверка дня на правильность, что бы чуть что завершить программу
                //var result = GetMonthAndDay(dayNum, isLeapYear); //метод который выдает кортедж данных на входе день и високосность года
                var (monthNum, dayInMonth) = GetMonthAndDay(dayNum, isLeapYear);
                //MonthName monthName = (MonthName)result.monthNum;
                MonthName monthName = (MonthName)monthNum;
                if (isLeapYear) Console.WriteLine("Високосный год, так... на минуточку.");
                //Console.WriteLine($"{result.dayInMonth} {monthName}");
                Console.WriteLine($"{dayInMonth} {monthName}");
                Console.ReadLine();
            }catch (Exception caught)
            {
                Console.WriteLine(caught.Message);
            }

        }
    }
}
