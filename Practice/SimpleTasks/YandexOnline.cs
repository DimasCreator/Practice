using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.SimpleTasks
{
    /// <summary>
    /// Задачи онлайн собеседования Яндекс на позицию стажера.
    /// </summary>
    public class YandexOnline
    {
        /// <summary>
        /// Вывести все простые числа из диапазона заданного пользователем
        /// Условность, что число больше 2
        /// </summary>
        public static LinkedList<int> Task1(int n)
        {
            LinkedList<int> numbersList = new LinkedList<int>();
            for(int i = 2; i <= n; i++)
            {
                if (IsSimple(i))
                {
                    numbersList.AddLast(i);
                }
            }
            return numbersList;
        }
        private static bool IsSimple(int number)
        {
            double sqrt = Math.Sqrt(number);
            for(int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }



        public static string Task2(int[] array)
        {
            return "";
        }

        public static int Task3(string str)
        {
            return 0;
        }
    }
}
