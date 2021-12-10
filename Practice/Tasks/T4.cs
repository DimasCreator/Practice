using System;
using Algorithms.SortingAlgorithms;

namespace Practice.Tasks
{
    public static class T4
    { 
        /// <summary>//TODO: не готово
        /// Требуется найти наименьшее натуральное число Q такое, что произведение его цифр равно заданному числу N.
        /// </summary>
        public static void Task()
        {
            int n;
            while (true)
            {
                Console.WriteLine("Введите число для факторизации");
                if (int.TryParse(Console.ReadLine(), out n)) break;
                Console.WriteLine("Нужно целое число");
            }
            var number = 1;
            while (true)
            {
                if (n == number.ProductionNumber())
                {
                    Console.WriteLine(number);
                    return;
                }
                number++;
            }
        }

        private static int ProductionNumber(this int number)
        {
            var result = 1;
            while (number % 10 != 0)
            {
                result *= number % 10;
                number /= 10;
            }
            return result;
        }
    }
}