using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.SortingAlgorithms;

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


        /// <summary>
        /// на вход подается массив чисел, нужно вывести диапазоны одной строкой ([1, 4, 6, 5, 7, 2, 19] -> '1-2, 4-7, 9')
        /// </summary>
        public static string Task2(int[] array)
        {
            StringBuilder diapasons = new StringBuilder();

            if(array == null || array.Length == 0)
            {
                return "";
            }
            if(array.Length == 1)
            {
                return array[0].ToString();
            }

            Sorter.BubbleSort(array);
            int currentStart = array[0];
            int currentFinish = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                if(array[i] - array[i-1] <= 1)
                {
                    currentFinish = array[i];
                }
                else
                {
                    if (currentStart != currentFinish)
                        diapasons.Append($"[{currentStart}-{currentFinish}]");
                    else
                        diapasons.Append($"[{currentFinish}]");
                    currentStart = array[i];
                    currentFinish = array[i];
                }
            }
            if (currentStart != currentFinish)
                diapasons.Append($"[{currentStart}-{currentFinish}]");
            else
                diapasons.Append($"[{currentFinish}]");

            return diapasons.ToString();
        }
        /*Тесты
         * Console.WriteLine(YandexOnline.Task2(new[] { 1, 4, 6, 5, 7, 2, 9 })); // 1-2, 4-7, 9
         * Console.WriteLine(YandexOnline.Task2(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })); // 1-10
         * Console.WriteLine(YandexOnline.Task2(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })); // 1-10
         * Console.WriteLine(YandexOnline.Task2(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })); // 1
         * Console.WriteLine(YandexOnline.Task2(new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 })); // -4-4
         * Console.WriteLine(YandexOnline.Task2(new[] { -65, -64, -63, -62, -61 })); // -65--61
         * Console.WriteLine(YandexOnline.Task2(new[] { 100, 45, 78, -100, -34, -67, 412 })); // -100 -67 -34 45 78 100 412 
         * Console.WriteLine(YandexOnline.Task2(new[] { 1, 2, 3, 4, 9, 8, 7, 6 })); // 1-4 6-9
         * Console.WriteLine(YandexOnline.Task2(new[] { 1, 2, 3, 47, 8, 9, 15, 16, 17 })); // 1-3 8-9 15-17 47
         */

        /// <summary>
        /// Вывести максимальную длину подстроки с одинаковыми буквами из входной строки
        /// </summary>
        public static int Task3(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            int maxLength = 1;
            int currentLength = 1;
            for(int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if(maxLength < currentLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
            }
            if (maxLength < currentLength)
            {
                maxLength = currentLength;
            }
            return maxLength;
        }
        /*Тесты
         * Console.WriteLine(YandexOnline.Task3("aaaavvvvccccc")); // 5
         * Console.WriteLine(YandexOnline.Task3("abjsanbjnasjvbdijansdvjisdn;iccccccmnbflksdnklfdnksblnfkdsl")); // 6
         * Console.WriteLine(YandexOnline.Task3("ccbbccbbccbbccbb")); // 2
         * Console.WriteLine(YandexOnline.Task3("")); // 0
         * Console.WriteLine(YandexOnline.Task3(null)); // 0
         * Console.WriteLine(YandexOnline.Task3("a")); // 1
         * Console.WriteLine(YandexOnline.Task3("anvmdlhgjrl;'dcksa")); // 1
         * Console.WriteLine(YandexOnline.Task3("nbmfjdjjjjdkdlcllldjkrkkkkkkk")); // 7
         * Console.WriteLine(YandexOnline.Task3("asdczxmnb")); // 1
         */
    }
}
