using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDayWithNewKnowledge
{
    public class Readclas
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
        public static T ReadValue<T>(UniTryParse<T> parser) //самый универсальный метод ввода и безопасный на данный момент который я знаю
        {
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
            while (!int.TryParse(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: "); //сообщение если введен не тот тип данных
            }
            return value; //значение которое возвращает метод
        }

    }
}
