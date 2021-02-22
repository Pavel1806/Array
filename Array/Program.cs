using System;
using System.Collections.Generic;

namespace Array
{
    class Program
    {
        /// <summary>
        /// счетчик
        /// </summary>
        static public int I { get; set; }

        /// <summary>
        /// делегат для нахождения нуля в массиве
        /// </summary>
        public delegate void myDeleg();

        /// <summary>
        /// делегат для определения конца массива
        /// </summary>
        /// <param name="x">счетчик</param>
        public delegate void myDeleg2(int x);

        /// <summary>
        /// словарь для нахождения нуля в массиве
        /// </summary>
        static Dictionary<int, myDeleg> Handlers = new Dictionary<int, myDeleg>();

        /// <summary>
        /// словарь для определения конца массива
        /// </summary>
        static Dictionary<int, myDeleg2> Handlers2 = new Dictionary<int, myDeleg2>();

        /// <summary>
        /// массив
        /// </summary>
        static int[] Array;

        /// <summary>
        /// констуктор для инициализации данных
        /// </summary>
        static Program()
        {
            Array = new int[9] { 9, 2, 5, 7, 2, 1, 4, 0, 9 };

            Handlers = new Dictionary<int, myDeleg>
            {
                { 1, new myDeleg(Func1)},
                { 2, new myDeleg(Func1)},
                { 3, new myDeleg(Func1)},
                { 4, new myDeleg(Func1)},
                { 5, new myDeleg(Func1)},
                { 6, new myDeleg(Func1)},
                { 7, new myDeleg(Func1)},
                { 8, new myDeleg(Func1)},
                { 9, new myDeleg(Func1)},
                { 0 , new myDeleg(Func2)}
            };
            Handlers2 = new Dictionary<int, myDeleg2>
            {
                { 1, new myDeleg2(CheckingZero)},
                { 2, new myDeleg2(CheckingZero)},
                { 3, new myDeleg2(CheckingZero)},
                { 4, new myDeleg2(CheckingZero)},
                { 5, new myDeleg2(CheckingZero)},
                { 6, new myDeleg2(CheckingZero)},
                { 7, new myDeleg2(CheckingZero)},
                { 8, new myDeleg2(CheckingZero)},
                { Array.Length, new myDeleg2(Func3)},
                { 0 , new myDeleg2(CheckingZero)}
            };
        }

       /// <summary>
       /// метод для возвращения программы для проверки следующего члена массива
       /// </summary>
        static public void Func1()
        {
            СheckingСounter();
        }

        /// <summary>
        /// метод для вывода "Yes" если найден ноль
        /// </summary>
        static public void Func2()
        {
            Console.WriteLine("Yes");
        }
        /// <summary>
        /// метод для вывода "No" если массив закончился
        /// </summary>
        /// <param name="i"></param>
        static public void Func3(int i)
        {
            Console.WriteLine("No");
        }

        /// <summary>
        /// Метод для перещелкивания счетчика
        /// </summary>
        /// <returns></returns>
        static public int Count()
        {
            return I++;
        }

        /// <summary>
        /// Метод для проверки счетчика на окончание массива
        /// </summary>
        static public void СheckingСounter()
        {
            int a = Count();

            Handlers2[a](a);
        }
        /// <summary>
        /// Метод для проверки наличия в массиве нуля
        /// </summary>
        /// <param name="a"></param>
        static public void CheckingZero(int a)
        {
            int[] array1 = Array;
            Handlers[array1[a]]();
        }

        static void Main(string[] args)
        {
            СheckingСounter();
        }
    }
}
