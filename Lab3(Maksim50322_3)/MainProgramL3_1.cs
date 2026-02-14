using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using WhatDay; //для использования данных из другого проекта

namespace Lab3_Maksim50322_3_
{
    public class MainProgramL3_1
    {
        public delegate bool UniTryParse<T>(string input, out T value); //дженерик для readvalue<T>
        public static T ReadValue<T>(string message, UniTryParse<T> parser) //самый универсальный метод ввода и безопасный на данный момент который я знаю
        {
            Console.Write(message);
            T value;

            while (!parser(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        public static int ReadInt(string message) //безопасный метод для int значений в коде практически не используется
        {
            Console.Write(message); //текстовое значение которое мы вводим, мы вводим строку, потом преобразуем ее в INT в переменную value
            int value; //вот сюда
            while(!int.TryParse(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: "); //сообщение если введен не тот тип данных
            }
            return value; //значение которое возвращает метод
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
            foreach (int days in months) //цикл форч для перебора всех месяцев и поиска нужного месяца
            {
                if (dayNum <= days) return (month, dayNum); //основной вывод метода
                dayNum -= days; //вычитаем количество дней месяца, если он не подходит
                month++; //инкрементируем месяц (счетчик который переключаем если перепрыгиваем месяц)
            }
            return (month, dayNum);// теоретически сюда не дойдём
        }


        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //эти три строчки для корректного ввода кирилицы
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU"); //при выводе данных с ценами, то будет автоматически указывать русскую валюту
            try
            {
                //int yearNum = ReadInt("Введите год: ");
                int yearNum = ReadValue<int>("Введите год: ", int.TryParse); //парсим год универсальным методом <int>после названия необходимо писать иначе компилятор не понимает какой ти данных обрабатывать, можно усложнить метод и будет совсем универсальный, но очень сложный метод 
                bool isLeapYear = IsLeapYear(yearNum); //проверяем високосный ли год

                //int dayNum = ReadInt("Введите день:");
                int dayNum = ReadValue<int>("Введите день: ", int.TryParse); //парсим день универсальным методом 

                ValidateDay(dayNum, isLeapYear); //проверка дня на правильность, что бы чуть что завершить программу
                //var result = GetMonthAndDay(dayNum, isLeapYear); //метод который выдает кортедж данных на входе день и високосность года
                var (monthNum, dayInMonth) = GetMonthAndDay(dayNum, isLeapYear); //деконструированный кортедж, читается легче, пишется чище, меньше переменных
                //MonthName monthName = (MonthName)result.monthNum;
                MonthName monthName = (MonthName)monthNum; //берем номер месяца и преобразуем его в номер из перечисления из другого проекта program.cs из WhatDay4
                if (isLeapYear) Console.WriteLine("Високосный год, так... на минуточку."); //просто прикол для упоминания что год високосный
                //Console.WriteLine($"{result.dayInMonth} {monthName}"); //старый вывод если бы я не деконструировал кортеж данных
                Console.WriteLine($"{dayInMonth} {monthName}"); //если бы не деконструировал кортеж, то пришлось бы писать переменную result. что немного неудобно и с первого взляда не понятно что я тут написал
                Console.ReadLine(); //используется для ожидания ентера
            }catch (Exception caught) //просто исключение, я не совсем их понммаю, но знаю, что сюда надо писать именно его!
            {
                Console.WriteLine(caught.Message); //вывод текста исключения
            }

        }
    }
}
